namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    private readonly Dictionary<Type, ServiceDescriptor> _map = new();
    private readonly Dictionary<Type, object> _singletons = new();
    private readonly object _lock = new();

    public void Register<TService, TImpl>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TImpl : TService
        => _map[typeof(TService)] = ServiceDescriptor.AsImplementation(typeof(TService), typeof(TImpl), lifetime);

    public void RegisterInstance<TService>(TService instance)
        => _map[typeof(TService)] = ServiceDescriptor.AsInstance(typeof(TService), instance!);

    public TService Resolve<TService>() => (TService)Resolve(typeof(TService));

    public object Resolve(Type serviceType)
    {
        var stack = new HashSet<Type>();
        return ResolveInternal(serviceType, stack);
    }

    private object ResolveInternal(Type serviceType, HashSet<Type> stack)
    {
        if (!_map.TryGetValue(serviceType, out var desc))
        {
            if (!serviceType.IsAbstract && !serviceType.IsInterface)
                desc = ServiceDescriptor.AsImplementation(serviceType, serviceType, ServiceLifetime.Transient);
            else
                throw new InvalidOperationException($"Service not registered: {serviceType.FullName}");
        }

        if (desc.Instance is not null) return desc.Instance;

        if (desc.Lifetime == ServiceLifetime.Singleton)
        {
            lock (_lock)
            {
                if (_singletons.TryGetValue(serviceType, out var existing)) return existing;
                var created = CreateInstance(desc, stack);
                _singletons[serviceType] = created;
                return created;
            }
        }

        return CreateInstance(desc, stack);
    }

    private object CreateInstance(ServiceDescriptor desc, HashSet<Type> stack)
    {
        if (!stack.Add(desc.ImplementationType))
            throw new InvalidOperationException($"Circular dependency detected: {desc.ImplementationType.FullName}");

        try
        {
            var ctors = desc.ImplementationType
                .GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length);

            foreach (var ctor in ctors)
            {
                var parms = ctor.GetParameters();
                var args = new object[parms.Length];
                var ok = true;

                for (int i = 0; i < parms.Length; i++)
                {
                    try
                    {
                        args[i] = ResolveInternal(parms[i].ParameterType, stack);
                    }
                    catch
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok) return Activator.CreateInstance(desc.ImplementationType, args)!;
            }

            var tried = string.Join(Environment.NewLine, desc.ImplementationType
                .GetConstructors()
                .Select(c => $"  {desc.ImplementationType.Name}({string.Join(", ", c.GetParameters().Select(p => p.ParameterType.FullName))})"));

            throw new InvalidOperationException(
                $"No satisfiable public constructor for {desc.ImplementationType.Name}. Tried:\n{tried}\n" +
                $"Make sure all parameter types are registered with the exact same interface types (namespaces included).");
        }
        finally
        {
            stack.Remove(desc.ImplementationType);
        }
    }

    public sealed record ServiceDescriptor(
        Type ServiceType,
        Type ImplementationType,
        ServiceLifetime Lifetime,
        object? Instance)
    {
        public static ServiceDescriptor AsImplementation(Type svc, Type impl, ServiceLifetime life)
            => new(svc, impl, life, null);

        public static ServiceDescriptor AsInstance(Type svc, object instance)
            => new(svc, instance.GetType(), ServiceLifetime.Singleton, instance);
    }
}
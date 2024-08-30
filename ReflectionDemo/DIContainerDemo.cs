

namespace ReflectionDemo;

public interface IServiceC
{
    void DoWork();
}


public class ServiceC : IServiceC
{
    public void DoWork()
    {
        Console.WriteLine("ServiceC is doing work.");
    }
}

public interface IServiceA
{
    void DoWork();
}

public class ServiceA : IServiceA
{
    private readonly IServiceC _serviceC;

    public ServiceA(IServiceC serviceC)
    {
        _serviceC = serviceC;
    }

    public void DoWork()
    {
        _serviceC.DoWork();

        Console.WriteLine("ServiceA is doing work.");
    }
}

public interface IServiceB
{
    void DoWork();
}

public class ServiceB : IServiceB
{
    private readonly IServiceA _serviceA;

    public ServiceB(IServiceA serviceA)
    {
        _serviceA = serviceA;
    }

    public void DoWork()
    {
        _serviceA.DoWork();
        Console.WriteLine("ServiceB is doing work.");
    }
}


internal class DIContainerDemo
{
    public static void Run()
    {
        Func<Type, object> serviceProvider = default!;

        // Simulate a DI container with a simple factory method
        serviceProvider = new Func<Type, object>(type =>
        {
            if (type == typeof(IServiceC)) 
                return CreateInstance<ServiceC>(serviceProvider); 
            if (type == typeof(IServiceA)) 
                return CreateInstance<ServiceA>(serviceProvider);
            if (type == typeof(IServiceB)) 
                return CreateInstance<ServiceB>(serviceProvider);

            throw new Exception("Type not registered.");
        });

        try
        {
            // Create an instance of ServiceB using reflection
            var serviceB = CreateInstance<ServiceB>(serviceProvider);
            serviceB.DoWork();

            var serviceC = CreateInstance<ServiceC>(serviceProvider);
            serviceC.DoWork();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    private static T CreateInstance<T>(Func<Type, object> serviceProvider = null)
    {
        var constructor = typeof(T).GetConstructors().FirstOrDefault();
        if (constructor == null)
            throw new Exception("No public constructors found.");

        var parameters = constructor.GetParameters();
        var parameterInstances = parameters
                            .Select(p => serviceProvider?.Invoke(p.ParameterType) ?? 
                             Activator.CreateInstance(p.ParameterType)).ToArray();

        return (T)constructor.Invoke(parameterInstances);
    }
}

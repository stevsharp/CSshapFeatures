namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    public sealed class Repo : IRepo
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    public interface IRepo { Guid Id { get; } }
}
namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    public interface IService
    {
        ILogger Logger { get; }
        IRepo Repo { get; }
    }
}
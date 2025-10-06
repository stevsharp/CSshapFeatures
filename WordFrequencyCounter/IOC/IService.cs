namespace WordFrequencyCounter.IOC;


    public interface IService
    {
        ILogger Logger { get; }
        IRepo Repo { get; }
    }

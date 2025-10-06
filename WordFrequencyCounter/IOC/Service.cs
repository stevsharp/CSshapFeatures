namespace WordFrequencyCounter.IOC;


    public sealed class Service : IService
    {
        public ILogger Logger { get; }
        public IRepo Repo { get; }

        public Service(ILogger logger, IRepo repo)
        {
            Logger = logger;
            Repo = repo;
            logger.Log($"Service constructed with Repo {repo.Id}");
        }
    }

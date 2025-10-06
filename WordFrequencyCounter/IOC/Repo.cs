namespace WordFrequencyCounter.IOC;


    public sealed class Repo : IRepo
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

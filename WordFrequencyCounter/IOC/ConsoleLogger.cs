namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    public sealed class ConsoleLogger : ILogger
    {
        public void Log(string msg) => Console.WriteLine($"[LOG] {msg}");
    }
}
using static WordFrequencyCounter.IOC.ServiceContainer;

namespace WordFrequencyCounter.IOC;

public sealed class ConsoleLogger : ILogger
{
    public void Log(string msg) => Console.WriteLine($"[LOG] {msg}");
}

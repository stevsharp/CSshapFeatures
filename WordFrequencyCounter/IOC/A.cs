namespace WordFrequencyCounter.IOC;

public sealed partial class ServiceContainer
{
    // Types to demonstrate cycle detection: A -> B -> A
    public sealed class A
    {
        public A(B b) { }
    }
}
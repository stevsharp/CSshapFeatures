
using System;
using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {

        // Step 1: Create an instance of IHelloWorldService implementation
        IHelloWorldService helloWorldService = new HelloWorldService();
        IHelloWorldService1 helloWorldService1 = new HelloWorldService1();

        var list = new List<object>
        {
            helloWorldService,
            helloWorldService1
        };


        // Step 2: Use Activator.CreateInstance to create an instance of MyProgram
        // and pass in the IHelloWorldService instance as a parameter
        //MyProgram myProgramInstance = (MyProgram)Activator.CreateInstance(typeof(MyProgram), new object[] { helloWorldService, helloWorldService1 });
        MyProgram myProgramInstance = (MyProgram)Activator.CreateInstance(typeof(MyProgram), list.ToArray());

        // Optional: Call the Run method on MyProgram instance
        myProgramInstance.Run();

        Console.ReadLine();
    }


}

public interface IHelloWorldService
{
    void SayHello();
}

public interface IHelloWorldService1
{
    void SayHello();
}


public class HelloWorldService1 : IHelloWorldService1
{
    public void SayHello()
    {
        Console.WriteLine("Hello, World! 1");
    }
}

public class HelloWorldService : IHelloWorldService
{
    public void SayHello()
    {
        Console.WriteLine("Hello, World! 0");
    }
}

public class MyProgram : IMyProgram
{
    public readonly IHelloWorldService _helloWorldService;
    public readonly IHelloWorldService1 _helloWorldService1;

    public MyProgram(IHelloWorldService helloWorldService, IHelloWorldService1 helloWorldService1)
    {
        _helloWorldService = helloWorldService;
        _helloWorldService1 = helloWorldService1;
    }



    public void Run()
    {
        Console.WriteLine("Hello From My Program");

        _helloWorldService.SayHello();

        _helloWorldService1.SayHello();
    }
}

public interface IMyProgram
{
    void Run();
}
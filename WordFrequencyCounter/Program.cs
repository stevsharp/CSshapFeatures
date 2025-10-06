using WordFrequencyCounter.IOC;

using static WordFrequencyCounter.IOC.ServiceContainer;

while (true)
{
    Console.Clear();
    Console.WriteLine("===== C# Weekly Challenges =====");
    Console.WriteLine("1. Challenge 01 – Word Frequency Counter");
    Console.WriteLine("2. Challenge 02 – Custom LINQ Extension (ToChunks)");
    Console.WriteLine("3. Challenge 03 – Mini DI Container");
    Console.WriteLine("0. Exit");
    Console.WriteLine("===============================");
    Console.Write("Select a challenge: ");

    string ? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            RunChallenge01();
            break;
        case "2":
            RunChallenge02();
            break;
        case "3":
            RunChallenge03();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

static void RunChallenge03()
{
    Console.Clear();
    Console.WriteLine("=== Challenge 03: Mini DI Container ===");

    var c = new ServiceContainer();

    c.Register<ILogger, ConsoleLogger>(ServiceLifetime.Singleton);
    c.Register<IRepo, Repo>(ServiceLifetime.Transient);
    c.Register<IService, Service>(ServiceLifetime.Transient);

    var s1 = c.Resolve<IService>();
    var s2 = c.Resolve<IService>();

    Console.WriteLine($"s1 == s2? {ReferenceEquals(s1, s2)}  (expect: False)");
    Console.WriteLine($"s1.Logger == s2.Logger? {ReferenceEquals(((Service)s1).Logger, ((Service)s2).Logger)}  (expect: True)");
    Console.WriteLine($"s1.Repo == s2.Repo? {ReferenceEquals(((Service)s1).Repo, ((Service)s2).Repo)}  (expect: False)");

    Console.WriteLine("\nCycle detection demo (expect exception):");
    try
    {
        var c2 = new ServiceContainer();
        c2.Register<A, A>();
        c2.Register<B, B>();
        var a = c2.Resolve<A>(); // A -> B -> A (cycle)
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Caught: {ex.Message}");
    }

    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}


/// Challenge 01: Word Frequency Counter    
/// 🏆 Challenge 1 Breakdown
/// 1.Input Handling

// We need to accept a block of text (multi-line).

// For simplicity, you can use Console.ReadLine() in a loop until the user presses Enter on an empty line.

// Or, for testing, just store the text in a string variable.

// string input = This world is big, and this world is small."

static void RunChallenge01()
{
    Console.Clear();
    Console.WriteLine("=== Challenge 01: Word Frequency Counter ===");
    Console.WriteLine("Enter your text (finish with an empty line):");

    string input = "";
    string line = "";

    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
    {
        input += line + " ";
    }

    string normalized = new(
        input.ToLower()
        .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());

    string [] words = normalized.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    var stopwords = new HashSet<string> { "is", "the", "and", "a", "this" };
    var frequencies = words
        .Where(word => !stopwords.Contains(word))
        .GroupBy(word => word)
        .Select(g => new { Word = g.Key, Count = g.Count() })
        .OrderByDescending(w => w.Count)
        .ThenBy(w => w.Word);

    Console.WriteLine("\nTop 5 words:");

    foreach (var item in frequencies.Take(5))
    {
        Console.WriteLine($"{item.Word} -> {item.Count}");
    }

    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}

static void RunChallenge02()
{
    Console.Clear();
    Console.WriteLine("=== Challenge 02: Custom LINQ Extension Method ===");

    var numbers = Enumerable.Range(1, 10);

    var chunks = numbers.ToChunks(3);

    Console.WriteLine("Splitting 1–10 into chunks of 3:");
    foreach (var chunk in chunks)
    {
        Console.WriteLine($"[{string.Join(", ", chunk)}]");
    }

    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}
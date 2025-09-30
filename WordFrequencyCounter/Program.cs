
while (true)
{
    Console.Clear();
    Console.WriteLine("===== C# Weekly Challenges =====");
    Console.WriteLine("1. Challenge 01 – Word Frequency Counter");
    Console.WriteLine("2. Challenge 02 – (coming soon)");
    Console.WriteLine("3. Challenge 03 – (coming soon)");
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
            Console.WriteLine("Challenge 02 is coming soon!");
            break;
        case "3":
            Console.WriteLine("Challenge 03 is coming soon!");
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
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
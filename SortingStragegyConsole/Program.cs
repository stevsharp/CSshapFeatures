
using SortingStragegyConsole;

try
{
    SortableCollection data = new(new[] {"Lorem", "ipsum", "dolor", "sit", "amet." });

    // User inputs the sorting order
    Console.WriteLine("Enter sorting order (A/D):");
    string sortOrderInput = Console.ReadLine().Trim().ToLower();

    // Determine the sorting strategy based on user input
    ISortStrategy strategy = sortOrderInput == "A"
        ? new SortAscendingStrategy()
        : new SortDescingStrategy(); 

    // Set and perform the sorting
    data.SetSortStrategy(strategy);
    data.Sort();

    // Display the sorted result
    Console.WriteLine("Sorted data:");
    foreach (var item in data.Items)
    {
        Console.WriteLine(item);
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}

Console.ReadLine();
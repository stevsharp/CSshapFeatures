
namespace SortingStragegyConsole;

public class SortDescingStrategy : ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input) => input.OrderByDescending(x => x);

}

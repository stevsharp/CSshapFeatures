
namespace SortingStragegyConsole
{
    public interface ISortStrategy
    {
        IOrderedEnumerable<string> Sort(IEnumerable<string> input);
    }
}

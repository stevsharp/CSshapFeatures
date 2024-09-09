
using System.Collections;
using System.Collections.Immutable;

namespace SortingStragegyConsole;

public interface ISortStrategy
{
    IOrderedEnumerable<string> Sort(IEnumerable<string> input);
}

public class SortAscendingStrategy : ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input) => input.OrderBy(x => x);
    
}


public class SortDescingStrategy : ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input) => input.OrderByDescending(x => x);

}

public class SortableCollection(IEnumerable<string> items) : IEnumerable<string>
{

    private ISortStrategy _sortStrategy = new SortAscendingStrategy();

    private ImmutableArray<string> _items = items.ToImmutableArray();
    public IEnumerable<string> Items => _items;
    public void SetSortStrategy(ISortStrategy strategy)=> _sortStrategy = strategy;
    public void Sort() => _items = _sortStrategy.Sort(_items).ToImmutableArray();
    public IEnumerator<string> GetEnumerator()=> Items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()=> ((IEnumerable)Items).GetEnumerator();
}
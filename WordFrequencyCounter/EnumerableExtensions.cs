
public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> source, int size)
    {
        if (size <= 0)
            throw new ArgumentException("Chunk size must be greater than 0.", nameof(size));

        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                yield return YieldChunkElements(enumerator, size);
            }
        }
    }

    private static IEnumerable<T> YieldChunkElements<T>(IEnumerator<T> source, int size)
    {
        int count = 0;  

        do
        {
            yield return source.Current;
            count++;
        } 
        while (count < size && source.MoveNext());
    }

}

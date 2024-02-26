namespace Samokhvalov.LeetCode;

public static class Extensions
{
    public static string ToStringCollection<T>(this IEnumerable<T> array)
    {
        return string.Join(", ", array);
    }
    
    public static string ToStringCollectionMatrix<T>(this IEnumerable<IEnumerable<T>> array)
    {
        return string.Join("| ", array.Select(x => $"[{x.First()}, {x.Last()}]"));
    }
}
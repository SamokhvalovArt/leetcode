namespace Samokhvalov.LeetCode;

public static class Extensions
{
    public static string ToStringCollection<T>(this IEnumerable<T> array)
    {
        return string.Join(", ", array);
    }
}
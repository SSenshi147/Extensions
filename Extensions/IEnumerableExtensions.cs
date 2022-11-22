namespace Extensions;
public static class IEnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> values)
    {
        return values == null || !values.Any();
    }
}

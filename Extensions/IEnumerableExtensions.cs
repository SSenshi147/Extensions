namespace Extensions;
public static class IEnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> values)
    {
        return values == null || !values.Any();
    }

    public static T SingleOrThrow<T>(this IEnumerable<T> items, Func<T, bool> selector)
    {
        var single = items.SingleOrDefault(selector);

        if (single == null) { throw new Exception("not found"); }

        return single;
    }
}

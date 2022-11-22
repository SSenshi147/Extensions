namespace Extensions;
public static class ItemExtensions
{
    public static void CopyPropertiesFrom<T>(this T item, T source)
    {
        if (item == null) { throw new ArgumentNullException(nameof(item)); }
        if (source == null) { throw new ArgumentNullException(nameof(source)); }

        var fromProperties = source.GetType().GetProperties();
        var toProperties = item.GetType().GetProperties();

        foreach (var fromProperty in fromProperties)
        {
            foreach (var toProperty in toProperties)
            {
                if (fromProperty.Name == toProperty.Name &&
                    fromProperty.PropertyType == toProperty.PropertyType &&
                    toProperty.CanWrite)
                {
                    toProperty.SetValue(item, fromProperty.GetValue(source));
                    break;
                }
            }
        }
    }

    public static List<T> ToList<T>(this T item)
    {
        return new List<T>() { item };
    }

    public static string ToJson<T>(this T item)
    {
        return System.Text.Json.JsonSerializer.Serialize(item);
    }

    public static string ToJson<T>(this T item,
                                   System.Text.Json.JsonSerializerOptions jsonSerializerOptions)
    {
        return System.Text.Json.JsonSerializer.Serialize(item, jsonSerializerOptions);
    }

    public static string ToNewtonsoftJson<T>(this T item)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item);
    }

    public static string ToNewtonsoftJson<T>(this T item,
                                             Newtonsoft.Json.Formatting formatting)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item, formatting);
    }

    public static string ToNewtonsoftJson<T>(this T item,
                                             Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item, jsonSerializerSettings);
    }

    public static string ToNewtonsoftJson<T>(this T item,
                                             Newtonsoft.Json.Formatting formatting,
                                             Newtonsoft.Json.JsonSerializerSettings jsonSerializerSettings)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(item, formatting, jsonSerializerSettings);
    }
}

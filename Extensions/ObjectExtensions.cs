namespace Extensions;
public static class ObjectExtensions
{
    public static void CopyPropertiesFrom(this object self, object source)
    {
        var fromProperties = source.GetType().GetProperties();
        var toProperties = self.GetType().GetProperties();

        foreach (var fromProperty in fromProperties)
        {
            foreach (var toProperty in toProperties)
            {
                if (fromProperty.Name == toProperty.Name &&
                    fromProperty.PropertyType == toProperty.PropertyType &&
                    toProperty.CanWrite)
                {
                    toProperty.SetValue(self, fromProperty.GetValue(source));
                    break;
                }
            }
        }
    }
}

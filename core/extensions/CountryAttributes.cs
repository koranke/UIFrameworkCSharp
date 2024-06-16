using UIFrameworkCSharp.core.attributes;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.core.extensions;

public static class CountryAttributes
{
    public static string GetName(this CountryEnum country)
    {
        var field = country.GetType().GetField(country.ToString());
        var attribute = (CountryProperty)field.GetCustomAttributes(typeof(CountryProperty), false)[0];
        return attribute.Name;
    }

    public static CountryEnum? GetById(this string id)
    {
        foreach (CountryEnum c in Enum.GetValues(typeof(CountryEnum)))
        {
            var field = c.GetType().GetField(c.ToString());
            if (field.ToString() == id)
            {
                return c;
            }
        }
        return null;
    }

}

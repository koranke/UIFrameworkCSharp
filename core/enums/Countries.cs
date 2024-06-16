namespace UIFrameworkCSharp.core.enums;

public class Countries
{
    public static CountryEnum Get(string id)
    {
        foreach (CountryEnum c in Enum.GetValues(typeof(CountryEnum)))
        {
            var field = c.GetType().GetField(c.ToString());
            if (field.Name == id)
            {
                return c;
            }
        }
        throw new Exception("Country not found for id: " + id);
    }
}

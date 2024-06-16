namespace UIFrameworkCSharp.core.attributes;

public class CountryProperty : Attribute
{
    public string Name { get; set; }

    public CountryProperty(string name)
    {
        Name = name;
    }

}

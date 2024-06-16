namespace UIFrameworkCSharp.core.attributes;

public class StateProperty : Attribute
{
    public string Name { get; set; }
    public int Id { get; set; }

    public StateProperty(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

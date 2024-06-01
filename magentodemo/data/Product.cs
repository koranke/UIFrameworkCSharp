namespace UIFrameworkCSharp.magentodemo.data;

public class Product
{
    public string? Name { get; set; }
    public string? SelectedSize { get; set; }
    public string? SelectedColor { get; set; }
    public string? Price { get; set; }

    public List<string>? Colors { get; set; }
    public List<string>? Sizes { get; set; }
    public List<Tag>? Tags { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Size: {Sizes}, Color: {Colors}, Price: {Price}";
    }
}

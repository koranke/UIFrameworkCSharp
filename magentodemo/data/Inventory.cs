namespace UIFrameworkCSharp.magentodemo.data;

public class Inventory
{
    public List<Product> Products { get; set; }
    private List<string> defaultSizes = new List<string> { "XS", "S", "M", "L", "XL" };

    public Inventory()
    {
        Products = new List<Product>();

        Products.Add(new Product
        {
            Name = "Radiant Tee",
            Price = "$22.00",
            Colors = new List<string> { "Orange", "Blue", "Purple" },
            Sizes = defaultSizes,
        });


        Products.Add(new Product
        {
            Name = "Hero Hoodie",
            Price = "$54.00",
            Colors = new List<string> { "Green", "Gray", "Black" },
            Sizes = defaultSizes,
        });

        Products.Add(new Product
        {
            Name = "Breathe-Easy Tank",
            Price = "$34.00",
            Colors = new List<string> { "Purple", "White", "Yellow" },
            Sizes = defaultSizes,
            Tags = new List<Tag> 
            {
                new Tag { Key = "Material", Values = new List<string> { "Cotton", "Polyester" } },
                new Tag { Key = "Style", Values = new List<string> { "Tank" } },
                new Tag { Key = "Fit", Values = new List<string> { "Slim" } }
            }
        });




        Products.Add(new Product
        {
            Name = "Sonic Tank",
            Price = "$18.00",
            Colors = new List<string> { "Green", "Blue", "Red" },
            Sizes = defaultSizes,
            //Tags = new List<string> { "Tank", "Sonic" }
        });

        Products.Add(new Product
        {
            Name = "Sonic Tee",
            Price = "$22.00",
            Colors = defaultSizes,
            Sizes = defaultSizes,
            //Tags = new List<string> { "Tee", "Sonic" }
        });

        Products.Add(new Product
        {
            Name = "Sonic Hoodie",
            Price = "$45.00",
            Colors = new List<string> { "Green", "Blue", "Red" },
            Sizes = defaultSizes,
            //Tags = new List<string> { "Hoodie", "Sonic" }
        });
    }
}

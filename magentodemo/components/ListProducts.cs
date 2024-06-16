using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.magentodemo.data;

namespace UIFrameworkCSharp.magentodemo.components;

public class ListProducts : ListControl<ListProducts>
{
    private RepeatingControl<Label> labelName;
    private RepeatingControl<Label> labelPrice;
    private RepeatingControl<Label> labelOption;
    private RepeatingControl<Label> labelColor;
    private RepeatingControl<Button> buttonAddToCart;


    public ListProducts(Locator locator, string rowLocatorPattern) : base(locator)
    {
        this.hasHeader = false;
        this.RowLocatorPattern = rowLocatorPattern;

        this.labelName = new RepeatingControl<Label>(
            locator, 
            ".//a[@class='product-item-link']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelPrice = new RepeatingControl<Label>(
            locator,
            ".//span[@class='price']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.buttonAddToCart = new RepeatingControl<Button>(
            locator,
            ".//button[@title='Add to Cart']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader);

        this.labelOption = new RepeatingControl<Label>(
            locator,
            ".//div[@class='swatch-option text' and text()='{0}']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelColor = new RepeatingControl<Label>(
            locator,
            ".//div[@class='swatch-option color' and @option-label='{0}']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );
    }

    public ListProducts UsingLabelName()
    {
        this.searchLabel = labelName;
        return this;
    }

    public Label LabelItemName
    {
        get
        {
            return labelName.Get(currentRow);
        }
    }

    public Label LabelItemPrice
    {
        get
        {
            return labelPrice.Get(currentRow);
        }
    }

    public Label LabelOption(string option)
    {
            return labelOption.Get(currentRow, option);
    }

    public Label LabelColor(string color)
    {
            return labelColor.Get(currentRow, color);
    }

    public Button ButtonAddToCart
    {
        get
        {
            return buttonAddToCart.Get(currentRow);
        }
    }

    public List<string> GetAllSizes()
    {
        string sizesPattern = ".//div[@class='swatch-option text']";
        var sizes = getRowAsElement(currentRow).FindElements(By.XPath(sizesPattern));
        return sizes.Select(size => size.Text).ToList();
    }

    public List<string> GetAllColors()
    {
        string colorsPattern = ".//div[@class='swatch-option color']";
        var colors = getRowAsElement(currentRow).FindElements(By.XPath(colorsPattern));
        return colors.Select(color => color.GetAttribute("option-label")).ToList();
    }

    public void AddProductToCart(Product product, int? sizeIndex, int? colorIndex)
    {
        AddProductToCart(product.Name,
            sizeIndex != null ? product.Sizes[sizeIndex ?? 0] : null,
            colorIndex != null ? product.Colors[colorIndex ?? 0] : null);
    }

    public void AddProductToCart(string productName, string option, string color)
    {
        UsingLabelName().WithRow(productName).LabelItemName.ScrollToElement();
        LabelItemName.Hover();
        if (option != null) LabelOption(option).Click();
        if (color != null) LabelColor(color).Click();
        ButtonAddToCart.AssertIsVisible();
        ButtonAddToCart.Click();
    }

    public Product GetProduct(int row)
    {
        WithRow(row);

        Product product = new Product();
        product.Name = LabelItemName.GetText();
        product.Price = LabelItemPrice.GetText();
        product.Sizes = GetAllSizes();
        product.Colors = GetAllColors();
        return product;
    }

    public List<Product> GetAllVisibleProducts()
    {
        List<Product> products = new List<Product>();
        int rowCount = GetRowCount();
        for (int i = 1; i <= rowCount; i++)
        {
            products.Add(GetProduct(i));
        }
        return products;
    }
}

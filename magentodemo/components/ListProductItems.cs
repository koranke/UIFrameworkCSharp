using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.magentodemo.components;

public class ListProductItems : ListControl<ListProductItems>
{
    private RepeatingControl<Label> labelItemName;
    private RepeatingControl<Label> labelItemPrice;
    private RepeatingControl<Label> labelOption;
    private RepeatingControl<Label> labelColor;
    private RepeatingControl<Button> buttonAddToCart;


    public ListProductItems(Locator locator, string rowLocatorPattern) : base(locator)
    {
        this.hasHeader = false;
        this.RowLocatorPattern = rowLocatorPattern;

        this.labelItemName = new RepeatingControl<Label>(
            locator, 
            ".//a[@class='product-item-link']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelItemPrice = new RepeatingControl<Label>(
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

    public ListProductItems UsingLabelName()
    {
        this.searchLabel = labelItemName;
        return this;
    }

    public Label LabelItemName
    {
        get
        {
            return labelItemName.Get(currentRow);
        }
    }

    public Label LabelItemPrice
    {
        get
        {
            return labelItemPrice.Get(currentRow);
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
}

using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.magentodemo.components;

public class ListProductItems : ListControl<ListProductItems>
{
    public RepeatingControl<Label> labelItemName { get; }
    public RepeatingControl<Label> labelItemPrice { get; }
    public RepeatingControl<Label> labelOption { get; }
    public RepeatingControl<Label> labelColor { get; }
    public RepeatingControl<Button> buttonAddToCart { get; }


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
            ".//div[@class='swatch-attribute-options clearfix']/div[text()='{0}']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelColor = new RepeatingControl<Label>(
            locator,
            ".//div[@class='swatch-attribute color']//div[@option-label='{0}']",
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

    public Label LabelItemName()
    {
        return labelItemName.Get(currentRow);
    }

    public Label LabelItemPrice()
    {
        return labelItemPrice.Get(currentRow);
    }

    public Button ButtonAddToCart()
    {
        return buttonAddToCart.Get(currentRow);
    }

    public Label LabelOption(string option)
    {
        return labelOption.Get(currentRow, option);
    }

    public Label LabelColor(string color)
    {
        return labelColor.Get(currentRow, color);
    }
}

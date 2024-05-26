using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.core;

namespace UIFrameworkCSharp.saucedemo.pages.cartPage;

public class ListCartItems : ListControl<ListCartItems>
{
    private RepeatingControl<Label> labelQuantity;
    private RepeatingControl<Label> labelName;
    private RepeatingControl<Label> labelDescription;
    private RepeatingControl<Label> labelPrice;
    private RepeatingControl<Button> buttonRemove;

    public ListCartItems(Locator locator) : base(locator)
    {
        this.hasHeader = false;
        this.RowLocatorPattern = ".//div[@class='cart_item']";

        labelQuantity = new RepeatingControl<Label>(
            locator,
            ".//div[@class='cart_quantity']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
        );
        labelPrice = new RepeatingControl<Label>(
            locator,
            ".//div[@class='inventory_item_price']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
        );
        labelName = new RepeatingControl<Label>(
            locator,
            ".//div[@class='inventory_item_name']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
        );
        labelDescription = new RepeatingControl<Label>(
            locator,
            ".//div[@class='inventory_item_desc']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
        );
        buttonRemove = new RepeatingControl<Button>(
            locator,
            "Remove",
            LocatorMethod.TEXT,
            RowLocatorPattern,
            hasHeader
        );
    }

    public ListCartItems UsingLabelName()
    {
        this.searchLabel = labelName;
        return this;
    }

    public Label LabelQuantity()
    {
        return labelQuantity.Get(currentRow);
    }

    public Label LabelName()
    {
        return labelName.Get(currentRow);
    }

    public Label LabelDescription()
    {
        return labelDescription.Get(currentRow);
    }

    public Label LabelPrice()
    {
        return labelPrice.Get(currentRow);
    }

    public Button ButtonRemove()
    {
        return buttonRemove.Get(currentRow);
    }
}
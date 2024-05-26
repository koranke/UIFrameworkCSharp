using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo.domain;

namespace UIFrameworkCSharp.saucedemo.pages.productsPage;

public class ListProducts : ListControl<ListProducts>
{
    private RepeatingControl<Label> labelPrice;
    private RepeatingControl<Label> labelName;
    private RepeatingControl<Label> labelDescription;
    private RepeatingControl<Button> buttonAddToCart;
    private RepeatingControl<Button> buttonRemoveFromCart;

    public ListProducts(Locator locator) : base(locator)
    {
        this.hasHeader = false;
        this.RowLocatorPattern = ".//div[@class='inventory_item']";

        labelPrice = new RepeatingControl<Label>(
            locator,
            ".//div[@class='inventory_item_price']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
        );
        labelName = new RepeatingControl<Label>(
            locator,
            ".//div[@class='inventory_item_name ']",
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
        buttonAddToCart = new RepeatingControl<Button>(
            locator, "Add to cart",
            LocatorMethod.TEXT,
            RowLocatorPattern,
            hasHeader
        );
        buttonRemoveFromCart = new RepeatingControl<Button>(locator,
            "Remove",
            LocatorMethod.TEXT,
            RowLocatorPattern,
            hasHeader
        );
    }

    public ListProducts UsingLabelName()
    {
        this.searchLabel = labelName;
        return this;
    }

    public ListProducts UsingLabelPrice()
    {
        this.searchLabel = labelPrice;
        return this;
    }

    public Label LabelPrice()
    {
        return labelPrice.Get(currentRow);
    }

    public Label LabelName()
    {
        return labelName.Get(currentRow);
    }

    public Label LabelDescription()
    {
        return labelDescription.Get(currentRow);
    }

    public Button ButtonAddToCart()
    {
        return buttonAddToCart.Get(currentRow);
    }

    public Button ButtonRemoveFromCart()
    {
        return buttonRemoveFromCart.Get(currentRow);
    }

    public Product GetCurrentProduct()
    {
        Product product = new Product();
        product.Name = LabelName().GetText();
        product.Description = LabelDescription().GetText();
        product.Price = Double.Parse(LabelPrice().GetText().Replace("$", ""));
        return product;
    }
}
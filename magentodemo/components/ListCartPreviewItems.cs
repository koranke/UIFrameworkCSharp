using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.magentodemo.data;

namespace UIFrameworkCSharp.magentodemo.components;

public class ListCartPreviewItems : ListControl<ListCartPreviewItems>
{
    private RepeatingControl<Label> labelItemName;
    private RepeatingControl<Label> labelDetails;
    private RepeatingControl<Label> labelSize;
    private RepeatingControl<Label> labelColor;
    private RepeatingControl<Label> labelItemPrice;
    private RepeatingControl<TextBox> textBoxlItemQty;
    private RepeatingControl<Button> buttonRemove;
    private RepeatingControl<Button> buttonEdit;

    public ListCartPreviewItems(Locator locator, string rowLocatorPattern) : base(locator)
    {
        this.hasHeader = false;
        this.RowLocatorPattern = rowLocatorPattern;

        this.labelItemName = new RepeatingControl<Label>(
            locator,
            ".//strong[@class='product-item-name']/a",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelDetails = new RepeatingControl<Label>(
            locator,
            ".//span[text()='See Details']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelSize = new RepeatingControl<Label>(
            locator,
            ".//dt[text()='Size']/following-sibling::dd/span",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );

        this.labelColor = new RepeatingControl<Label>(
            locator,
            ".//dt[text()='Color']/following-sibling::dd/span",
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

        this.textBoxlItemQty = new RepeatingControl<TextBox>(
            locator,
            ".//input[@class='input-text qty']",
            LocatorMethod.XPATH,
            RowLocatorPattern,
            hasHeader
            );
    }

    public ListCartPreviewItems UsingLabelName()
    {
        this.searchLabel = labelItemName;
        return this;
    }

    public Label LabelItemName
    {
        get
        {
            return this.labelItemName.Get(currentRow);
        }
    }

    public Label LabelDetails
    {
        get
        {
            return this.labelDetails.Get(currentRow);
        }
    }

    public Label LabelSize
    {
        get
        {
            return this.labelSize.Get(currentRow);
        }
    }

    public Label LabelColor
    {
        get
        {
            return this.labelColor.Get(currentRow);
        }
    }

    public Label LabelItemPrice
    {
        get
        {
            return this.labelItemPrice.Get(currentRow);
        }
    }

    public TextBox TextBoxItemQty
    {
        get
        {
            return this.textBoxlItemQty.Get(currentRow);
        }
    }

    public Button ButtonRemove
    {
        get
        {
            return this.buttonRemove.Get(currentRow);
        }
    }

    public Button ButtonEdit
    {
        get
        {
            return this.buttonEdit.Get(currentRow);
        }
    }

    public void VerifyItem(Product product, int? sizeIndex, int? colorIndex)
    {
        UsingLabelName().WithRow(product.Name).LabelDetails.Click();
        if (sizeIndex != null)
        {
            LabelSize.AssertText(product.Sizes[sizeIndex??0]);
        }
        else
        {
            LabelSize.AssertIsNotVisible();
        }
        if (colorIndex != null)
        {
            LabelColor.AssertText(product.Colors[colorIndex??0]);
        }
        else
        {
            LabelColor.AssertIsNotVisible();
        }
        
        LabelItemPrice.AssertText(product.Price);
    }
}

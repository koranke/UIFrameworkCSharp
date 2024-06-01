using OpenQA.Selenium;
using System.Globalization;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.data;
using UIFrameworkCSharp.magentodemo.pages.homePage;

namespace UIFrameworkCSharp.magentodemo.components;

public class PanelCartPreview : PanelControl
{
    public Button ButtonClose { get; }
    public Label LabelCartCount { get; }
    public Label LabelSubTotal { get; }
    public Button ButtonViewCart { get; }
    public Button ButtonCheckout { get; }
    public ListCartPreviewItems ListCartPreviewItems { get; }

    public PanelCartPreview(IWebDriver driver)
    {
        this.WebDriver = driver;
        this.LabelCartCount = new Label(driver, By.XPath("//span[@class='count']"));
        this.ButtonClose = new Button(driver, By.XPath("//button[@title='Close']"));
        this.LabelSubTotal = new Label(driver, By.XPath("//span[@class='price']"));
        this.ButtonViewCart = new Button(driver, By.XPath("//span[text()='View and Edit Cart']"));
        this.ButtonCheckout = new Button(driver, By.XPath("//button[text()='Proceed to Checkout']"));
        this.ListCartPreviewItems = new ListCartPreviewItems(
            new Locator(driver, By.Id("mini-cart")), "//li[./div[@class='product']]"
            );
    }

    public void verifySubTotal(List<Product> products)
    {
        decimal subTotal = 0;
        foreach (var item in products)
        {
            decimal price;
            decimal.TryParse(item.Price, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out price);
            subTotal += price;
        }
        LabelSubTotal.AssertText(String.Format("{0:C}", subTotal));
    }
}

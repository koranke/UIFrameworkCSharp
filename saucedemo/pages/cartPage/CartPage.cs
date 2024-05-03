using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.core;

namespace UIFrameworkCSharp.saucedemo.pages.cartPage;

public class CartPage : BaseSauceDemoPage<CartPage>
{
    public Label LabelTitle { get; private set; }
    public Button ButtonContinueShopping { get; private set; }
    public ListCartItems ListCartItems { get; private set; }

    public CartPage(SauceDemoSite site) : base(site, "cart.html")
    {
        LabelTitle = new Label(site.WebDriver, By.ClassName("title"));
        ButtonContinueShopping = new Button(site.WebDriver, By.Id("continue-shopping"));
        ListCartItems = new ListCartItems(new Locator(site.WebDriver, By.ClassName("cart_list")));
    }
}
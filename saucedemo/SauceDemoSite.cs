using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo.pages.cartPage;
using UIFrameworkCSharp.saucedemo.pages.loginPage;
using UIFrameworkCSharp.saucedemo.pages.productsPage;

namespace UIFrameworkCSharp.saucedemo;

public class SauceDemoSite : Site<SauceDemoSite>
{
    private LoginPage loginPage;
    private ProductsPage productsPage;
    private CartPage cartPage;

    public SauceDemoSite() : base()
    {
        Initialize();
    }

    private void Initialize()
    {
        this.BaseUrl = SauceDemoConstants.BaseUrl;
    }

    public LoginPage LoginPage()
    {
        if (loginPage == null)
        {
            loginPage = new LoginPage(this);
        }
        return loginPage;
    }

    public ProductsPage ProductsPage()
    {
        if (productsPage == null)
        {
            productsPage = new ProductsPage(this);
        }
        return productsPage;
    }

    public CartPage CartPage()
    {
        if (cartPage == null)
        {
            cartPage = new CartPage(this);
        }
        return cartPage;
    }
}
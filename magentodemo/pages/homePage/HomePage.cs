using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.magentodemo.components;
using UIFrameworkCSharp.magentodemo.data;

namespace UIFrameworkCSharp.magentodemo.pages.homePage;

public class HomePage : BaseMagentoPage<HomePage>
{
    /*
     * Elements to handle:
     *  main menu
     *  search tool
     *  cart
     *  product focus panels
     *  hot sellers list
     */

    public PanelNavigation Navigation { get; }
    public ListProducts ListProducts { get; }

    public HomePage(MagentoSite site) : base(site, "")
    {
        this.Navigation = new PanelNavigation(site.WebDriver);
        this.ListProducts = new ListProducts(
            new Locator(site.WebDriver, By.XPath("//ol[@class='product-items widget-product-grid']"))
            , "//li[@class='product-item']");
    }

    internal void AddProductToCart(Product product, int sizeIndex, int colorIndex)
    {
        int cartCount = 0;
        try
        {
            cartCount = int.Parse(Navigation.LabelCartCount.GetText());
        }
        catch (Exception)
        {
            //do nothing
        }

        ListProducts.AddProductToCart(product, sizeIndex, colorIndex);
        string expectedCount = (cartCount + 1).ToString();
        WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
        wait.Until(condition =>
        {
            try
            {
                return Navigation.LabelCartCount.GetText().Equals(expectedCount);
            }
            catch (Exception)
            {
                return false;
            }
        });
    }
}

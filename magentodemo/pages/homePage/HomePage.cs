using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages.homePage;

public class HomePage : BaseMagentoPage<HomePage>
{
    /*
     * Elements to hangle:
     *  main menu
     *  search tool
     *  cart
     *  product focus panels
     *  hot sellers list
     */

    public NavigationPanel Navigation { get; }
    public ListProductItems ListProductItems { get; }

    public HomePage(MagentoSite site) : base(site, "")
    {
        this.Navigation = new NavigationPanel(site.WebDriver);
        this.ListProductItems = new ListProductItems(
            new Locator(site.WebDriver, By.XPath("//ol[@class='product-items widget-product-grid']"))
            , "//li[@class='product-item']");
    }
}

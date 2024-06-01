using OpenQA.Selenium;
using UIFrameworkCSharp.core;
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

    public PanelNavigation Navigation { get; }
    public ListProductItems ListProductItems { get; }

    public HomePage(MagentoSite site) : base(site, "")
    {
        this.Navigation = new PanelNavigation(site.WebDriver);
        this.ListProductItems = new ListProductItems(
            new Locator(site.WebDriver, By.XPath("//ol[@class='product-items widget-product-grid']"))
            , "//li[@class='product-item']");
    }
}

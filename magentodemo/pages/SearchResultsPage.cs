using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages;

public class SearchResultsPage : BaseMagentoPage<SearchResultsPage>
{
    public PanelNavigation Navigation { get; }
    public Label LabelResults { get; }
    public Label LabelNoResults { get; }
    public ListProducts ListProductItems { get; }

    public SearchResultsPage(MagentoSite site) : base(site, "catalogsearch/result/.*")
    {
        Navigation = new PanelNavigation(site.WebDriver);
        LabelResults = new Label(site.WebDriver, By.XPath("//h1[@class='page-title']/span"));
        LabelNoResults = new Label(site.WebDriver, By.XPath("//div[@class='message notice']"));
        ListProductItems = new ListProducts(
            new Locator(site.WebDriver, By.XPath("//ol[@class='products list items product-items']")),
            "//li[@class='item product product-item']");
    }
}

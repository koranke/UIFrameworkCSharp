using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages.searchResultsPage;

public class SearchResultsPage : BaseMagentoPage<SearchResultsPage>
{
    public NavigationPanel Navigation { get; }
    public Label LabelResults { get; }
    public Label LabelNoResults { get; }
    public ListProductItems ListProductItems { get; }

    public SearchResultsPage(MagentoSite site) : base(site, "catalogsearch/result")
    {
        this.Navigation = new NavigationPanel(site.WebDriver);
        this.LabelResults = new Label(site.WebDriver, By.XPath("//h1[@class='page-title']/span"));
        this.LabelNoResults = new Label(site.WebDriver, By.XPath("//div[@class='message notice']"));
        this.ListProductItems = new ListProductItems(
            new Locator(site.WebDriver, By.XPath("//ol[@class='products list items product-items']")),
            "//li[@class='item product product-item']");
    }
}

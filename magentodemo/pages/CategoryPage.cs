using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.components;

namespace UIFrameworkCSharp.magentodemo.pages;

public class CategoryPage : BaseMagentoPage<CategoryPage>
{
    public PanelNavigation Navigation { get; }
    public PanelFilters Filters { get; }
    public ComboBox ComboBoxSortBy { get; }
    public Button ButtonSortBy { get; }
    public ListProducts ListProducts { get; }
    public PaginationMain Pagination { get; }

    public CategoryPage(MagentoSite site, string department, string category) : base(site, $"{department}/{category}.html")
    {
        Navigation = new PanelNavigation(site.WebDriver);
        Filters = new PanelFilters(site.WebDriver);
        ComboBoxSortBy = new SelectComboBox(site.WebDriver, By.Id("sorter"));
        ButtonSortBy = new Button(site.WebDriver, By.XPath("//a[@data-role='direction-switcher']"));
        ListProducts = new ListProducts(
            new core.Locator(site.WebDriver, By.XPath("//ol[@class='products list items product-items']")),
            "//li[@class='item product product-item']"
        );
        Pagination = new PaginationMain(site.WebDriver);
    }
}

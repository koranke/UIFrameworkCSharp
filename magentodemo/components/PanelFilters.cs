using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;

namespace UIFrameworkCSharp.magentodemo.components;

public class PanelFilters : PanelControl
{
    public ExpansionControl GeneralFilters { get; }
    public ExpansionControl SizeColorFilters { get; }
    public Button ButtonClearAll { get; }
    public TaggedButton ButtonClearItem { get; }
    public TaggedLabel LabelFilterItem { get; }

    public PanelFilters(IWebDriver webDriver)
    {
        this.WebDriver = webDriver;
        ButtonClearAll = new Button(webDriver, By.XPath("//a[span[text()='Clear All']]"));
        ButtonClearItem = new TaggedButton(webDriver, "//ol[@class='items']//span[text()='{0}']/following-sibling::a");
        LabelFilterItem = new TaggedLabel(webDriver, "//ol[@class='items']//span[@class='filter-value' and text()='{0}']");

        GeneralFilters = new ExpansionControl(webDriver, "//div[text()='{0}']",
            ".//following-sibling::div[@data-role='content']/ol/li/a[normalize-space(text())='{0}']");
        SizeColorFilters = new ExpansionControl(webDriver, "//div[text()='{0}']",
            ".//following-sibling::div[@data-role='content']//a[@aria-label='{0}']/div");
    }
}

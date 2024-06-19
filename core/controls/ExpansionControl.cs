using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class ExpansionControl : BaseControl
{
    private string itemLocator;

    public ExpansionControl(IWebDriver webDriver, string expansionLocator, string itemLocator) : base(webDriver, expansionLocator)
    {
        this.itemLocator = itemLocator;
    }

    public ExpansionControl expand(string controlText)
    {
        GetLocator(controlText).Click();
        return this;
    }

    public ExpansionControl selectItem(string controlText, string itemText)
    {
        expand(controlText);
        GetLocator(controlText).WithNext(By.XPath(itemLocator.Replace("{0}", itemText))).Click();
        return this;
    }
}

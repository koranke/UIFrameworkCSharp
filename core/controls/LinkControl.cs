using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class LinkControl : BaseControl
{
    public LinkControl(Locator locator) : base(locator)
    {
    }

    public LinkControl(IWebDriver webDriver, By locator) : base(webDriver, locator)
    {
    }

    public string GetHref()
    {
        return locator.GetAttribute("href");
    }

    public LinkControl Click()
    {
        locator.Click();
        return this;
    }

    public string GetLabel()
    {
        return locator.GetText();
    }

    public void AssertHref(string expectedHref)
    {
        Assert.AreEqual(expectedHref, GetHref(), "Unexpected href.");
    }
}

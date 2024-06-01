using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class FlagControl : BaseControl
{
    public FlagControl(IWebDriver webDriver, By by) : base(webDriver, by)
    {
    }

    public FlagControl(Locator locator) : base(locator)
    {
    }

    public FlagControl Click()
    {
        locator.Click();
        return this;
    }

    public string GetLabel()
    {
        return locator.GetText().Trim();
    }

    public bool IsSelected()
    {
        return locator.IsChecked();
    }

    public FlagControl AssertIsSelected()
    {
        Assert.IsTrue(locator.IsChecked(), "Option not selected.");
        return this;
    }

    public FlagControl AssertIsNotSelected()
    {
        Assert.IsFalse(locator.IsChecked(), "Option is selected.");
        return this;
    }
}
using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class MenuOption : BaseControl
{
    public MenuOption(IWebDriver driver, By selector) : base(driver, selector)
    {
    }

    public MenuOption Click()
    {
        this.locator.Click();
        return this;
    }

    public MenuOption Hover()
    {
        this.locator.Hover();
        return this;
    }

    public string GetText()
    {
        return this.locator.GetText();
    }

    public void AssertIsVisible()
    {
        Assert.IsTrue(this.locator.IsVisible());
    }

    public void AssertNotIsVisible()
    {
        Assert.IsTrue(this.locator.IsNotVisible());
    }
}

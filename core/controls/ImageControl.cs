using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class ImageControl : BaseControl
{
    public ImageControl(IWebDriver driver, By selector) : base(driver, selector)
    {
    }

    public string GetSource()
    {
        return this.locator.GetAttribute("src");
    }

    public string GetAlt()
    {
        return this.locator.GetAttribute("alt");
    }

    public void AssertSourceContains(string expected)
    {
        Assert.IsTrue(this.GetSource().Contains(expected));
    }

    public void AssertAltContains(string expected)
    {
        Assert.IsTrue(this.GetAlt().Contains(expected));
    }

    internal void Click()
    {
        this.locator.Click();
    }
}

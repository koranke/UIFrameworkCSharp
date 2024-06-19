using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

/*
Use this for cases where there are multiple labels that are the same except for some text reference, and where the text
value possibilities are numerous.  Using this, you can just define the label once.
 */
public class TaggedLabel : BaseControl
{
    public TaggedLabel(IWebDriver webDriver, string xpath) : base(webDriver, xpath)
    {
    }

    public bool IsVisible(string item)
    {
        return GetLocator(item).IsVisible();
    }

    public void AssertIsVisible(string item)
    {
        Assert.IsTrue(IsVisible(item), "Unexpected visible state.");
    }

    public void AssertIsNotVisible(string item)
    {
        Assert.IsTrue(GetLocator(item).IsNotVisible(), "Unexpected visible state.");
    }
}

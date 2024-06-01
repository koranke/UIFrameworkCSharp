using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public abstract class BaseControl
{
    protected Locator locator;

    public BaseControl(IWebDriver webDriver, By by)
    {
        locator = new Locator(webDriver, by);
    }

    public BaseControl(Locator locator)
    {
        this.locator = locator;
    }

    public bool IsEnabled()
    {
        return locator.IsEnabled();
    }

    public void AssertIsEnabled()
    {
        Assert.IsTrue(IsEnabled(), "Unexpected enabled state.");
    }

    public void AssertIsNotEnabled()
    {
        Assert.IsTrue(!IsEnabled(), "Unexpected enabled state.");
    }

    public bool IsVisible(int timeoutInSeconds)
    {
        return locator.IsVisible(timeoutInSeconds);
    }

    public bool IsNotVisible()
    {
        return locator.IsNotVisible();
    }

    public void AssertIsVisible()
    {
        AssertIsVisible(0);
    }

    public void AssertIsVisible(int timeoutInSeconds)
    {
        Assert.IsTrue(IsVisible(timeoutInSeconds), "Control is not visible.");
    }

    public void AssertIsNotVisible()
    {
        Assert.IsTrue(IsNotVisible(), "Control is visible.");
    }

    public void Hover()
    {
        this.locator.Hover();
    }

    public void ScrollToElement()
    {
        this.locator.ScrollToElement();
    }


    public void AssertText(string text)
    {
        if (!GetActualText(locator).Equals(text))
        {
            Thread.Sleep(1000);
        }
        Assert.AreEqual(text, GetActualText(locator));
    }

    public void AssertTextContains(string text)
    {
        if (!GetActualText(locator).Contains(text))
        {
            Thread.Sleep(1000);
        }
        Assert.IsTrue(GetActualText(locator).Contains(text));
    }

    private string GetActualText(Locator locator)
    {
        string actualText;
        if (GetType().IsAssignableFrom(typeof(TextBox)))
        {
            actualText = locator.GetAttribute("value");
        }
        else if (GetType().IsAssignableFrom(typeof(Button)))
        {
            actualText = ((Button)this).GetLabel();
        }
        else
        {
            actualText = locator.GetText();
        }
        return actualText == null ? "" : actualText;
    }

    public void Wait(int timeToWait)
    {
        Thread.Sleep(timeToWait);
    }

    public string GetAttribute(string attributeName)
    {
        return locator.GetAttribute(attributeName);
    }
}
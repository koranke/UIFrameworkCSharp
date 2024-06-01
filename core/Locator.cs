using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using UIFrameworkCSharp.core.extensions;

namespace UIFrameworkCSharp.core;

public class Locator
{
    private IWebDriver webDriver;
    private IWebElement parentElement;

    public By By { get; private set; }
    private int? index;
    private Locator next;

    public Locator WithIndex(int index)
    {
        this.index = index - 1;
        return this;
    }

    public Locator WithNext(By by)
    {
        this.next = new Locator(webDriver, by);
        return this;
    }

    public Locator WithNext(By by, int index)
    {
        this.next = new Locator(webDriver, by);
        this.next.WithIndex(index);
        return this;
    }

    public Locator WithParentElement(IWebElement parentElement)
    {
        this.parentElement = parentElement;
        return this;
    }

    public Locator(IWebDriver driver, By by)
    {
        this.webDriver = driver;
        this.By = by;
    }

    public Locator GetWithNextLocator(By by)
    {
        IWebElement parentElement;
        if (index == null)
        {
            parentElement = webDriver.FindElement(this.By);
        }
        else
        {
            parentElement = webDriver.FindElements(this.By)[index.Value];
        }
        Locator locator = new Locator(webDriver, by).WithParentElement(parentElement);
        return locator;
    }

    public IWebElement GetElement()
    {
        if (parentElement != null) return GetElement(parentElement);

        IWebElement webElement;
        if (index == null)
        {
            webElement = webDriver.FindElement(By);
        }
        else
        {
            webElement = webDriver.FindElements(By)[index.Value];
        }

        if (next != null)
        {
            return next.GetElement(webElement);
        }
        else
        {
            return webElement;
        }
    }

    public IWebElement GetElement(IWebElement parentWebElement)
    {
        IWebElement webElement;
        if (index == null)
        {
            webElement = parentWebElement.FindElement(By);
        }
        else
        {
            webElement = parentWebElement.FindElements(By)[index.Value];
        }
        if (next != null)
        {
            return next.GetElement(webElement);
        }
        else
        {
            return webElement;
        }
    }

    public IList<IWebElement> All()
    {
        if (parentElement != null)
        {
            return parentElement.FindElements(By);
        }
        return webDriver.FindElements(By);
    }

    public IWebElement Nth(int index)
    {
        WithIndex(index);
        return GetElement();
    }

    public void Click()
    {
        GetElement().Click();
    }

    public bool IsEnabled()
    {
        return GetElement().Enabled;
    }

    public bool IsVisible()
    {
        return IsVisible(0);
    }

    public bool IsVisible(int maxWaitTimeInSeconds)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));
            return wait.Until(condition => webDriver.FindElement(By).Displayed == true);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public bool IsNotVisible()
    {
        return IsNotVisible(0);
    }

    public bool IsNotVisible(int maxWaitTimeInSeconds)
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

            //not sure if this is actually what we want.  need to review use case.
            return wait.Until(condition => webDriver.FindElements(By).Count == 0);
        }
        catch (WebDriverTimeoutException)
        {
            return true;
        }
    }

    public bool IsChecked()
    {
        return GetElement().Selected;
    }

    public string GetText()
    {
        return GetElement().Text.Trim();
    }

    public void SetText(string text)
    {
        GetElement().SendKeys(text);
    }

    public string GetAttribute(string attributeName)
    {
        return GetElement().GetAttribute(attributeName);
    }

    public Locator Clone()
    {
        return new Locator(webDriver, By);
    }

    public void Hover()
    {
        Actions actions = new Actions(webDriver);
        actions.MoveToElement(GetElement()).Perform();
    }

    public void ScrollToElement()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement());
    }
}
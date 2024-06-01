using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIFrameworkCSharp.core;

/*
 * Demo class.  Can be deleted.
 */
class BrowserOps
{
    IWebDriver webDriver;

    public void InitBrowser()
    {
        webDriver = new ChromeDriver();
        webDriver.Manage().Window.Maximize();
    }

    public string Title
    {
        get { return webDriver.Title; }
    }

    public void GoTo(string url)
    {
        webDriver.Navigate().GoToUrl(url);
    }

    public void GoBack()
    {
        webDriver.Navigate().Back();
    }

    public void Close()
    {
        webDriver.Quit();
    }

    public IWebDriver GetDriver()
    {
        return webDriver;
    }

}

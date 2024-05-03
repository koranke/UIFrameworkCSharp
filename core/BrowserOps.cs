using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCSharp.core;

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

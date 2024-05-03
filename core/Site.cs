using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UIFrameworkCSharp.core.enums;

namespace UIFrameworkCSharp.core;

public abstract class Site<T>
{
    public string BaseUrl { get; set; }
    public IWebDriver WebDriver { get; set; }

    private bool _isSignedIn;
    public bool IsSignedIn
    {
        get { return _isSignedIn; }
        set { _isSignedIn = value; }
    }

    private string _sessionStorage;
    public string SessionStorage
    {
        get { return _sessionStorage; }
        set { _sessionStorage = value; }
    }

    public Site()
    {
        this.WebDriver = SeleniumManager.GetNewDriver();
    }

    public Site(TargetBrowser targetBrowser)
    {
        this.WebDriver = SeleniumManager.GetNewDriver(targetBrowser);
    }

    public IWebDriver GetNewDriver(TargetBrowser targetBrowser)
    {
        this.WebDriver = SeleniumManager.GetNewDriver(targetBrowser);
        return WebDriver;
    }
}
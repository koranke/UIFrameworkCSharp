using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UIFrameworkCSharp.core;

namespace UIFrameworkCSharp.saucedemo.pages;

public abstract class BaseSauceDemoPage<T> : BasePage<T>
{
    protected SauceDemoSite Site { get; set; }
    private string Path;

    public BaseSauceDemoPage(SauceDemoSite site, string path) : base(site.WebDriver, site.BaseUrl, path)
    {
        this.Site = site;
    }

    public T Open()
    {
        LoginIfNeeded();
        return GoTo();
    }

    protected void LoginIfNeeded()
    {
        if (!Site.IsSignedIn)
        {
            Site.LoginPage().SignIn();
        }
    }
}
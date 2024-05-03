using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class Label : BaseControl, TextControl
{
    public Label(IWebDriver webDriver, By locator) : base(webDriver, locator)
    {
    }

    public Label(Locator locator) : base(locator)
    {
    }

    public void Click()
    {
        locator.Click();
    }

    public string GetText()
    {
        return locator.GetText().Trim();
    }
}
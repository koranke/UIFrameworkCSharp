using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class TextBox : BaseControl
{
    public TextBox(IWebDriver webDriver, By locator) : base(webDriver, locator)
    {
    }

    public TextBox SetText(string text)
    {
        locator.SetText(text);
        return this;
    }

    public string GetText()
    {
        return locator.GetAttribute("value");
    }
}
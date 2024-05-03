using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using System.Threading;

namespace UIFrameworkCSharp.core.controls;

public class Button : BaseControl
{
    private int clickDelay = 0;

    public Button(IWebDriver webDriver, By locator) : base(webDriver, locator)
    {
    }

    public Button(Locator locator) : base(locator)
    {
    }

    public Button SetClickDelay(int delay)
    {
        this.clickDelay = delay;
        return this;
    }

    public Button Click()
    {
        if (clickDelay > 0)
        {
            Thread.Sleep(clickDelay);
        }
        locator.Click();
        return this;
    }

    public string GetLabel()
    {
        string label = locator.GetAttribute("value");
        if (label == null)
        {
            label = locator.GetText();
        }
        return label;
    }
}
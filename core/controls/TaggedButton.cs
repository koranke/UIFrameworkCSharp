using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

/*
Use this for cases where there are multiple buttons that are the same except for some text reference.  Using this,
you can just define the button once.
 */
public class TaggedButton : BaseControl
{
    public int ClickDelay { get; set; } = 0;

    public TaggedButton(IWebDriver webDriver, string xpath) : base(webDriver, xpath)
    {
    }

    /*
    Some buttons may require a delay before they become responsive to a click event.  Adjust this if needed for
    individual controls.
     */
    public TaggedButton click(string item)
    {
        if (ClickDelay > 0) {
            Thread.Sleep(ClickDelay);
        }
        GetLocator(item).Click();
        return this;
    }
}

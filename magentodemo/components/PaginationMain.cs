using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;

namespace UIFrameworkCSharp.magentodemo.components;

public class PaginationMain : PaginationControl
{
    public PaginationMain(IWebDriver webDriver) : base(new Locator(webDriver, By.XPath("//div[@class='products wrapper grid products-grid']/following-sibling::div")))
    {
        this.PageLocatorPattern = ".//li[@class='item']/a[span[text()='%d']]";
        this.ButtonPrior = new Button(new Locator(webDriver, By.XPath(".//a[@title='Previous']")).WithParent(this.locator));
        this.ButtonPrior = new Button(new Locator(webDriver, By.XPath(".//a[@title='Next']")).WithParent(this.locator));
    }

}

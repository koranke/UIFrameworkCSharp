using OpenQA.Selenium;

namespace UIFrameworkCSharp.core.controls;

public class PaginationControl : BaseControl
{
    public string PageLocatorPattern { get; set; } = ".//a";
    public Button ButtonFirst { get; set; }
    public Button ButtonPrior { get; set; }
    public Button ButtonNext { get; set; }
    public Button ButtonLast { get; set; }

    public PaginationControl(Locator locator) : base(locator)
    {
    }

    public void ClickPage(int pageNumber)
    {
        try
        {
            IWebElement element = locator.GetWithNextLocator(By.XPath(String.Format(PageLocatorPattern, pageNumber))).GetElement();
            element.Click();
        }
        catch (Exception)
        {
            throw new Exception("Page number " + pageNumber + " not found");
        }
    }
}
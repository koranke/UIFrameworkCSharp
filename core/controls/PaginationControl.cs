using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
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
        if (GetPages().Contains(pageNumber))
        {
            locator.WithNext(ExtendedBy.Text(pageNumber.ToString())).Click();
        }
        else
        {
            throw new Exception("Page number " + pageNumber + " not found");
        }
    }

    public List<int> GetPages()
    {
        List<int> pages = new List<int>();
        foreach (IWebElement element in locator.GetWithNextLocator(By.XPath(PageLocatorPattern)).All())
        {
            string text = element.Text;
            if (int.TryParse(text, out int page))
            {
                pages.Add(page);
            }
        }
        return pages;
    }
}
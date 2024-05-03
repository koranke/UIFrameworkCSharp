using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;

namespace UIFrameworkCSharp.core;

public abstract class BasePage<T>
{
//    protected Props props = ConfigCache.GetOrCreate<Props>();
//    protected Log log = Log.GetInstance();

    protected readonly IWebDriver webDriver;
    protected string path;
    protected string url;
    protected int maxDiffPixel;

    public BasePage(IWebDriver webDriver, string baseUrl, string path)
    {
        this.webDriver = webDriver;
        this.path = path;
        this.url = string.Format("{0}{1}", baseUrl, path);
        this.maxDiffPixel = 0; //props.MaxDiffPixels;
    }

    public T GoTo()
    {
        webDriver.Navigate().GoToUrl(url);
        return (T)Convert.ChangeType(this, typeof(T));
    }

    public string GetPageUrl()
    {
        return webDriver.Url;
    }

    public bool IsOpen()
    {
        WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
        return wait.Until(condition => webDriver.Url == url);
    }

    public void AssertIsOpen()
    {
        Assert.IsTrue(IsOpen());
    }

    public void Wait(int timeToWait)
    {
        try
        {
            Thread.Sleep(timeToWait);
        }
        catch (Exception)
        {
            //do nothing
        }
    }

    protected List<Locator> GetMask()
    {
        return null;
    }


    //private void TakeAndSaveShot(string imagePath)
    //{
    //    AShot shotTaker = new AShot();
    //    if (GetMask() != null)
    //    {
    //        foreach (Locator locator in GetMask())
    //        {
    //            shotTaker.AddIgnoredElement(locator.By);
    //        }
    //    }
    //    Screenshot screenshot = shotTaker.TakeScreenshot(webDriver);
    //    try
    //    {
    //        screenshot.SaveAsFile(imagePath, ScreenshotImageFormat.Png);
    //    }
    //    catch (Exception e)
    //    {
    //        log.LogAssert(false, "Failed to save image as file.\n" + e.Message);
    //    }
    //}

    private string GetImageNameFromClass()
    {
        return this.GetType().Name + ".png";
    }

    private string GetImageDiffNameFromClass()
    {
        return this.GetType().Name + "Diff.png";
    }

    // ... Rest of the methods
}
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UIFrameworkCSharp.core;

public abstract class BasePage<T>
{
    //    protected Props props = ConfigCache.GetOrCreate<Props>();
    protected static Logger log;

    public IWebDriver WebDriver { get; }
    protected string path;
    protected string url;
    protected int maxDiffPixel;

    public BasePage(IWebDriver webDriver, string baseUrl, string path)
    {
        log = LogManager.GetLogger(GetType().Name); 
        this.WebDriver = webDriver;
        this.path = path;
        this.url = string.Format("{0}{1}", baseUrl, path);
        this.maxDiffPixel = 0; //props.MaxDiffPixels;
    }

    public T GoTo()
    {
        log.Info($"Opening {this.url}");
        WebDriver.Navigate().GoToUrl(url);
        return (T)Convert.ChangeType(this, typeof(T));
    }

    public string GetPageUrl()
    {
        return WebDriver.Url;
    }

    public bool IsOpen()
    {
        WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        try
        {
            if (url.EndsWith(".*"))
            {
                return wait.Until(condition => WebDriver.Url.Contains(url.Replace(".*", "")));
            }
            else
            {
                return wait.Until(condition => WebDriver.Url == url);
            }
        }
        catch (OpenQA.Selenium.WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void AssertIsOpen()
    {
        Assert.IsTrue(IsOpen(), $"Failed to open {this.url}.");
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
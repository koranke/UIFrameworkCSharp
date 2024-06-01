using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.core.extensions;

namespace UIFrameworkCSharp.core;

public class SeleniumManager
{
    //    private static readonly Props props = ConfigCache.GetOrCreate<Props>();
    protected static Logger log = LogManager.GetCurrentClassLogger();
    private static readonly Dictionary<long, IWebDriver> driverMap = new Dictionary<long, IWebDriver>();

    public static int SlowTime { get; set; } = 0; //props.SlowTime;

    public static IWebDriver GetNewDriver()
    {
        return GetNewDriver(null);
    }

    public static IWebDriver GetNewDriver(TargetBrowser? targetBrowser)
    {
        long threadId = Thread.CurrentThread.ManagedThreadId;

        if (driverMap.ContainsKey(threadId))
        {
            driverMap[threadId].Quit();
        }
        log.Debug($"Getting new driver for thread: {Thread.CurrentThread.ManagedThreadId}");
        driverMap[threadId] = GetConfiguredDriver(targetBrowser);
        return driverMap[threadId];
    }

    public static IWebDriver GetCurrentDriver()
    {
        long threadId = Thread.CurrentThread.ManagedThreadId;
        return driverMap.GetValueOrDefault(threadId, null);
    }

    public static void CloseCurrentDriver()
    {
        long threadId = Thread.CurrentThread.ManagedThreadId;

        if (driverMap.ContainsKey(threadId))
        {
            log.Debug($"Closing current driver for thread: {Thread.CurrentThread.ManagedThreadId}");
            driverMap[threadId].Quit();
            driverMap.Remove(threadId);
        }
        else
        {
            log.Debug($"No driver to close for thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    private static IWebDriver GetConfiguredDriver(TargetBrowser? targetBrowser)
    {
        if (targetBrowser == null)
        {
            targetBrowser = TargetBrowser.EDGE; //props.TargetBrowser;
        }

        bool headless = false; //props.Headless;
        int implicitWait = 0; //props.ImplicitWait;

        IWebDriver webDriver;
        switch (targetBrowser)
        {
            case TargetBrowser.CHROMIUM:
            case TargetBrowser.CHROME:
                ChromeOptions chromeOptions = new ChromeOptions();

                if (headless)
                {
                    chromeOptions.AddArguments("--headless=new");
                }
                webDriver = new ChromeDriver(chromeOptions);
                break;
            case TargetBrowser.EDGE:
                EdgeOptions edgeOptions = new EdgeOptions();
                if (headless)
                {
                    edgeOptions.AddArguments("--headless=new");
                }
                webDriver = new EdgeDriver(edgeOptions);
                break;
            case TargetBrowser.WEBKIT:
                webDriver = new SafariDriver();
                break;
            case TargetBrowser.FIREFOX:
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                if (headless)
                {
                    firefoxOptions.AddArguments("-headless");
                }
                webDriver = new FirefoxDriver(firefoxOptions);
                break;
            default:
                log.LogAssert(false, $"Unsupported Browser: {targetBrowser.Value}");
                return null;
        }
        webDriver.Manage().Window.Maximize();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(implicitWait);
        return webDriver;
    }
}
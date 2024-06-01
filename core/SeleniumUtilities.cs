using OpenQA.Selenium;

namespace UIFrameworkCSharp.core;

public class SeleniumUtilities
{
    public static void TakeScreenshot()
    {
        TakeScreenshot(ProjectUtilities.GetTestName());
    }

    public static void TakeScreenshot(TestContext testContext)
    {
        string className = testContext.FullyQualifiedTestClassName.Substring(testContext.FullyQualifiedTestClassName.LastIndexOf('.') + 1);
        string testName = $"{className}.{testContext.TestName}";
        TakeScreenshot(testName);
    }

    public static void TakeScreenshot(string testName)
    {
        string screenshotPath = ProjectUtilities.GetScreenshotDirectory();

        IWebDriver driver = core.SeleniumManager.GetCurrentDriver();
        if (driver != null)
        {
            string fileName = string.Format("{0}.{1}.png",
                testName,
                DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            Console.WriteLine($"Screenshot saved to {fileName}");
            screenshot.SaveAsFile($"{screenshotPath}\\{fileName}");
        }
    }


}

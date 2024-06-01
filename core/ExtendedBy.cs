using OpenQA.Selenium;

namespace UIFrameworkCSharp.core;

public class ExtendedBy
{
    public static By TestId(string testId)
    {
        return By.XPath($"//*[@data-testid='{testId}']");
    }

    public static By RelativeTestId(string testId)
    {
        return By.XPath($".//descendant-or-self::*[@data-testid='{testId}']");
    }

    public static By Text(string text)
    {
        return By.XPath($"//*[text()='{text}']");
    }
}
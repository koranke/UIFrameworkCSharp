using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UIFrameworkCSharp.core.controls;

public class SelectComboBox : BaseControl, ComboBox
{
    public SelectComboBox(IWebDriver webDriver, By by) : base(webDriver, by)
    {
    }

    public SelectComboBox(Locator locator) : base(locator)
    {
    }

    public void SetValue(string value)
    {
        GetAsSelect().SelectByValue(value);
    }

    public void SetText(string option)
    {
        GetAsSelect().SelectByText(option);
    }

    public void SetText(int textIndex)
    {
        GetAsSelect().SelectByIndex(textIndex);
    }

    public string GetText()
    {
        return GetAsSelect().SelectedOption.Text;
    }

    public string GetValue()
    {
        return locator.GetAttribute("value");
    }

    public List<string> GetOptions()
    {
        return GetAsSelect().Options.Select(option => option.Text).ToList();
    }

    public void AssertText(string expectedText)
    {
        Assert.AreEqual(expectedText, GetText());
    }

    public void AssertValue(string expectedValue)
    {
        Assert.AreEqual(expectedValue, GetValue());
    }

    public void AssertOptions(List<string> expectedOptions)
    {
        CollectionAssert.AreEquivalent(expectedOptions, GetOptions());
    }

    public bool OptionExists(string targetText)
    {
        return GetOptions().Contains(targetText);
    }

    private SelectElement GetAsSelect()
    {
        return new SelectElement(locator.GetElement());
    }
}
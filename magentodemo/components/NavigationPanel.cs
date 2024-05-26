using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;

namespace UIFrameworkCSharp.magentodemo.components;

public class NavigationPanel : PanelControl
{
    private string menuSelector = "//nav//span[text()=\"{0}\"]";
    public MenuOption WhatsNew { get; }
    public MenuOption Women { get; }

    public ImageControl Logo { get; }
    public TextBox SearchBox { get; }
    public Button SearchButton { get; }


    public NavigationPanel(IWebDriver driver)
    {
        this.WebDriver = driver;
        this.Logo = new ImageControl(driver, By.XPath("//a[@class=\"logo\"]/img"));
        this.SearchBox = new TextBox(driver, By.XPath("//input[@id=\"search\"]"));
        this.SearchButton = new Button(driver, By.XPath("//button[@class=\"action search\"]"));
        WhatsNew = new MenuOption(driver, GetMenuSelector("What's New"));
        Women = new MenuOption(driver, GetMenuSelector("Women"));
    }

    private By GetMenuSelector(string menuName)
    {
        return By.XPath(string.Format(menuSelector, menuName));
    }
}

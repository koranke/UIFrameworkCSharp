using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;

namespace UIFrameworkCSharp.magentodemo.components;

public class PanelNavigation : PanelControl
{
    private string menuSelector = "//nav//span[text()=\"{0}\"]";
    public MenuOption WhatsNew { get; }
    public MenuOption Women { get; }

    public ImageControl Logo { get; }
    public TextBox TextBoxSearch { get; }
    public Button ButtonSearch { get; }
    public Button ButtonCart { get; }
    public Label LabelCartCount { get; }
    public PanelCartPreview PanelCartPreview { get; }


    public PanelNavigation(IWebDriver driver)
    {
        this.WebDriver = driver;
        this.Logo = new ImageControl(driver, By.XPath("//a[@class=\"logo\"]/img"));
        this.TextBoxSearch = new TextBox(driver, By.XPath("//input[@id=\"search\"]"));
        this.ButtonSearch = new Button(driver, By.XPath("//button[@class=\"action search\"]"));
        this.ButtonCart = new Button(driver, By.XPath("//a[@class=\"action showcart\"]"));
        this.LabelCartCount = new Label(driver, By.XPath("//span[@class=\"counter-number\"]"));
        this.PanelCartPreview = new PanelCartPreview(driver);
        WhatsNew = new MenuOption(driver, GetMenuSelector("What's New"));
        Women = new MenuOption(driver, GetMenuSelector("Women"));
    }

    private By GetMenuSelector(string menuName)
    {
        return By.XPath(string.Format(menuSelector, menuName));
    }
}

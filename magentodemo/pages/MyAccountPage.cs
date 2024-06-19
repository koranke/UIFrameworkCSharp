using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.magentodemo.pages;

public class MyAccountPage : BaseMagentoPage<MyAccountPage>
{
    public Label LabelContactInfo { get; }
    public Button ButtonEditContactInfo { get; }
    public Button ButtonChangePassword { get; }
    public Label LabelBillingAddress { get; }
    public Button ButtonEditBillingAddress { get; }
    public Label LabelShippingAddress { get; }
    public Button ButtonEditShippingAddress { get; }

    public MyAccountPage(MagentoSite site) : base(site, "customer/account/")
    {
        LabelContactInfo = new Label(site.WebDriver, By.XPath("//strong[./span[text()='Contact Information']]/following-sibling::div[@class='box-content']/p"));
        ButtonEditContactInfo = new Button(site.WebDriver, By.XPath("//strong[./span[text()='Contact Information']]/following-sibling::div[@class='box-actions']/a[1]"));
        ButtonChangePassword = new Button(site.WebDriver, By.XPath("//strong[./span[text()='Contact Information']]/following-sibling::div[@class='box-actions']/a[2]"));
        LabelBillingAddress = new Label(site.WebDriver, By.XPath("//strong[./span[text()='Default Billing Address']]/following-sibling::div/address"));
        ButtonEditBillingAddress = new Button(site.WebDriver, By.XPath("//strong[./span[text()='Default Billing Address']]/following-sibling::div/a"));
        LabelShippingAddress = new Label(site.WebDriver, By.XPath("//strong[./span[text()='Default Shipping Address']]/following-sibling::div/address"));
        ButtonEditShippingAddress = new Button(site.WebDriver, By.XPath("//strong[./span[text()='Default Billing Address']]/following-sibling::div/a"));
    }

    public MyAccountPage Open(AuthBody authBody)
    {
        if (!Site.IsSignedIn)
        { 
            Site.LoginPage.Login(authBody, this);
        }
        else
        {
            this.Open();
        }
        return this;
    }
}

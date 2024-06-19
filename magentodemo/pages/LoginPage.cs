using OpenQA.Selenium;
using UIFrameworkCSharp.core.controls;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.magentodemo.pages;

public class LoginPage : BaseMagentoPage<LoginPage>
{
    public TextBox TextBoxEmail { get; }
    public TextBox TextBoxPassword { get; }
    public Button ButtonLogin { get; }
    public LinkControl LinkForgotPassword { get; }
    public Button ButtonCreateAccount { get; }

    public LoginPage(MagentoSite site) : base(site, "customer/account/login/")
    {
        TextBoxEmail = new TextBox(site.WebDriver, By.Id("email"));
        TextBoxPassword = new TextBox(site.WebDriver, By.Id("pass"));
        ButtonLogin = new Button(site.WebDriver, By.Id("send2"));
        LinkForgotPassword = new LinkControl(site.WebDriver, By.LinkText("Forgot your Password?"));
        ButtonCreateAccount = new Button(site.WebDriver, By.LinkText("Create an Account"));
    }

    public LoginPage Login<T>(AuthBody authBody, BaseMagentoPage<T> pageAfterLogin)
    {
        this.Open();
        TextBoxEmail.SetText(authBody.Username);
        TextBoxPassword.SetText(authBody.Password);
        ButtonLogin.Click();
        pageAfterLogin.AssertIsOpen();
        return this;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.core.controls;

namespace UIFrameworkCSharp.saucedemo.pages.loginPage;

public class LoginPage : BaseSauceDemoPage<LoginPage>
{
    public TextBox TextBoxUserName { get; }
    public TextBox TextBoxPassword { get; }
    public Label LabelError { get; }
    public Button ButtonLogin { get; }

    public LoginPage(SauceDemoSite site) : base(site, "")
    {
        TextBoxUserName = new TextBox(site.WebDriver, By.Id("user-name"));
        TextBoxPassword = new TextBox(site.WebDriver, By.Id("password"));
        LabelError = new Label(site.WebDriver, By.CssSelector("[data-test='error']"));
        ButtonLogin = new Button(site.WebDriver, By.Id("login-button"));
    }

    public LoginPage SignIn(string userName, string password)
    {
        GoTo();
        this.TextBoxUserName.SetText(userName);
        this.TextBoxPassword.SetText(password);
        this.ButtonLogin.Click();

        Site.IsSignedIn = true;
        return this;
    }

    public LoginPage SignIn()
    {
        return SignIn("standard_user", "secret_sauce");
    }
}
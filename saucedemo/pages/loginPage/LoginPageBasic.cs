using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCSharp.saucedemo.pages.loginPage;

public class LoginPageBasic
{
    IWebDriver driver;
    private By username = By.Id("user-name");
    private By password = By.Id("password");
    private By loginButton = By.Id("login-button");
    private By passwordLabel = By.XPath("//div[@class='login_password']");
    private By usernameLabel = By.Id("login_credentials");

    public LoginPageBasic(IWebDriver driver)
    {
        this.driver = driver;
    }

    public IWebElement Username
    {
        get { return driver.FindElement(username); }
    }

    public IWebElement Password
    {
        get { return driver.FindElement(password); }
    }

    public IWebElement LoginButton
    {
        get { return driver.FindElement(loginButton); }
    }

    public IWebElement PasswordLabel
    {
        get { return driver.FindElement(passwordLabel); }
    }

    public string GetPasswordLabelText()
    {
        return PasswordLabel.Text.Split(Environment.NewLine)[1];
    }

    public IWebElement UsernameLabel
    {
        get { return driver.FindElement(usernameLabel); }
    }

    public List<string> GetUsernameLabelText()
    {
        return UsernameLabel.Text.Split(Environment.NewLine).Skip(1).ToList();
    }
}

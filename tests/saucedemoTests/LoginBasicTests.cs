using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo.pages.loginPage;

namespace UIFrameworkCSharp.tests.saucedemoTests;

[TestClass]
public class LoginBasicTests
{
    BrowserOps browserOps = new BrowserOps();
    string testUrl = "https://www.saucedemo.com";
    IWebDriver driver;
    LoginPageBasic loginPage;

    [TestInitialize]
    public void SetUp()
    {
        browserOps.InitBrowser();
        driver = browserOps.GetDriver();
        loginPage = new LoginPageBasic(driver);
    }

    [TestMethod]
    public void TestPublishedUsersAndPassword()
    {
        browserOps.GoTo(testUrl);

        string passwordLabel = loginPage.GetPasswordLabelText();
        Assert.AreEqual("secret_sauce", passwordLabel);

        List<string> usernameLabel = loginPage.GetUsernameLabelText();
        Assert.IsTrue(usernameLabel.Contains("standard_user"));
        Assert.AreEqual(6, usernameLabel.Count);
        CollectionAssert.AreEquivalent(
            new List<string> { "standard_user", "locked_out_user", "problem_user", "performance_glitch_user", "error_user", "visual_user" },
            usernameLabel
            );

        browserOps.Close();
    }

    [TestMethod]
    public void TestValidLoginUsingSelenium()
    {
        browserOps.GoTo(testUrl);
        Assert.AreEqual("Swag Labs", browserOps.Title);

        IWebElement username = driver.FindElement(By.Id("user-name"));
        username.SendKeys("standard_user");
        IWebElement password = driver.FindElement(By.Id("password"));
        password.SendKeys("secret_sauce");
        IWebElement loginButton = driver.FindElement(By.Id("login-button"));
        loginButton.Click();

        Thread.Sleep(2000);
        browserOps.Close();
    }

    [TestMethod]
    public void TestValidLoginUsingBasicPageObject()
    {
        browserOps.GoTo(testUrl);
        Assert.AreEqual("Swag Labs", browserOps.Title);

        loginPage.Username.SendKeys("standard_user");
        loginPage.Password.SendKeys("secret_sauce");
        loginPage.LoginButton.Click();

        Thread.Sleep(2000);
        browserOps.Close();
    }
}
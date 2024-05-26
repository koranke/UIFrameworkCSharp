using UIFrameworkCSharp.core;
using UIFrameworkCSharp.saucedemo;

namespace UIFrameworkCSharp.tests.saucedemoTests;

[TestClass]
public class LoginTests
{
    [TestCleanup]
    public void Cleanup()
    {
        SeleniumManager.CloseCurrentDriver();
    }

    [TestMethod]
    public void TestLoginWithValidCredentials()
    {
        SauceDemoSite site = new SauceDemoSite();
        site.LoginPage().SignIn("standard_user", "secret_sauce");
        site.ProductsPage().AssertIsOpen();
    }

    [TestMethod]
    [DataRow("standard_user", "invalid_password", "Username and password do not match any user in this service")]
    [DataRow("standard_user", "", "Password is required")]
    public void TestLoginWithInvalidCredentials(string username, string password, string errorMessage)
    {
        SauceDemoSite site = new SauceDemoSite();
        site.LoginPage().SignIn(username, password);
        site.LoginPage().LabelError.AssertTextContains(errorMessage);
    }
}

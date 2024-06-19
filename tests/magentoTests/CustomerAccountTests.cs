using System.Net;
using System.Net.Http.Json;
using UIFrameworkCSharp.magentodemo;
using UIFrameworkCSharp.magentodemo.api;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class CustomerAccountTests : TestBase
{
    private static Account defaultAccount;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        Customer customer = new Customer()
        {
            Email = "E3nNGbgzpp@test.com",
            Firstname = "Theodora",
            Lastname = "Watsical"
        };

        defaultAccount = new Account()
        {
            Customer = customer,
            Password = "LXQkph8754=="
        };

        HttpResponseMessage response = CustomerApi.TryGetToken(defaultAccount.ToAuthBody());
        if (response.StatusCode == HttpStatusCode.OK)
        {
            defaultAccount = CustomerApi.GetMe(response.Content.ReadFromJsonAsync<string>().Result);
        }
        else
        {
            defaultAccount = CustomerApi.Create(defaultAccount);
        }
        defaultAccount.Password = "LXQkph8754==";
    }

    [TestMethod]
    public void TestOpenNewCustomerPage()
    {
        MagentoSite site = new MagentoSite();
        site.HomePage.Open();
        site.HomePage.Navigation.LinkCreateAccount.Click();
        site.NewCustomerPage.AssertIsOpen();
    }

    [TestMethod]
    public void TestCreateAccount()
    {
        MagentoSite site = new MagentoSite();
        Account account = site.NewCustomerPage.Open().CreateRandomAccount();
        site.MyAccountPage.AssertIsOpen();
        site.MyAccountPage.LabelContactInfo.AssertText(account.GetContactInfo());
        site.MyAccountPage.LabelBillingAddress.AssertText(account.GetBillingAddressAsString());
    }

    [TestMethod]
    public void TestViewAccount()
    {
        MagentoSite site = new MagentoSite();
        site.MyAccountPage.Open(defaultAccount.ToAuthBody());
        site.MyAccountPage.AssertIsOpen();
        site.MyAccountPage.LabelContactInfo.AssertText(defaultAccount.GetContactInfo());
        site.MyAccountPage.LabelBillingAddress.AssertText(defaultAccount.GetBillingAddressAsString());
        site.MyAccountPage.LabelShippingAddress.AssertText(defaultAccount.GetShippingAddressAsString());
    }
}

using UIFrameworkCSharp.core.utilities;
using UIFrameworkCSharp.magentodemo.api;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.tests.magentoTests;

[TestClass]
public class ApiTests
{

    [TestMethod]
    public void TestCreateCustomer()
    {
        Account account = new Account().withDefaults();
        HttpResponseMessage response = CustomerApi.TryCreate(account);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public void TestGetMe()
    {
        Account account = new Account().withDefaults();
        CustomerApi.Create(account);
        string token = CustomerApi.GetToken(account.ToAuthBody());
        HttpResponseMessage response = CustomerApi.TryGetMe(token);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [TestMethod]
    public void TestAccountScenario()
    {
       Account account = new Account()
            .WithIncludeBillingAddress()
            .WithIncludeShippingAddress()
            .Create();

        Console.WriteLine(account.GetContactInfo());
    }
}

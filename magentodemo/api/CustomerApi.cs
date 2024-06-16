using System.Net.Http.Json;
using UIFrameworkCSharp.core.api;
using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.magentodemo.domain;

namespace UIFrameworkCSharp.magentodemo.api;

public class CustomerApi : ApiBase<CustomerApi>
{
    private CustomerApi()
    {
        BaseUrl = "https://magento.softwaretestingboard.com/rest/default/V1/";
    }

    public static string GetToken(AuthBody authBody)
    {
        return TryGetToken(authBody)
            .EnsureSuccessStatusCode()
            .Content.ReadFromJsonAsync<string>().Result;
    }

    public static HttpResponseMessage TryGetToken(AuthBody authBody)
    {
        return new CustomerApi().Post("integration/customer/token", authBody);
    }

    public static Account GetMe(string token)
    {
        return TryGetMe(token)
            .EnsureSuccessStatusCode()
            .Content.ReadFromJsonAsync<Account>().Result;
    }

    public static HttpResponseMessage TryGetMe(string token)
    {
        return new CustomerApi()
            .WithAuthType(AuthType.BEARER)
            .WithAuthorization(token)
            .Get("customers/me");
    }

    public static Account Create(Account account)
    {
        return TryCreate(account)
            .EnsureSuccessStatusCode()
            .Content.ReadFromJsonAsync<Account>().Result;
    }

    public static HttpResponseMessage TryCreate(Account account)
    {
        return new CustomerApi()
            .Post("customers", account);
    }

}

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
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

    /*
     * The Magento API returns the JSON in snake_case.  In order to get around that, we first need to get
     * the JSON back as a string.  Then we can deserialize the JSON into a Customer object using Newtonsoft.Json.
     * along with the GetSerializerSettings method.
    */
    public static Account GetMe(string token)
    {
        string json = TryGetMe(token)
            .EnsureSuccessStatusCode()
            .Content.ReadAsStringAsync().Result;

        Customer customer = JsonConvert.DeserializeObject<Customer>(json, GetSerializerSettings());

        return new Account() { Customer = customer };
    }

    /*
     * This is needed as the Magento GetMe API returns the JSON in snake_case.
    */
    public static JsonSerializerSettings GetSerializerSettings()
    {
        return new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
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

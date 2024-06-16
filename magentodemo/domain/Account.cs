using Newtonsoft.Json;
using UIFrameworkCSharp.core.utilities;
using UIFrameworkCSharp.magentodemo.api;

namespace UIFrameworkCSharp.magentodemo.domain;

public class Account : BaseScenario
{
    public Customer Customer { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    private bool includeBillingAddress;
    [JsonIgnore]
    private bool includeShippingAddress;

    public Account withDefaults()
    {
        if (needsPopulation)
        {
            Customer = new Customer().withMinDefaults();
            Password = GetNonNull(Password, RandomData.GetRandomPassword(20));

            if (includeBillingAddress)
            {
                Customer.WithAddress(new Address
                {
                    Firstname = Customer.Firstname,
                    Lastname = Customer.Lastname,
                    DefaultBilling = true
                }.withDefaults());
            }
            if (includeShippingAddress)
            {
                Customer.WithAddress(new Address
                {
                    Firstname = Customer.Firstname,
                    Lastname = Customer.Lastname,
                    DefaultShipping = true
                }.withDefaults());
            }
            needsPopulation = false;
        }
        return this;
    }

    public AuthBody ToAuthBody()
    {
        return new AuthBody
        {
            Username = Customer.Email,
            Password = Password
        };
    }

    public Account Create()
    {
        withDefaults();
        CustomerApi.Create(this);
        return this;
    }

    public Account WithIncludeBillingAddress()
    {
        includeBillingAddress = true;
        return this;
    }

    public Account WithIncludeShippingAddress()
    {
        includeShippingAddress = true;
        return this;
    }

    public string GetContactInfo()
    {
        return $"{Customer.Firstname} {Customer.Lastname}\n" +
               $"{Customer.Email}";
    }
}

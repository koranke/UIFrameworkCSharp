using UIFrameworkCSharp.core.utilities;
using UIFrameworkCSharp.core.extensions;
using UIFrameworkCSharp.core.enums;
using Newtonsoft.Json;

namespace UIFrameworkCSharp.magentodemo.domain;

public class Address : BaseScenario
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Telephone { get; set; }
    public List<string> Street { get; set; }
    public string City { get; set; }
    public AddressRegion Region { get; set; }
    public string Postcode { get; set; }
    [JsonIgnore]
    public string Country { get; set; }
    public string CountryId { get; set; }
    public bool DefaultShipping { get; set; }
    public bool DefaultBilling { get; set; }

    public Address withDefaults()
    {
        if (needsPopulation)
        {
            Firstname = GetNonNull(Firstname, RandomData.en.Name.FirstName());
            Lastname = GetNonNull(Lastname, RandomData.en.Name.LastName());
            Telephone = GetNonNull(Telephone, RandomData.en.Phone.PhoneNumber());
            Street = GetNonNull(Street, new List<string> {RandomData.en.Address.StreetAddress()});
            City = GetNonNull(City, RandomData.en.Address.City());
            Region = GetNonNull(Region, new AddressRegion().withDefaults());
            Postcode = GetNonNull(Postcode, RandomData.en.Address.ZipCode());
            CountryId = GetNonNull(CountryId, "US");
            Country = GetNonNull(Country, Countries.Get(CountryId).GetName());
            needsPopulation = false;
        }
        return this;
    }

    public override string ToString()
    {
        if (Country == null && CountryId != null)
        {
            Country = Countries.Get(CountryId).GetName();
        }
        return Firstname + " " + Lastname + Environment.NewLine + String.Join(Environment.NewLine, Street) + Environment.NewLine
            + City + ", " + Region.Region + ", " + Postcode + Environment.NewLine + Country + $"{Environment.NewLine}T: " + Telephone;
    }
}

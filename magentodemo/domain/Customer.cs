using UIFrameworkCSharp.core.utilities;

namespace UIFrameworkCSharp.magentodemo.domain;

public class Customer : BaseScenario
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public List<Address> Addresses { get; set; }

    public Customer withMinDefaults()
    {
        if (needsPopulation)
        {
            Firstname = GetNonNull(Firstname, RandomData.en.Name.FirstName());
            Lastname = GetNonNull(Lastname, RandomData.en.Name.LastName());
            Email = GetNonNull(Email, RandomData.en.Internet.Email());
            needsPopulation = false;
        }
        return this;
    }

    public Customer withDefaults()
    {
        if (needsPopulation)
        {
            withMinDefaults();
            Company = GetNonNull(Company, RandomData.en.Company.CompanyName());
            this.Addresses = GetNonNull(Addresses, new List<Address> { new Address().withDefaults() });
            needsPopulation = false;
        }
        return this;
    }

    public Customer WithAddress(Address address)
    {
        if (Addresses == null)
        {
            Addresses = new List<Address>();
        }
        this.Addresses.Add(address);
        return this;
    }

    public Customer WithEmail(string email)
    {
        this.Email = email;
        return this;
    }

    public Customer WithFirstname(string firstname)
    {
        this.Firstname = firstname;
        return this;
    }

    public Customer WithLastname(string lastname)
    {
        this.Lastname = lastname;
        return this;
    }

}

using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.core.utilities;
using UIFrameworkCSharp.core.extensions;

namespace UIFrameworkCSharp.magentodemo.domain;

public class AddressRegion : BaseScenario
{
    public int RegionId { get; set; }
    public string RegionCode { get; set; }
    public string Region { get; set; }

    public AddressRegion withDefaults()
    {
        if (needsPopulation)
        {
            State state = RandomData.en.PickRandom<State>();
            RegionId = state.GetId();
            RegionCode = state.ToString();
            Region = state.GetName();
            needsPopulation = false;
        }
        return this;
    }
}

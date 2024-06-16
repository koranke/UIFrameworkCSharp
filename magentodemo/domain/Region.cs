using UIFrameworkCSharp.core.enums;
using UIFrameworkCSharp.core.utilities;
using UIFrameworkCSharp.core.extensions;
using Newtonsoft.Json;

namespace UIFrameworkCSharp.magentodemo.domain;

public class Region : BaseScenario
{
    [JsonIgnore]
    public int RegionId { get; set; }
    public string RegionCode { get; set; }
    [JsonProperty("region")]
    public string RegionName { get; set; }

    public Region withDefaults()
    {
        if (needsPopulation)
        {
            State state = RandomData.en.PickRandom<State>();
            RegionId = state.GetId();
            RegionCode = state.ToString();
            RegionName = state.GetName();
            needsPopulation = false;
        }
        return this;
    }
}

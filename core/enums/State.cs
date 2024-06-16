using NLog.Config;
using UIFrameworkCSharp.core.attributes;

namespace UIFrameworkCSharp.core.enums;

public enum State
{
    [StateProperty("Alabama", 1)]
    AL,
    [StateProperty("Alaska", 2)]
    AK,
    [StateProperty("Arizona", 4)]
    AZ,
    [StateProperty("Arkansas", 5)]
    AR,
    [StateProperty("California", 12)]
    CA,
    [StateProperty("Colorado", 13)]
    CO,
    [StateProperty("Connecticut", 14)]
    CT,
    [StateProperty("Delaware", 15)]
    DE,
    [StateProperty("Florida", 18)]
    FL,
    [StateProperty("Georgia", 19)]
    GA,
    [StateProperty("Hawaii", 21)]
    HI,
    [StateProperty("Idaho", 22)]
    ID,
    [StateProperty("Illinois", 23)]
    IL,
    [StateProperty("Indiana", 24)]
    IN,
    [StateProperty("Iowa", 25)]
    IA,
    [StateProperty("Kansas", 26)]
    KS,
    [StateProperty("Kentucky", 27)]
    KY,
    [StateProperty("Louisiana", 28)]
    LA,
    [StateProperty("Maine", 29)]
    ME,
    [StateProperty("Maryland", 31)]
    MD,
    [StateProperty("Massachusetts", 32)]
    MA,
    [StateProperty("Michigan", 33)]
    MI,
    [StateProperty("Minnesota", 34)]
    MN,
    [StateProperty("Mississippi", 35)]
    MS,
    [StateProperty("Missouri", 36)]
    MO,
    [StateProperty("Montana", 37)]
    MT,
    [StateProperty("Nebraska", 38)]
    NE,
    [StateProperty("Nevada", 39)]
    NV,
    [StateProperty("New Hampshire", 40)]
    NH,
    [StateProperty("New Jersey", 41)]
    NJ,
    [StateProperty("New Mexico", 42)]
    NM,
    [StateProperty("New York", 43)]
    NY,
    [StateProperty("North Carolina", 44)]
    NC,
    [StateProperty("North Dakota", 45)]
    ND,
    [StateProperty("Ohio", 47)]
    OH,
    [StateProperty("Oklahoma", 48)]
    OK,
    [StateProperty("Oregon", 49)]
    OR,
    [StateProperty("Pennsylvania", 51)]
    PA,
    [StateProperty("Rhode Island", 53)]
    RI,
    [StateProperty("South Carolina", 54)]
    SC,
    [StateProperty("South Dakota", 55)]
    SD,
    [StateProperty("Tennessee", 56)]
    TN,
    [StateProperty("Texas", 57)]
    TX,
    [StateProperty("Utah", 58)]
    UT,
    [StateProperty("Vermont", 59)]
    VT,
    [StateProperty("Virginia", 61)]
    VA,
    [StateProperty("Washington", 62)]
    WA,
    [StateProperty("West Virginia", 63)]
    WV,
    [StateProperty("Wisconsin", 64)]
    WI,
    [StateProperty("Wyoming", 65)]
    WY
}
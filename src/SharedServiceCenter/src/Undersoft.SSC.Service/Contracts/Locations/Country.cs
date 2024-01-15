using System.Runtime.Serialization;

namespace Undersoft.SSC.Service.Contracts.Locations;

[DataContract]
public partial class Country : DataObject
{
    [DataMember(Order = 12)]
    public string? Name { get; set; }

    [DataMember(Order = 13)]
    public string? CountryCode { get; set; }

    [DataMember(Order = 14)]
    public string? Continent { get; set; }

    [DataMember(Order = 15)]
    public string? TimeZone { get; set; }

    [DataMember(Order = 16)]
    public long? CurrencyId { get; set; }

    [DataMember(Order = 17)]
    public virtual Currency? Currency { get; set; }

    [DataMember(Order = 18)]
    public long? LanguageId { get; set; }

    [DataMember(Order = 19)]
    public virtual Language? Language { get; set; }

    [DataMember(Order = 20)]
    public virtual DataObjects<CountryState>? CountryStates { get; set; }
}

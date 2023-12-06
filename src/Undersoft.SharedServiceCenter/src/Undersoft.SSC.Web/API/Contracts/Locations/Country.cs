using System.Runtime.Serialization;

namespace Undersoft.SSC.Web.API.Contracts.Locations;

[DataContract]
public partial class Country : DataObject
{
    public string? Name { get; set; }

    public string? CountryCode { get; set; }

    public string? Continent { get; set; }

    public string? TimeZone { get; set; }

    public long? CurrencyId { get; set; }
    public virtual Currency? Currency { get; set; }

    public long? LanguageId { get; set; }
    public virtual Language? Language { get; set; }

    public virtual DataObjects<CountryState>? CountryStates { get; set; }
}

using System.Runtime.Serialization;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.Contracts.Locations;

[DataContract]
public class Address : DataObject
{
    [DataMember(Order = 12)]
    public string? CityName { get; set; }

    [DataMember(Order = 13)]
    public string? StreetName { get; set; }

    [DataMember(Order = 14)]
    public string? BuildingNumber { get; set; }

    [DataMember(Order = 15)]
    public string? ApartmentNumber { get; set; }

    [DataMember(Order = 16)]
    public string? Postcode { get; set; }

    [DataMember(Order = 17)]
    public string? Notices { get; set; }

    [DataMember(Order = 18)]
    public AddressType? AddressType { get; set; }

    [DataMember(Order = 19)]
    public long? CountryId { get; set; }

    [DataMember(Order = 20)]
    public virtual Country? Country { get; set; }

    [DataMember(Order = 21)]
    public long? StateId { get; set; }

    [DataMember(Order = 22)]
    public virtual CountryState? CountryState { get; set; }
}

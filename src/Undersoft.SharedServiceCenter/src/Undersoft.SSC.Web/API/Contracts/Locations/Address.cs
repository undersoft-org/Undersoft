using System.Runtime.Serialization;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts.Locations;

[DataContract]
public class Address : DataObject
{
    public string? CityName { get; set; }

    public string? StreetName { get; set; }

    public string? BuildingNumber { get; set; }

    public string? ApartmentNumber { get; set; }

    public string? Postcode { get; set; }

    public string? Notices { get; set; }

    public AddressType? AddressType { get; set; }

    public long? CountryId { get; set; }
    public virtual Country? Country { get; set; }

    public long? StateId { get; set; }
    public virtual CountryState? CountryState { get; set; }
}

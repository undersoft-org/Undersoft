using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities.Locations
{
    public class Address : DataObject
    {
        public string? CityName { get; set; }

        public string? StreetName { get; set; }

        public string? BuildingNumber { get; set; }

        public string? ApartmentNumber { get; set; }

        public string? Postcode { get; set; }

        public string? Notices { get; set; }

        public AddressType AddressType { get; set; }

        public long? CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public long? StateId { get; set; }
        public virtual CountryState? CountryState { get; set; }

        public long? LocationId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Location? Location { get; set; }
    }
}

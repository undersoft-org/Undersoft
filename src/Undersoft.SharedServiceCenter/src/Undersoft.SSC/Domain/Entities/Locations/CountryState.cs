
using Undersoft.SDK.Service.Data.Object;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Undersoft.SSC.Domain.Entities.Locations
{
    public class CountryState : DataObject
    {
        public string? Name { get; set; }

        public string? StateCode { get; set; }

        public string? TimeZone { get; set; }

        public long? CountryId { get; set; }
        public virtual Country? Country { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual RelatedSet<Address>? Addresses { get; set; }
    }
}

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;

namespace Undersoft.SSC.Entities.Members.Locations
{
    public class Language : DataObject
    {
        public string? Name { get; set; }

        public string? LanguageCode { get; set; }

        public virtual RelatedSet<Country>? Countries { get; set; }
    }
}

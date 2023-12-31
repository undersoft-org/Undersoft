using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Domain.Entities.Locations
{
    public class Language : DataObject
    {
        public string? Name { get; set; }

        public string? LanguageCode { get; set; }

        public virtual RelatedSet<Country>? Countries { get; set; }
    }
}

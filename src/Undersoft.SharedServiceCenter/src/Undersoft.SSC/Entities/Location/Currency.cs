using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;

namespace Undersoft.SSC.Entities.Locations
{
    public partial class Currency : DataObject
    {
        public string? Name { get; set; }

        public string? CurrencyCode { get; set; }

        public virtual RelatedSet<Country>? Countries { get; set; }

        public double Rate { get; set; }
    }
}

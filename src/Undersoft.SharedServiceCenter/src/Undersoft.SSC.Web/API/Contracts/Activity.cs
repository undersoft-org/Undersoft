using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

public class Activity : DataObject, IContract
{
    public virtual Identifiers<Activity>? Identifiers { get; set; }

    public virtual Details<Detail>? Details { get; set; }

    public virtual Settings<Setting>? Settings { get; set; }

    [IdentityRubric]
    public virtual ActivityGroup? Group { get; set; }

}

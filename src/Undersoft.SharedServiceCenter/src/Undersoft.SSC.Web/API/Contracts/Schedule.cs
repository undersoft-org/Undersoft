namespace Undersoft.SSC.Web.API.Contracts;

using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SSC.Domain.Entities.Enums;

public class Schedule : DataObject, IContract
{
    public virtual Identifiers<Schedule>? Identifiers { get; set; }

    public virtual Details<Detail>? Details { get; set; }

    public virtual Settings<Setting>? Settings { get; set; }

    [IdentityRubric]
    public virtual ScheduleGroup? Group { get; set; }
}

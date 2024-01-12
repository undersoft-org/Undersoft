using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Entities.Schedules;

public class ScheduleDetail : ObjectDetail<ScheduleDetail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<ScheduleDetail>? RelatedFrom { get; set; }

    public virtual RelatedSet<ScheduleDetail>? RelatedTo { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual ScheduleDefault? Default { get; set; }
}

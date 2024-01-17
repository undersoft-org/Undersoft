using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities;

public class Detail : ObjectDetail<Detail, DetailKind>, IEntity, ISerializableJsonDocument, IDetail
{
    public virtual RelatedSet<Detail>? RelatedFrom { get; set; }

    public virtual RelatedSet<Detail>? RelatedTo { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Application>? Applications { get; set; }

    public virtual RelatedSet<Platform>? Platforms { get; set; }

    public virtual RelatedSet<Service>? Services { get; set; }

    public virtual RelatedSet<Equipment>? Equipment { get; set; }

    public virtual RelatedSet<Infrastructure>? Infrastructures { get; set; }

    public virtual long DefaultId { get; set; }
    public virtual Default? Default { get; set; }
}

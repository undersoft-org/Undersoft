using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities;

public class Detail : ObjectDetail<Detail, DetailKind>, IEntity, ISerializableObject, IDetail
{
    public virtual RelatedSet<Detail>? RelatedFrom { get; set; }

    public virtual RelatedSet<Detail>? RelatedTo { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }
}

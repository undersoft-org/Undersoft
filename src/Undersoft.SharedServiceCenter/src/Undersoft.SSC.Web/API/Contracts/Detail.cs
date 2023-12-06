using System.Runtime.Serialization;
using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

[DataContract]
public class Detail : DataObjectDetail<Detail>, ISerializableObject, IDetail, IContract
{
    public Detail() : base() { }

    public Detail(DetailKind kind) : base() { Kind = kind; }

    public virtual string? Name { get; set; }

    [IdentityRubric]
    public DetailKind Kind { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities;

public class Detail : DataObject, IEntity, ISerializableObject, IDetail
{
    [NotMapped]
    [JsonIgnore]
    [IgnoreDataMember]
    internal IDataSerializer _serializer;

    public Detail()
    {
        _serializer = new DataSerializer(this);
    }

    public virtual RelatedSet<Detail>? RelatedFrom { get; set; }

    public virtual RelatedSet<Detail>? RelatedTo { get; set; }

    public virtual Identifiers<Detail>? Identifiers { get; set; }

    public virtual RelatedSet<Account>? Accounts { get; set; }

    public virtual RelatedSet<Activity>? Activities { get; set; }

    public virtual RelatedSet<Schedule>? Schedules { get; set; }

    public virtual RelatedSet<Resource>? Resources { get; set; }

    public virtual string? Name { get; set; }

    public virtual JsonDocument? Document { get; set; }

    public virtual string? TypeName { get; set; }

    public DetailKind Kind { get; set; }

    public T GetObject<T>()
    {
        return _serializer.GetObject<T>();
    }

    public void SetDocument<T>(T structure)
    {
        _serializer.SetDocument(structure);
    }
}

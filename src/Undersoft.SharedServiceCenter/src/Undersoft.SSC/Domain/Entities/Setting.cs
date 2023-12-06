using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities
{
    public class Setting : DataObject, ISerializableObject, ISetting
    {
        internal IDataSerializer _serializer;

        public Setting()
        {
            _serializer = new DataSerializer(this);
        }

        public virtual RelatedSet<Setting>? RelatedFrom { get; set; }

        public virtual RelatedSet<Setting>? RelatedTo { get; set; }

        public virtual Identifiers<Setting>? Identifiers { get; set; }

        public virtual RelatedSet<Account>? Accounts { get; set; }

        public virtual RelatedSet<Activity>? Activities { get; set; }

        public virtual RelatedSet<Schedule>? Schedules { get; set; }

        public virtual RelatedSet<Resource>? Resources { get; set; }

        public long? DefaultId { get; set; }
        public virtual Default? Default { get; set; }

        public virtual string? Name { get; set; }

        public virtual JsonDocument? Document { get; set; }

        public virtual string? TypeName { get; set; }

        public T GetObject<T>()
        {
            return _serializer.GetObject<T>();
        }

        public void SetDocument<T>(T structure)
        {
            _serializer.SetDocument(structure);
        }

        public virtual SettingKind Kind { get; set; }

    }
}
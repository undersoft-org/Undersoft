using System.Runtime.Serialization;
using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts
{
    [DataContract]
    public class Setting : DataObjectDetail<Setting>, ISetting, IContract
    {
        public Setting() : base() { }

        public Setting(SettingKind kind) : base() { Kind = kind; }

        public virtual string? Name { get; set; }

        [IdentityRubric]
        public virtual SettingKind Kind { get; set; }
    }
}

using System.Runtime.Serialization;
using Undersoft.SDK.Instant.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

[DataContract]
public class Account : DataObject, IContract
{
    public Account() { }

    public virtual Identifiers<Account>? Identifiers { get; set; }

    public virtual Details<Detail>? Details { get; set; }

    public virtual Settings<Setting>? Settings { get; set; }

    [IdentityRubric]
    public virtual AccountGroup? Group { get; set; }
}



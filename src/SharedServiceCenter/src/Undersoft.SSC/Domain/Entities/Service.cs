namespace Undersoft.SSC.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities.Enums;

public class Service : OpenEntity<Service, Detail, Setting, ServiceGroup>
{
    public virtual RelatedSet<Service>? RelatedFrom { get; set; }

    public virtual RelatedSet<Service>? RelatedTo { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    [Remote]
    public virtual RemoteSet<Application>? Applications { get; set; }

    public virtual long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    [ForeignKey(nameof(Location))]
    public virtual long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}

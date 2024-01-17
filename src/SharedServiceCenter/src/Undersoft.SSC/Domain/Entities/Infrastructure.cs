namespace Undersoft.SSC.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities.Enums;

public class Infrastructure : OpenEntity<Infrastructure, Detail, Setting, PlatformGroup>
{
    public virtual RelatedSet<Infrastructure>? RelatedFrom { get; set; }

    public virtual RelatedSet<Infrastructure>? RelatedTo { get; set; }

    public virtual RelatedSet<Service>? Services { get; set; }

    public virtual RelatedSet<Member>? Members { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    [ForeignKey(nameof(Location))]
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}

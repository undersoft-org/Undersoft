namespace Undersoft.SSC.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Remote;
using Undersoft.SSC.Domain.Entities.Enums;

public class Application : OpenEntity<Application, Detail, Setting, ApplicationGroup>
{
    public virtual EntitySet<Application>? RelatedFrom { get; set; }

    public virtual EntitySet<Application>? RelatedTo { get; set; }

    [Remote]
    public virtual RemoteSet<Service>? Services { get; set; }
    public virtual RemoteSet<
        RemoteLink<Service, Application>
    >? ServicesToApplications { get; set; }

    public virtual EntitySet<Member>? Members { get; set; }

    public long? DefaultId { get; set; }
    public virtual Default? Default { get; set; }

    [ForeignKey(nameof(Location))]
    public long? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}

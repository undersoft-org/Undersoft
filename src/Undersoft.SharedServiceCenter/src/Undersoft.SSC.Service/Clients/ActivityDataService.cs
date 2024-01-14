using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Schedules;

namespace Undersoft.SSC.Service.Clients;

public class ActivityDataService : OpenDataService
{
    public ActivityDataService(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        builder
            .RemoteSetToSet<Activity, Member>(k => k.TargetId, k => k.Id)
            .RemoteSetToSet<Activity, Resource>(k => k.TargetId, k => k.Id)
            .RemoteSetToSet<Activity, Schedule>(k => k.TargetId, k => k.Id);

        return base.OnModelCreating(builder);
    }
}

using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Schedules;

namespace Undersoft.SSC.Service.Clients;

public class MemberDataService : OpenDataService
{
    public MemberDataService(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        builder
            .RemoteSetToSet<Member, Activity>(k => k.TargetId, k => k.Id)
            .RemoteSetToSet<Member, Resource>(k => k.TargetId, k => k.Id)
            .RemoteSetToSet<Member, Schedule>(k => k.TargetId, k => k.Id);

        return base.OnModelCreating(builder);
    }
}

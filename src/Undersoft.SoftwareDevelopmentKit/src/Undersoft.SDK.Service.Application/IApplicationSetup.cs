﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Undersoft.SDK.Service.Application
{
    using DataServer;
    using Data.Store;

    public partial interface IApplicationSetup : IServiceSetup
    {
        IApplicationSetup AddDataServer<TServiceStore>(
            DataServerTypes dataServiceTypes,
            Action<DataServerBuilder> builder = null
        ) where TServiceStore : IDataServiceStore;
        IApplicationSetup AddAccountIdentity<TContext>() where TContext : DbContext;
        IApplicationSetup AddIdentityAuthentication();
        IApplicationSetup AddIdentityAuthorization();
        IApplicationSetup UseDataServices();
        IApplicationSetup AddApiVersions(string[] apiVersions);
        IApplicationSetup ConfigureApplication(bool includeSwagger, Assembly[] assemblies = null, Type[] sourceTypes = null, Type[] clientTypes = null);
    }
}

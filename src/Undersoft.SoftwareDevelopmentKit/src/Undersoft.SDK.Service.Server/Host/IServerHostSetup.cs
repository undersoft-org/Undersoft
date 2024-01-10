﻿using Microsoft.AspNetCore.Builder;

namespace Undersoft.SDK.Service.Server
{
    public interface IServerHostSetup
    {

        IServerHostSetup UseHeaderForwarding();

        IServerHostSetup UseApiSetup(string[] apiVersions);
        
        IServerHostSetup UseCustomSetup(Action<IServerHostSetup> action);

        IServerHostSetup UseDataServices();

        IServerHostSetup UseDefaultProvider();

        IServerHostSetup UseInternalProvider();

        IServerHostSetup UseDataMigrations();

        IServerHostSetup UseEndpoints(bool useRazorPages = false);

        IServerHostSetup UseJwtMiddleware();

        IServerHostSetup RebuildProviders();

        IServerHostSetup UseSwaggerSetup(string[] apiVersions);

        IServerHostSetup MapFallbackToFile(string filePath);

        IApplicationBuilder Application { get; }
    }
}
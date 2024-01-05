using Microsoft.AspNetCore.Builder;

namespace Undersoft.SDK.Service.Application
{
    public interface IApplicationHostSetup
    {

        IApplicationHostSetup UseHeaderForwarding();

        IApplicationHostSetup UseApiSetup(string[] apiVersions);
        
        IApplicationHostSetup UseCustomSetup(Action<IApplicationHostSetup> action);

        IApplicationHostSetup UseDataServices();

        IApplicationHostSetup UseDefaultProvider();

        IApplicationHostSetup UseInternalProvider();

        IApplicationHostSetup UseDataMigrations();

        IApplicationHostSetup UseEndpoints(bool useRazorPages = false);

        IApplicationHostSetup UseJwtMiddleware();

        IApplicationHostSetup RebuildProviders();

        IApplicationHostSetup UseSwaggerSetup(string[] apiVersions);

        IApplicationHostSetup MapFallbackToFile(string filePath);

        IApplicationBuilder Application { get; }
    }
}
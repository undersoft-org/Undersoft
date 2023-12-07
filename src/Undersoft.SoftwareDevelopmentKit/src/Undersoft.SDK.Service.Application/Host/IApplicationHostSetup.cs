namespace Undersoft.SDK.Service.Application
{
    public interface IApplicationHostSetup
    {

        IApplicationHostSetup UseHeaderForwarding();

        IApplicationHostSetup UseStandardSetup(string[] apiVersions, bool useRazorPages = false);

        IApplicationHostSetup UseDataServices();

        IApplicationHostSetup UseDefaultProvider();

        IApplicationHostSetup UseInternalProvider();

        IApplicationHostSetup UseDataMigrations();

        IApplicationHostSetup UseEndpoints(bool useRazorPages = false);

        IApplicationHostSetup UseJwtUserInfo();

        IApplicationHostSetup RebuildProviders();

        IApplicationHostSetup UseSwaggerSetup(string[] apiVersions);

        IApplicationHostSetup MapFallbackToFile(string filePath);
    }
}
namespace Undersoft.SDK.Service.Host
{
    public interface IServiceHostSetup
    {
        IServiceHostSetup UseDataServices();

        IServiceHostSetup UseInternalProvider();

        IServiceHostSetup UseDataMigrations();

        IServiceHostSetup RebuildProviders();
    }
}
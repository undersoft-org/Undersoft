using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Host;

namespace Undersoft.SDK.Service.Host
{
    public partial class ServiceHostSetup : IServiceHostSetup
    {
        IHostBuilder app;
        IHostingEnvironment env;

        public ServiceHostSetup(IHostBuilder application) { app = application; }

        public ServiceHostSetup(IHostBuilder application, IHostingEnvironment environment, bool useSwagger)
        {
            app = application;
            env = environment; 
        }

        public ServiceHostSetup(IHostBuilder application, IHostingEnvironment environment, string[] apiVersions = null)
        {
            app = application;
            env = environment;
        }

        public virtual IServiceHostSetup RebuildProviders()
        {
            UseInternalProvider();
            return this;
        }

        public IServiceHostSetup UseDataServices()
        {
            this.LoadOpenDataEdms().ConfigureAwait(true);
            return this;
        }

        public IServiceHostSetup UseDataMigrations()
        {
            using (var session = ServiceManager.NewSession())
            {
                try
                {
                    IServicer us = session.ServiceProvider.GetRequiredService<IServicer>();
                    us.GetSources().ForEach(e => ((DbContext)e.Context).Database.Migrate());
                }
                catch (Exception ex)
                {
                    this.Error<Applog>("Object migration initial create - unable to connect the database engine", null, ex);
                }
            }

            return this;
        }

        public virtual IServiceHostSetup UseInternalProvider()
        {
            ServiceManager.GetRegistry().MergeServices();
            app.UseServiceProviderFactory(ServiceManager.GetProviderFactory());
            return this;
        }      
    }
}
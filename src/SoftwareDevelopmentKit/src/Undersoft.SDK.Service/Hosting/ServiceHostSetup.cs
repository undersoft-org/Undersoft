using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.Host
{
    public partial class ServiceHostSetup : IServiceHostSetup
    {
        IHostBuilder app;
        IHostingEnvironment env;
        IServiceManager sm;

        public ServiceHostSetup(IHostBuilder application, IServiceManager manager) 
        { 
            app = application; 
            sm = manager;
        }

        public ServiceHostSetup(IHostBuilder application, IServiceManager manager, IHostingEnvironment environment, bool useSwagger) : this(application, manager)
        {
            env = environment; 
        }

        public ServiceHostSetup(IHostBuilder application, IServiceManager manager, IHostingEnvironment environment, string[] apiVersions = null) : this(application, manager)
        {
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
            using (var session = sm.CreateScope())
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
            sm.Registry.MergeServices();
            app.UseServiceProviderFactory(sm.GetProviderFactory());
            return this;
        }

        public virtual IServiceManager Manager => sm;
    }
}
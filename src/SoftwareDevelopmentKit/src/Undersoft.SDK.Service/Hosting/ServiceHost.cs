using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Infrastructure.Repository;

namespace Undersoft.SDK.Service.Hosting
{
    public class ServiceHost : IHost
    {
        public string ServiceName { get; set; }

        public IHost Host { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }
         
        public string Route { get; set; } 

        public long TenantId { get; set; }
         
        public string TenantName { get; set; }

        public string TypeName { get; set; } 

        public IServiceProvider Services => Host.Services;

        public void Dispose()
        {
            Host.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken = default)
        {            
            return Host.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken = default)
        {
            return Host.StopAsync(cancellationToken);
        }
    }
}
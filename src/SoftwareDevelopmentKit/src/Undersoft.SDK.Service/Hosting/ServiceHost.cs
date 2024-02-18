using Microsoft.Extensions.Hosting;

namespace Undersoft.SDK.Service.Hosting
{

    public class ServiceHost : Identifiable, IHost, IServiceHost
    {
        public string Name { get; set; }

        public IHost Host { get; set; }

        public string HostName { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public SslCertificate Certificate { get; set; }

        public string Route { get; set; }

        public long TenantId { get; set; }

        public string TenantName { get; set; }

        public IServiceProvider Services => Host.Services;

        public IServicer Servicer { get; set; }

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
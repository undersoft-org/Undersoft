using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.Server.Hosting;

public class ServerHost : Identifiable, IHost
{
    public string ServerName { get; set; }

    public IHost Host { get; set; }

    public string HostName { get; set; }

    public int Port { get; set; }

    public string Route { get; set; }

    public long TenantId { get; set; }

    public string TenantName { get; set; }

    public IServiceProvider? Services => Host?.Services;

    public Registry<ServiceHost> ServiceHosts { get; set; }

    private Registry<IServiceProvider> hostedServices;
    public Registry<IServiceProvider> HostedServices =>
        hostedServices ??= ServiceHosts.Select(s => s.Services).ToRegistry();

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        return Host.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        return Host.StopAsync(cancellationToken);
    }

    public void Dispose()
    {
        Host.Dispose();
    }
}

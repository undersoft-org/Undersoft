using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.Hosting;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Hosting;
using Undersoft.SDK.Service.Server.Hosting;

namespace Undersoft.SDK.Service.Application.Server.Hosting;

public class ApplicationServerHost : Identifiable, IHost
{
    private IHost _host { get; set; }

    public ApplicationServerHost(IHostBuilder builder)
    {
        _host = builder.Build();
    }
    
    public string? ServerName { get; set; }

    public string? HostName { get; set; }

    public int Port { get; set; }

    public string? Route { get; set; }

    public long TenantId { get; set; }

    public string? TenantName { get; set; }

    public IServiceProvider Services => _host.Services;

    public Registry<ApplicationHost>? ApplicationHosts { get; set; }

    private Registry<IServiceProvider?>? hostedApplications;
    public Registry<IServiceProvider?>? HostedApplications =>
        hostedApplications ??= ApplicationHosts?.Select(s => s.Services)?.ToRegistry();

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        return _host.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        return _host.StopAsync(cancellationToken);
    }

    public void Dispose()
    {
        _host?.Dispose();
    }
}
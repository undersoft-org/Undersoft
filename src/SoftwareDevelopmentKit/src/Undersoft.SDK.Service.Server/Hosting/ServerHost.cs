using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service.Server.Hosting;

public class ServerHost : DataObject
{
    public IHost Host { get; set; }

    public string HostName { get; set; }

    public int ServerPort { get; set; }

    public string Route { get; set; }

    public long TenantId { get; set; }

    public string TenantName { get; set; }

    public string ServerName { get; set; }

    public Registry<ServiceHost> ServiceHosts { get; set; }

}
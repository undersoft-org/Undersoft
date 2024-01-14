using Microsoft.Extensions.Hosting;
using Undersoft.SDK.Service.Infrastructure.Repository;

namespace Undersoft.SDK.Service.Host
{
    public class ServiceHost
    {
        public IHost Host { get; set; }

        public string Name { get; set; }
        
        public int Port { get; set; }

        public string Path { get; set; }
         
        public long TenantId { get; set; }
        
        public string Tenant { get; set; }

        public string TypeName { get; set; }
    }
}
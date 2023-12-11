using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Host;

namespace Undersoft.SDK.Service
{
    public static class ServiceSetupExtensions
    {
        public static IServiceSetup AddServiceSetup(this IServiceCollection services)
        {
            return new ServiceSetup(services);
        }       
    }
}

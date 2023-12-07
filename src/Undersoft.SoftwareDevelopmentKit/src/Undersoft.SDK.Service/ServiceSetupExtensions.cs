using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service;

namespace Undersoft.SDK.Service
{
    public static class ServiceSetupExtensions
    {
        public static IServiceSetup AddServiceSetup(this IServiceCollection services, IMvcBuilder mvcBuilder)
        {
            return new ServiceSetup(services, mvcBuilder);
        }

        public static IServiceSetup AddServiceSetup(this IServiceCollection services)
        {
            return new ServiceSetup(services);
        }
    }
}

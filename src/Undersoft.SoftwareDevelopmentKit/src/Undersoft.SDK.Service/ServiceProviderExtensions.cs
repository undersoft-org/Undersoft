using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;
using Undersoft.SDK.Service.Data.Repository;
using Undersoft.SDK.Service.Host;

namespace Undersoft.SDK.Service
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider AddPropertyInjection(this IServiceProvider provider)
        {
            var field = typeof(ServiceProvider).GetField("_createServiceAccessor",
                            BindingFlags.Instance | BindingFlags.NonPublic);
            var accessor = (Delegate)field.GetValue(provider);
            var newAccessor = (Type type) =>
            {
                Func<object, object> newFunc = (scope) =>
                {
                    var resolver = (Delegate)accessor.DynamicInvoke(new[] { type });
                    var resolved = resolver.DynamicInvoke(new[] { scope });
                    InjectProperties(provider, type, resolved);
                    return resolved;
                };
                return newFunc;
            };
            field.SetValue(provider, newAccessor);
            return provider;
        }

        private static void InjectProperties(IServiceProvider provider, Type type, object service)
        {
            if (service is null) return;
            var propInfos = service.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<InjectAttribute>() != null)
                .ToList();
            foreach (var propInfo in propInfos)
            {
                var instance = provider.GetService(propInfo.PropertyType);
                propInfo.SetValue(service, instance);
            }
        }

        public static async Task LoadDataServiceModels(this IServiceProvider provider)
        {
            await Task.Run(() =>
            {
                RepositoryManager.Clients.ForEach((client) =>
                {
                    client.BuildMetadata();
                });

                ServiceHostSetup.AddOpenDataServiceImplementations();
            });
        }

        public static IServiceProvider UseDataServices(this IServiceProvider provider)
        {
            provider.LoadDataServiceModels().ConfigureAwait(false);
            return provider;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute { }
}

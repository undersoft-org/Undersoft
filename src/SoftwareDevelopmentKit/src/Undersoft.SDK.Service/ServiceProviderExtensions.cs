﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Undersoft.SDK.Service.Hosting;

namespace Undersoft.SDK.Service
{
    public static class ServiceProviderExtensions
    {
        public static IServiceProvider AddPropertyInjection(this IServiceProvider provider)
        {
            var field = typeof(ServiceProvider).GetField(
                "_createServiceAccessor",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
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
            if (service is null)
                return;
            service
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<InjectPropertyAttribute>() != null)
                .ForEach(prop => prop.SetValue(service, provider.GetService(prop.PropertyType)));
        }

        public static async Task LoadDataServiceModelsAsync(this IServiceProvider provider)
        {
            var sm = provider.GetService<IServiceManager>();
            foreach (var client in sm.GetClients())
            {
                var model = await client.BuildMetadataAsync();
            }

            sm.Registry.AddOpenDataRemoteImplementations();
        }

        public static void LoadDataServiceModels(this IServiceProvider provider)
        {
            var sm = provider.GetService<IServiceManager>();
            foreach (var client in sm.GetClients())
            {
                var model = client.BuildMetadata();
            }

            sm.Registry.AddOpenDataRemoteImplementations();
        }

        public static async Task<IServiceProvider> UseServiceClientsAsync(this IServiceProvider provider)
        {
            await provider.LoadDataServiceModelsAsync();
            return provider;
        }

        public static IServiceProvider UseServiceClients(this IServiceProvider provider)
        {
            provider.LoadDataServiceModels();
            return provider;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InjectPropertyAttribute : Attribute { }
}

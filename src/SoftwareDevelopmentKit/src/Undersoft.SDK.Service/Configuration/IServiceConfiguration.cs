using System.Collections.Generic;

namespace Undersoft.SDK.Service.Configuration;
using Microsoft.Extensions.Configuration;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Store;

public interface IServiceConfiguration : IConfiguration
{
    string Version { get; }
    IServiceConfiguration Configure<TOptions>(string sectionName) where TOptions : class;
    IConfigurationSection Client(string name);
    IConfigurationSection DataCacheLifeTime();
    int ClientPoolSize(IConfigurationSection endpoint);
    string ClientConnectionString(IConfigurationSection client);
    string ClientConnectionString(string name);
    ClientProvider ClientProvider(IConfigurationSection client);
    ClientProvider ClientProvider(string name);
    IEnumerable<IConfigurationSection> Clients();
    string TypeName { get; }
    string StoreRoutes(string name);
    IConfigurationSection Source(string name);
    int SourcePoolSize(IConfigurationSection endpoint);
    string SourceConnectionString(IConfigurationSection endpoint);
    string SourceConnectionString(string name);
    StoreProvider SourceProvider(IConfigurationSection endpoint);
    StoreProvider SourceProvider(string name);
    IEnumerable<IConfigurationSection> Sources();
    string Name { get; }
    IConfigurationSection Repository();
    IConfigurationSection AccessServer();
    string IdentityServerBaseUrl();
    string IdentityServiceName();
    string[] IdentityServerScopes();
    string[] IdentityServerRoles();
    AccessServerOptions GetAccessServerConfiguration();
    AccessServerOptions AccessOptions { get; }
}
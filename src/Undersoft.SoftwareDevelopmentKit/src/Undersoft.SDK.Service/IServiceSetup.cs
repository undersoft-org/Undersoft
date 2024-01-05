using AutoMapper;
using System.Reflection;

namespace Undersoft.SDK.Service;

using Data.Mapper;

public partial interface IServiceSetup
{
    IServiceSetup AddMapper(IDataMapper mapper);
    IServiceSetup AddMapper(params MapperProfile[] profiles);
    IServiceSetup AddMapper<TProfile>() where TProfile : MapperProfile;
    IServiceSetup AddCaching();
    IServiceSetup ConfigureServices(Assembly[] assemblies = null, Type[] sourceTypes = null, Type[] clientTypes = null);
    IServiceSetup AddRepositorySources(Assembly[] assemblies = null);
    IServiceSetup AddRepositoryClients(Assembly[] assemblies = null);
    IServiceSetup AddImplementations(Assembly[] assemblies = null);
    IServiceSetup AddPropertyInjection();
    IServiceSetup MergeServices();
    IServiceRegistry Services { get; }
}
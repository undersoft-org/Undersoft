using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection;
using Undersoft.SDK.Service.Server.Controller;
using Microsoft.AspNetCore.OData.Formatter;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Client.Remote;

namespace Undersoft.SDK.Service.Server;

public class OpenDataServerBuilder<TStore> : DataServerBuilder, IDataServerBuilder<TStore>
    where TStore : IDataServiceStore
{
    IServiceRegistry _registry;
    protected ODataConventionModelBuilder odataBuilder;
    protected IEdmModel edmModel;
    protected static bool actionSetAdded;

    public OpenDataServerBuilder(IServiceRegistry registry) : base()
    {
        _registry = registry;
        odataBuilder = new ODataConventionModelBuilder();
        StoreType = typeof(TStore);
    }

    public OpenDataServerBuilder(IServiceRegistry registry, string routePrefix, int pageLimit) : this(registry)
    {
        RoutePrefix += "/" + routePrefix;
        PageLimit = pageLimit;
    }

    public override void Build()
    {
        BuildEdm();
        _registry.MergeServices(true);
    }

    public object EntitySet(Type entityType)
    {
        var entitySetName = entityType.Name;
        if (entityType.IsGenericType && entityType.IsAssignableTo(typeof(Identifier)))
            entitySetName = entityType.GetGenericArguments().FirstOrDefault().Name + "Identifier";

        var etc = odataBuilder.AddEntityType(entityType);
        etc.Name = entitySetName;
        var ets = odataBuilder.AddEntitySet(entitySetName, etc);
        ets.EntityType.HasKey(entityType.GetProperty("Id"));

        return ets;
    }

    public object EntitySet<TDto>() where TDto : class
    {
        return odataBuilder.EntitySet<TDto>(typeof(TDto).Name);
    }

    public IEdmModel GetEdm()
    {
        if (edmModel == null)
        {
            edmModel = odataBuilder.GetEdmModel();
            odataBuilder.ValidateModel(edmModel);
        }
        return edmModel;
    }

    public void BuildEdm()
    {
        Assembly[] asm = AppDomain.CurrentDomain.GetAssemblies();
        var controllerTypes = asm.SelectMany(
                a =>
                    a.GetTypes()
                        .Where(
                            type =>
                                type.GetCustomAttribute<OpenDataServiceAttribute>() != null
                                || type.GetCustomAttribute<OpenDataActionServiceAttribute>() != null
                                || type.GetCustomAttribute<RemoteOpenDataServiceAttribute>() != null
                                || type.GetCustomAttribute<RemoteOpenDataActionServiceAttribute>()
                                    != null
                        )
            )
            .ToArray();

        foreach (var controllerType in controllerTypes)
        {
            var genTypes = controllerType.BaseType.GenericTypeArguments;

            if (
                genTypes.Length > 4
                && genTypes[1].IsAssignableTo(StoreType)
                && genTypes[2].IsAssignableTo(StoreType)
            )
                EntitySet(genTypes[4]);
            else if (genTypes.Length > 3)
            {
                if (
                    genTypes[3].IsAssignableTo(typeof(IOrigin))
                    && (
                        genTypes[1].IsAssignableTo(StoreType)
                        || genTypes[0].IsAssignableTo(StoreType)
                    )
                )
                    EntitySet(genTypes[3]);
                else
                    continue;
            }
            else if (genTypes.Length > 2)
                if (
                    genTypes[2].IsAssignableTo(typeof(IDataObject))
                    && genTypes[0].IsAssignableTo(StoreType)
                )
                    EntitySet(genTypes[2]);
                else
                    continue;
        }
    }

    public IMvcBuilder AddODataServicer(IMvcBuilder mvc)
    {
        var model = GetEdm();
        var route = GetRoutes();
        mvc.AddOData(b =>
        {
            b.RouteOptions.EnableQualifiedOperationCall = true;
            b.RouteOptions.EnableUnqualifiedOperationCall = true;
            b.RouteOptions.EnableKeyInParenthesis = true;
            b.RouteOptions.EnableKeyAsSegment = false;
            b.RouteOptions.EnableControllerNameCaseInsensitive = true;
            b.EnableQueryFeatures(PageLimit).AddRouteComponents(route, model);
        });
        AddODataSupport(mvc);
        _registry.MergeServices(true);
        return mvc;
    }

    private IMvcBuilder AddODataSupport(IMvcBuilder mvc)
    {
        mvc.AddMvcOptions(options =>
        {
            foreach (
                OutputFormatter outputFormatter in options.OutputFormatters
                    .OfType<OutputFormatter>()
                    .Where(x => x.SupportedMediaTypes.Count == 0)
            )
            {
                outputFormatter.SupportedMediaTypes.Add(
                    new MediaTypeHeaderValue("_application/prs.odatatestxx-odata")
                );
            }

            foreach (
                InputFormatter inputFormatter in options.InputFormatters
                    .OfType<InputFormatter>()
                    .Where(x => x.SupportedMediaTypes.Count == 0)
            )
            {
                inputFormatter.SupportedMediaTypes.Add(
                    new MediaTypeHeaderValue("_application/prs.odatatestxx-odata")
                );
            }
        });
        return mvc;
    }

    protected override string GetRoutes()
    {
        if (StoreType == typeof(IEventStore))
        {
            return StoreRoutes.OpenEventRoute;
        }
        else if (StoreType == typeof(IIdentityStore))
        {
            return StoreRoutes.OpenIdentityRoute;
        }
        else
        {
            return StoreRoutes.OpenDataRoute;
        }
    }

    public override IDataServerBuilder AddAccountServices<TAuth>() where TAuth : class
    {
        AddAuthorizationActions<TAuth>();
        return base.AddAccountServices<TAuth>();
    }

    private void AddAuthorizationActions<TAuth>() where TAuth : class
    {
        if (actionSetAdded)
            return;

        var name = typeof(TAuth).Name;  

        odataBuilder
            .EntityType<TAuth>()
            .Function("SignIn")
            .Returns<string>()
            .Parameter<string>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("SignIn")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("SignUp")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("SignOut")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("Renew")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("ConfirmEmail")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("ResetPassword")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        odataBuilder
            .EntityType<TAuth>()
            .Action("CompleteRegistration")
            .ReturnsFromEntitySet<TAuth>(name)
            .Parameter<TAuth>(name);

        actionSetAdded = true;
    }
}

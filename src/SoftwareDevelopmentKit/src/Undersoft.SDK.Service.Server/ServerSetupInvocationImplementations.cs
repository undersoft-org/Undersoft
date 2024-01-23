using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Data.Model;
using Series;
using System.Collections.Generic;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Invocation.Handler;
using Undersoft.SDK.Service.Server.Operation.Invocation.Notification;
using Undersoft.SDK.Service.Server.Operation.Invocation.Notification.Handler;

public partial class ServerSetup
{
    public IServerSetup AddServerSetupInternalActionImplementations()
    {
        IServiceRegistry service = registry;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        IServiceCollection deck = service
            .AddTransient<ISeries<IModel>, Registry<IModel>>()
            .AddScoped<ITypedSeries<IModel>, TypedRegistry<IModel>>();

        var controllerTypes = assemblies
            .SelectMany(
                a =>
                    a.GetTypes()
                        .Where(
                            type =>
                                type.GetCustomAttributes()
                                    .Any(a => a.GetType().IsAssignableTo(typeof(ServiceClientAttribute)))
                        )
                        .ToArray()
            )
            .Where(
                b =>
                    !b.IsAbstract
                    && b.BaseType.IsGenericType
                    && b.BaseType.GenericTypeArguments.Length > 2
            )
            .ToArray();

        HashSet<string> duplicateCheck = new HashSet<string>();

        foreach (var controllerType in controllerTypes)
        {
            var genericTypes = controllerType.BaseType.GenericTypeArguments;
            var store = genericTypes[0];
            var actionType = genericTypes[2];
            var dtoType = genericTypes[3];
            var _method = genericTypes[1];

            if (duplicateCheck.Add(store.Name + actionType.Name + dtoType.Name + _method.Name))
            {
                service.AddTransient(
                    typeof(IRequest<>).MakeGenericType(
                        typeof(Invocation<>).MakeGenericType(dtoType)
                    ),
                    typeof(Invocation<>).MakeGenericType(dtoType)
                );
                service.AddTransient(
                    typeof(IRequestHandler<,>).MakeGenericType(
                        new[]
                        {
                            typeof(Action<,,>).MakeGenericType(store, actionType, dtoType),
                            typeof(Invocation<>).MakeGenericType(dtoType)
                        }
                    ),
                    typeof(ActionHandler<,,>).MakeGenericType(store, actionType, dtoType)
                );
                service.AddTransient(
                    typeof(IRequestHandler<,>).MakeGenericType(
                        new[]
                        {
                            typeof(Function<,,>).MakeGenericType(store, actionType, dtoType),
                            typeof(Invocation<>).MakeGenericType(dtoType)
                        }
                    ),
                    typeof(FunctionHandler<,,>).MakeGenericType(store, actionType, dtoType)
                );
                service.AddTransient(
                    typeof(INotificationHandler<>).MakeGenericType(
                        typeof(ActionInvoked<,,>).MakeGenericType(store, actionType, dtoType)
                    ),
                    typeof(ActionInvokedHandler<,,>).MakeGenericType(store, actionType, dtoType)
                );
                service.AddTransient(
                    typeof(INotificationHandler<>).MakeGenericType(
                        typeof(FunctionInvoked<,,>).MakeGenericType(store, actionType, dtoType)
                    ),
                    typeof(FunctionInvokedHandler<,,>).MakeGenericType(store, actionType, dtoType)
                );
            }
        }
        return this;
    }
}

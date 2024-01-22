using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Data.Model;
using Operation.Command;
using Operation.Command.Handler;
using Operation.Notification;
using Operation.Notification.Handler;
using Series;
using System.Collections.Generic;
using Undersoft.SDK.Service.Client;

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
                                    .Any(
                                        a =>
                                            a.GetType().IsAssignableTo(typeof(ServiceAttribute))
                                    )
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
                             typeof(Invocation<,>).MakeGenericType(dtoType, _method)
                         ),
                         typeof(Invocation<,>).MakeGenericType(dtoType, _method)
                     );

                service.AddTransient(
                   typeof(IRequestHandler<,>).MakeGenericType(
                       new[]
                       {
                            typeof(Invoke<,,,>).MakeGenericType(store, actionType, dtoType, _method),
                            typeof(Invocation<,>).MakeGenericType(dtoType, _method)
                       }
                   ),
                   typeof(InvokeHandler<,,,>).MakeGenericType(store, actionType, dtoType, _method)
               );

                service.AddTransient(
                 typeof(INotificationHandler<>).MakeGenericType(
                     typeof(Invoked<,,,>).MakeGenericType(store, actionType, dtoType, _method)
                 ),
                 typeof(ExecutedHandler<,,,>).MakeGenericType(store, actionType, dtoType, _method)
                );
            }
        }
        return this;
    }
}

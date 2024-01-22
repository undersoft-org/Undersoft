using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Operation.Remote.Command;
using Operation.Remote.Command.Handler;
using Operation.Remote.Notification;
using Operation.Remote.Notification.Handler;
using Undersoft.SDK.Service.Client.Remote;

public partial class ServerSetup
{
    public IServerSetup AddServerSetupRemoteActionImplementations()
    {
        IServiceRegistry service = registry;

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        var controllerTypes = assemblies
            .SelectMany(
                a =>
                    a.GetTypes()
                        .Where(
                            type =>
                                type.GetCustomAttributes()
                                    .Any(
                                        a =>
                                            a.GetType().IsAssignableTo(typeof(RemoteDataActionServiceAttribute))
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
            var _viewmodel = genericTypes[3];
            var dtoType = genericTypes[2];
            var _method = genericTypes[1];

            if (duplicateCheck.Add(store.Name + _viewmodel.Name + dtoType.Name + _method.Name))
            {

                service.AddTransient(
                  typeof(IRequest<>).MakeGenericType(
                      typeof(Invocation<,>).MakeGenericType(_viewmodel, _method)
                  ),
                  typeof(Invocation<,>).MakeGenericType(_viewmodel, _method)
              );

                service.AddTransient(
                   typeof(IRequestHandler<,>).MakeGenericType(
                       new[]
                       {
                            typeof(RemoteExecute<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method),
                            typeof(Invocation<,>).MakeGenericType(_viewmodel, _method)
                       }
                   ),
                   typeof(RemoteInvokeHandler<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
               );

                service.AddTransient(
                 typeof(INotificationHandler<>).MakeGenericType(
                     typeof(RemoteInvoked<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
                 ),
                 typeof(RemoteInvokedHandler<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
                );
            }
        }
        return this;
    }
}

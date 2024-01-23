using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Undersoft.SDK.Service.Client.Remote;
using Undersoft.SDK.Service.Server.Operation.Invocation;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation.Handler;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation.Notification;
using Undersoft.SDK.Service.Server.Operation.Remote.Invocation.Notification.Handler;

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
                                            a.GetType()
                                                .IsAssignableTo(
                                                    typeof(RemoteDataActionServiceAttribute)
                                                )
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
                        typeof(Invocation<>).MakeGenericType(_viewmodel)
                    ),
                    typeof(Invocation<>).MakeGenericType(_viewmodel)
                );

                service.AddTransient(
                    typeof(IRequestHandler<,>).MakeGenericType(
                        new[]
                        {
                            typeof(RemoteAction<,,>).MakeGenericType(store, dtoType, _viewmodel),
                            typeof(Invocation<>).MakeGenericType(_viewmodel)
                        }
                    ),
                    typeof(RemoteActionHandler<,,>).MakeGenericType(store, dtoType, _viewmodel)
                );
                service.AddTransient(
                    typeof(IRequestHandler<,>).MakeGenericType(
                        new[]
                        {
                            typeof(RemoteFunction<,,>).MakeGenericType(store, dtoType, _viewmodel),
                            typeof(Invocation<>).MakeGenericType(_viewmodel)
                        }
                    ),
                    typeof(RemoteFunctionHandler<,,>).MakeGenericType(store, dtoType, _viewmodel)
                );
                service.AddTransient(
                    typeof(INotificationHandler<>).MakeGenericType(
                        typeof(RemoteActionInvoked<,,>).MakeGenericType(store, dtoType, _viewmodel)
                    ),
                    typeof(RemoteActionInvokedHandler<,,>).MakeGenericType(store, dtoType, _viewmodel)
                );
                service.AddTransient(
                  typeof(INotificationHandler<>).MakeGenericType(
                      typeof(RemoteFunctionInvoked<,,>).MakeGenericType(store, dtoType, _viewmodel)
                  ),
                  typeof(RemoteFunctionInvokedHandler<,,>).MakeGenericType(store, dtoType, _viewmodel)
              );
            }
        }
        return this;
    }
}

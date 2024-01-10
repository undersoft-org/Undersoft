using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Behaviour;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Operation.Remote.Command;
using Operation.Remote.Command.Handler;
using Operation.Remote.Command.Validator;
using Operation.Remote.Notification;
using Operation.Remote.Notification.Handler;
using Operation.Remote.Query;
using Operation.Remote.Query.Handler;
using Operation.Remote.Validator;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Client.Remote;

public partial class ServerSetup
{
    public IServerSetup AddServerSetupRemoteActionImplementations(Assembly[] assemblies)
    {
        IServiceRegistry service = registry;

        assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

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
                      typeof(ActionCommand<,>).MakeGenericType(_viewmodel, _method)
                  ),
                  typeof(ActionCommand<,>).MakeGenericType(_viewmodel, _method)
              );

                service.AddTransient(
                   typeof(IRequestHandler<,>).MakeGenericType(
                       new[]
                       {
                            typeof(RemoteExecute<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method),
                            typeof(ActionCommand<,>).MakeGenericType(_viewmodel, _method)
                       }
                   ),
                   typeof(RemoteExecuteHandler<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
               );

                service.AddTransient(
                 typeof(INotificationHandler<>).MakeGenericType(
                     typeof(RemoteExecuted<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
                 ),
                 typeof(RemoteExecutedHandler<,,,>).MakeGenericType(store, dtoType, _viewmodel, _method)
                );
            }
        }
        return this;
    }
}

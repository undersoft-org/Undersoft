using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Undersoft.SDK.Service.Application;

using Series;
using Operation.Command;
using Operation.Command.Handler;
using Operation.Notification;
using Operation.Notification.Handler;
using Data.ViewModel;
using System.Collections.Generic;

public partial class ApplicationSetup
{
    public IApplicationSetup AddApplicationSetupInternalActionImplementations(Assembly[] assemblies)
    {
        IServiceRegistry service = registry;

        assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

        IServiceCollection deck = service
            .AddTransient<ISeries<IViewModel>, Registry<IViewModel>>()
            .AddScoped<ITypedSeries<IViewModel>, TypedRegistry<IViewModel>>();

        var controllerTypes = assemblies
            .SelectMany(
                a =>
                    a.GetTypes()
                        .Where(
                            type =>
                                type.GetCustomAttributes()
                                    .Any(
                                        a =>
                                            a.GetType().IsAssignableTo(typeof(DataActionServiceAttribute))
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
                             typeof(ActionCommand<,>).MakeGenericType(dtoType, _method)
                         ),
                         typeof(ActionCommand<,>).MakeGenericType(dtoType, _method)
                     );

                service.AddTransient(
                   typeof(IRequestHandler<,>).MakeGenericType(
                       new[]
                       {
                            typeof(Execute<,,,>).MakeGenericType(store, actionType, dtoType, _method),
                            typeof(ActionCommand<,>).MakeGenericType(dtoType, _method)
                       }
                   ),
                   typeof(ExecuteHandler<,,,>).MakeGenericType(store, actionType, dtoType, _method)
               );

                service.AddTransient(
                 typeof(INotificationHandler<>).MakeGenericType(
                     typeof(Executed<,,,>).MakeGenericType(store, actionType, dtoType, _method)
                 ),
                 typeof(ExecutedHandler<,,,>).MakeGenericType(store, actionType, dtoType, _method)
                );
            }
        }
        return this;
    }
}

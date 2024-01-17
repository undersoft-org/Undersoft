﻿using MediatR;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Repository.Client;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;

namespace Undersoft.SDK.Service
{
    public interface IServicer : IServiceManager, IRepositoryManager, IDisposable
    {
        T CallObject<T>() where T : class;
        T CallService<T>() where T : class;
        IAsyncEnumerable<object> CreateStream(object request, CancellationToken cancellationToken = default);
        IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default);
        Lazy<R> Deserve<T, R>(Func<T, R> function)
            where T : class
            where R : class;
        ValueTask DisposeAsyncCore();
        Task Publish(object notification, CancellationToken cancellationToken = default);
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification;
        Task<R> Run<T, R>(Func<T, Task<R>> function) where T : class;
        Task<R> Run<T, R>(string methodname, params object[] parameters) where T : class;
        Task Run<T>(Func<T, Task> function) where T : class;
        Task Run<T>(string methodname, params object[] parameters) where T : class;
        Task Save(bool asTransaction = false);
        Task<int> SaveClient(IRepositoryClient client, bool asTransaction = false);
        Task<int> SaveClients(bool asTransaction = false);
        Task<int> SaveEndpoint(IRepositorySource endpoint, bool asTransaction = false);
        Task<int> SaveEndpoints(bool asTransaction = false);
        Task<object> Send(object request, CancellationToken cancellationToken = default);
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
        Task<R> Serve<T, R>(Func<T, Task<R>> function) where T : class;
        Task<R> Serve<T, R>(string methodname, params object[] parameters) where T : class;
        Task Serve<T>(Func<T, Task> function) where T : class;
        Task Serve<T>(string methodname, params object[] parameters) where T : class;
    }
}
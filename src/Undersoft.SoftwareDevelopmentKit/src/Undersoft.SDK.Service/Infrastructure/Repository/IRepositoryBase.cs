using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Undersoft.SDK.Service.Data.Mapper;
using Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;


namespace Undersoft.SDK.Service.Infrastructure.Repository
{
    public interface IRepository : IRepositoryContext
    {
        Type ElementType { get; }

        Expression Expression { get; }

        IQueryProvider Provider { get; }

        IDataMapper Mapper { get; }

        CancellationToken Cancellation { get; set; }

        IEnumerable<IRemoteProperty> RemoteProperties { get; set; }

        void LoadRemote(object entity);

        Task LoadRemoteAsync(object entity);

        void LoadRelated(EntityEntry entry, RelatedType relatedType);

        void LoadRelatedAsync(EntityEntry entry, RelatedType relatedType, CancellationToken token);
    }
}
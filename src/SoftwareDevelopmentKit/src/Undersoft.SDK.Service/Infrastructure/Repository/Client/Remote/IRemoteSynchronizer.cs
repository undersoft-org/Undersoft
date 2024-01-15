using Microsoft.OData.Client;
using Undersoft.SDK.Service.Infrastructure.Repository;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote
{
    public interface IRemoteSynchronizer
    {
        void AddRepository(IRepository repository);

        void OnLinked(object sender, LoadCompletedEventArgs args);

        void AcquireLinker();

        void ReleaseLinker();

        void AcquireResult();

        void ReleaseResult();
    }
}


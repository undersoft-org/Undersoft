using Microsoft.EntityFrameworkCore;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Source
{
    public interface ISourceProviderConfiguration
    {
        IServiceRegistry AddSourceProvider(SourceProvider provider);
        DbContextOptionsBuilder BuildOptions(DbContextOptionsBuilder builder, SourceProvider provider, string connectionString);
    }
}
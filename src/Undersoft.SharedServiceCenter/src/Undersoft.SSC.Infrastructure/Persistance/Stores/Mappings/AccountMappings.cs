using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings
{
    using Undersoft.SSC.Domain.Entities;

    public class AccountMappings : EntityTypeMapping<Account>
    {
        const string TABLE_NAME = "Accounts";

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Account>()
                .LinkSetToSet<Account, Resource>(ExpandSite.OnRight)
                .LinkSetToSet<Account, Schedule>(ExpandSite.OnRight)
                .LinkSetToSet<Account, Setting>(ExpandSite.OnRight)
                .LinkSetToSet<Account, Detail>(ExpandSite.OnRight)
                .LinkOneToOne<Account, Location>(ExpandSite.OnRight)
                .LinkSetToSet<Account, Account>(
                    nameof(Account.RelatedTo),
                    nameof(Account.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

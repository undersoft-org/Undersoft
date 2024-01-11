using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Account;
    using Undersoft.SSC.Entities.Resource;
    using Undersoft.SSC.Entities.Schedule;

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
                .LinkOneToOne<Account, AccountLocation>(ExpandSite.OnRight)
                .LinkSetToSet<Account, Account>(
                    nameof(Account.RelatedTo),
                    nameof(Account.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

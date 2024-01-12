using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Data.Relation;
    using SDK.Service.Infrastructure.Store;
    using SSC.Entities.Accounts;
    using SSC.Entities.Activity;
    using Undersoft.SSC.Entities.Resources;
    using Undersoft.SSC.Entities.Schedules;

    public class AccountMappings : EntityTypeMapping<Account>
    {
        const string TABLE_NAME = "Accounts";

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Account>()
                .RelateOneToSet<AccountDefault, Account>(ExpandSite.OnLeft)
                .RelateSetToSet<Account, AccountSetting>(ExpandSite.OnRight)
                .RelateOneToOne<Account, AccountLocation>(ExpandSite.OnRight)
                .RelateSetToSet<Account, AccountDetail>(ExpandSite.OnRight)
                .RelateSetToSet<Account, Account>(
                    nameof(Account.RelatedTo),
                    nameof(Account.RelatedFrom),
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Account, Activity>(
                    r => r.AccountsToActivities,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Account, Resource>(
                    r => r.AccountsToResources,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Account, Schedule>(
                    r => r.AccountsToSchedules,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<AccountSetting, AccountSetting>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<AccountDetail, AccountDetail>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                );
        }
    }
}

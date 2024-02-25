using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SDK.Service.Server.Accounts
{
    using Undersoft.SDK.Service.Data.Store;
    using Undersoft.SDK.Service.Infrastructure.Database;

    public class AccountMappings : EntityTypeMapping<Account>
    {
        const string TABLE_NAME = "Accounts";

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.DomainSchema);

            builder.HasMany(c => c.Tokens).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);

            builder.HasOne(c => c.User).WithOne().HasForeignKey<Account>(u => u.UserId);

            builder.HasOne(c => c.Personal).WithOne().HasForeignKey<Account>(u => u.PersonalId);

            builder.HasMany(c => c.Proffesionals).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);

            builder.HasMany(c => c.Organizations).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);

            builder.HasMany(c => c.Consents).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);

            builder.HasMany(c => c.Subscriptions).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);

            builder.HasMany(c => c.Payments).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);
        }
    }

    public class RolemMappings : EntityTypeMapping<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(c => c.Claims).WithOne(c => c.Role).HasForeignKey(c => c.AccountRoleId);
        }
    }

    public class AccountPersonalMappings : EntityTypeMapping<AccountPersonal>
    {
        public override void Configure(EntityTypeBuilder<AccountPersonal> builder)
        {
            builder.HasOne(c => c.Account).WithOne().HasForeignKey<AccountPersonal>(k => k.AccountId);
        }
    }

    public class AccountTokenMappings : EntityTypeMapping<AccountToken>
    {
        public override void Configure(EntityTypeBuilder<AccountToken> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Tokens).HasForeignKey(c => c.AccountId);
        }
    }

    public class AccountProffesionalMappings : EntityTypeMapping<AccountProffesional>
    {
        public override void Configure(EntityTypeBuilder<AccountProffesional> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Proffesionals).HasForeignKey(c => c.AccountId);
        }
    }

    public class AccountOrganizationsMappings : EntityTypeMapping<AccountOrganization>
    {
        public override void Configure(EntityTypeBuilder<AccountOrganization> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Organizations).HasForeignKey(c => c.AccountId);
        }
    }

    public class AccountSubscriptionsMappings : EntityTypeMapping<AccountSubscription>
    {
        public override void Configure(EntityTypeBuilder<AccountSubscription> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Subscriptions).HasForeignKey(c => c.AccountId);
        }
    }

    public class AccountConsentsMappings : EntityTypeMapping<AccountConsent>
    {
        public override void Configure(EntityTypeBuilder<AccountConsent> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Consents).HasForeignKey(c => c.AccountId);
        }
    }

    public class AccountPaymentsMappings : EntityTypeMapping<AccountPayment>
    {
        public override void Configure(EntityTypeBuilder<AccountPayment> builder)
        {
            builder.HasOne(c => c.Account).WithMany(c => c.Payments).HasForeignKey(c => c.AccountId);
        }
    }
}

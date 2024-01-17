using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Domain.Entities.Locations;

public class LanguageMappings : EntityTypeMapping<Language>
{
    private const string TABLE_NAME = "Languages";

    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder.RelateOneToSet<Language, Country>(
            nameof(Country.Language),
            nameof(Language.Countries), ExpandSite.OnLeft);
    }
}
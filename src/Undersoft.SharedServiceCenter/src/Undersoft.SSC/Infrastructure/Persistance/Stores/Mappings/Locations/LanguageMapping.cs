using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings.Locations;


using Undersoft.SSC.Domain.Entities.Locations;

public class LanguageMapping : EntityTypeMapping<Language>
{
    private const string TABLE_NAME = "Languages";

    public override void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder.LinkOneToSet<Language, Country>(
            nameof(Country.Language),
            nameof(Language.Countries), ExpandSite.OnLeft);
    }
}
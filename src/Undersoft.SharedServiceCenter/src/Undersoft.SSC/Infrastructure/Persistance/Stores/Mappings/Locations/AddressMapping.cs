﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings.Locations;


using Undersoft.SSC.Domain.Entities.Locations;

public class AddressMapping : EntityTypeMapping<Address>
{
    private const string TABLE_NAME = "Addresses";

    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        builder.Property(p => p.CityName)
          .HasMaxLength(50)
          .HasColumnType("varchar")
          .IsRequired();

        builder.Property(p => p.StreetName)
          .HasMaxLength(100)
          .HasColumnType("varchar")
          .IsRequired();

        builder.Property(p => p.BuildingNumber)
         .HasMaxLength(20)
         .HasColumnType("varchar");

        builder.Property(p => p.ApartmentNumber)
         .HasMaxLength(20)
         .HasColumnType("varchar")
         .IsRequired();

        builder.Property(p => p.Postcode)
         .HasMaxLength(12)
         .HasColumnType("varchar")
         .IsRequired();

        builder.Property(p => p.Notices)
         .HasMaxLength(150)
         .HasColumnType("varchar");
    }
}
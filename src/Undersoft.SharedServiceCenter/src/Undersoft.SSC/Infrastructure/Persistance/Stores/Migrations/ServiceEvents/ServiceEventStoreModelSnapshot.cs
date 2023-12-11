﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Undersoft.SSC.Infrastructure.Persistance.Stores;

#nullable disable

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Migrations.ServiceEvents
{
    [DbContext(typeof(ServiceEventStore))]
    partial class ServiceEventStoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Undersoft.SDK.Service.Data.Event.Event", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    b.Property<long>("AggregateId")
                        .HasColumnType("bigint");

                    b.Property<string>("AggregateType")
                        .HasColumnType("text");

                    b.Property<string>("CodeNo")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp")
                        .HasColumnOrder(8);

                    b.Property<string>("Creator")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnOrder(9);

                    b.Property<byte[]>("EventData")
                        .HasColumnType("bytea");

                    b.Property<string>("EventType")
                        .HasColumnType("text");

                    b.Property<long>("EventVersion")
                        .HasColumnType("bigint");

                    b.Property<string>("Label")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnOrder(11);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp")
                        .HasColumnOrder(6);

                    b.Property<string>("Modifier")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnOrder(7);

                    b.Property<int>("Ordinal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(10);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Ordinal"));

                    b.Property<int>("OriginKey")
                        .HasColumnType("integer")
                        .HasColumnOrder(3);

                    b.Property<string>("OriginName")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnOrder(5);

                    b.Property<int>("PublishStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("timestamp");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Id"), "hash");

                    b.HasIndex("Ordinal")
                        .IsUnique();

                    b.ToTable("EventStore", "EventNode");
                });
#pragma warning restore 612, 618
        }
    }
}

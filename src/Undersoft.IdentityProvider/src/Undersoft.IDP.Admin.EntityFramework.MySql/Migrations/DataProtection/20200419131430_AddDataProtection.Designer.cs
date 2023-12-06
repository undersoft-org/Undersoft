﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Undersoft.IDP.Admin.EntityFramework.Shared.DbContexts;

namespace Undersoft.IDP.Admin.EntityFramework.MySql.Migrations.DataProtection
{
    [DbContext(typeof(IdentityServerDataProtectionDbContext))]
    [Migration("20200419131430_AddDataProtection")]
    partial class AddDataProtection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FriendlyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Xml")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });
#pragma warning restore 612, 618
        }
    }
}

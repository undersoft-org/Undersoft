﻿using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Undersoft.SSC.Service.Infrastructure.Stores.Migrations.Entries
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Local");

            migrationBuilder.EnsureSchema(
                name: "Relation");

            migrationBuilder.EnsureSchema(
                name: "Identifier");

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: false),
                    Document = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Infrastructures",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infrastructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infrastructures_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platforms_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    DefaultId = table.Column<long>(type: "bigint", nullable: false),
                    Document = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Continent = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Local",
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Local",
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityAndActivity",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAndActivity", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivityAndActivity_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAndActivity_Activities_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityIdentifiers_Activities_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationAndApplication",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationAndApplication", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ApplicationAndApplication_Applications_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationAndApplication_Applications_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identifier<Application>",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier<Application>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifier<Application>_Applications_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndDetails_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ApplicationsAndDetails_Applications_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailAndDetail",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailAndDetail", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_DetailAndDetail_Details_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailAndDetail_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailIdentifiers_Details_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_EquipmentAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentAndDetails_Equipment_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAndEquipment",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAndEquipment", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_EquipmentAndEquipment_Equipment_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentAndEquipment_Equipment_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentIdentifiers_Equipment_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureAndInfrastructure",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureAndInfrastructure", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_InfrastructureAndInfrastructure_Infrastructures_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureAndInfrastructure_Infrastructures_RightEntity~",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureIdentifiers_Infrastructures_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructuresAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructuresAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndDetails_Infrastructures_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsAndMembers",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsAndMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ApplicationsAndMembers_Applications_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsAndMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAndMembers",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAndMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_EquipmentAndMembers_Equipment_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentAndMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructuresAndMembers",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructuresAndMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndMembers_Infrastructures_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberAndMember",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAndMember", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MemberAndMember_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberAndMember_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberIdentifiers_Members_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembersAndActivities",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAndActivities", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersAndActivities_Activities_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAndActivities_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAndDetails_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformAndPlatform",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformAndPlatform", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PlatformAndPlatform_Platforms_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformAndPlatform_Platforms_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformIdentifiers_Platforms_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PlatformsAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsAndDetails_Platforms_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsAndMembers",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsAndMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PlatformsAndMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsAndMembers_Platforms_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndResources",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesAndResources", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndResources_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndResources_Resources_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersAndResources",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAndResources", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersAndResources_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAndResources_Resources_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceAndResource",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceAndResource", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ResourceAndResource_Resources_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceAndResource_Resources_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceIdentifiers_Resources_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourcesAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcesAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ResourcesAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcesAndDetails_Resources_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersAndSchedules",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAndSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersAndSchedules_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAndSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourcesAndSchedules",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcesAndSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ResourcesAndSchedules_Resources_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcesAndSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleAndSchedule",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAndSchedule", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ScheduleAndSchedule_Schedules_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleAndSchedule_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleIdentifiers_Schedules_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesAndActivities",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesAndActivities", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SchedulesAndActivities_Activities_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulesAndActivities_Schedules_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SchedulesAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulesAndDetails_Schedules_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsAndServices",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsAndServices", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ApplicationsAndServices_Applications_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsAndServices_Services_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identifier<Service>",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifier<Service>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identifier<Service>_Services_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureService",
                schema: "Local",
                columns: table => new
                {
                    InfrastructuresId = table.Column<long>(type: "bigint", nullable: false),
                    ServicesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureService", x => new { x.InfrastructuresId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_InfrastructureService_Infrastructures_InfrastructuresId",
                        column: x => x.InfrastructuresId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LocaleType = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Notices = table.Column<string>(type: "text", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    PlatformId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    ResourceId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true),
                    ServiceId = table.Column<long>(type: "bigint", nullable: true),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: true),
                    InfrastructureId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Activities_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Applications_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Equipment_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Infrastructures_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Members_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Platforms_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Resources_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Schedules_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Services_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceAndService",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAndService", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServiceAndService_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceAndService_Services_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndDetails",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServicesAndDetails_Details_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesAndDetails_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndEquipment",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndEquipment", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServicesAndEquipment_Equipment_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesAndEquipment_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndMembers",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndMembers", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServicesAndMembers_Members_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesAndMembers_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndPlatforms",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndPlatforms", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServicesAndPlatforms_Platforms_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesAndPlatforms_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndSettings_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ApplicationsAndSettings_Applications_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_EquipmentAndSettings_Equipment_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructuresAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructuresAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndSettings_Infrastructures_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Infrastructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructuresAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembersAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_MembersAndSettings_Members_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_PlatformsAndSettings_Platforms_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedFromAndRelatedTo",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedFromAndRelatedTo", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_RelatedFromAndRelatedTo_Settings_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedFromAndRelatedTo_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourcesAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcesAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ResourcesAndSettings_Resources_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcesAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulesAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SchedulesAndSettings_Schedules_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulesAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesAndSettings",
                schema: "Relation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    RightEntityId = table.Column<long>(type: "bigint", nullable: false),
                    LeftEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ServicesAndSettings_Services_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingIdentifiers",
                schema: "Identifier",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Key = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingIdentifiers_Settings_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryStates",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StateCode = table.Column<string>(type: "text", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryStates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Local",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Place = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Width = table.Column<int>(type: "integer", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: true),
                    X = table.Column<int>(type: "integer", nullable: true),
                    Y = table.Column<int>(type: "integer", nullable: true),
                    Z = table.Column<int>(type: "integer", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Latitue = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    Altitude = table.Column<double>(type: "double precision", nullable: true),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    Block = table.Column<int>(type: "integer", nullable: false),
                    Sector = table.Column<int>(type: "integer", nullable: false),
                    Cluster = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Endpoints",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Host = table.Column<string>(type: "text", nullable: true),
                    IP = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: true),
                    URI = table.Column<string>(type: "text", nullable: true),
                    OS = table.Column<string>(type: "text", nullable: true),
                    Protocol = table.Column<string>(type: "text", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: true),
                    Parameters = table.Column<string[]>(type: "text[]", nullable: true),
                    Return = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoints_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Local",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginKey = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    OriginName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    Ordinal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    CityName = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    StreetName = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    BuildingNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    ApartmentNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Postcode = table.Column<string>(type: "varchar", maxLength: 12, nullable: false),
                    Notices = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    AddressType = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    CountryStateId = table.Column<long>(type: "bigint", nullable: true),
                    Place = table.Column<int>(type: "integer", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Local",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_CountryStates_CountryStateId",
                        column: x => x.CountryStateId,
                        principalSchema: "Local",
                        principalTable: "CountryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DefaultId",
                schema: "Local",
                table: "Activities",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Ordinal",
                schema: "Local",
                table: "Activities",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndDetails_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndResources_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndResources",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndSettings_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAndActivity_RightEntityId",
                schema: "Relation",
                table: "ActivityAndActivity",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityIdentifiers_Key",
                schema: "Identifier",
                table: "ActivityIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ActivityIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "Local",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryStateId",
                schema: "Local",
                table: "Addresses",
                column: "CountryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocationId",
                schema: "Local",
                table: "Addresses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationAndApplication_RightEntityId",
                schema: "Relation",
                table: "ApplicationAndApplication",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_DefaultId",
                schema: "Local",
                table: "Applications",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Ordinal",
                schema: "Local",
                table: "Applications",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAndDetails_RightEntityId",
                schema: "Relation",
                table: "ApplicationsAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAndMembers_RightEntityId",
                schema: "Relation",
                table: "ApplicationsAndMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAndServices_RightEntityId",
                schema: "Relation",
                table: "ApplicationsAndServices",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsAndSettings_RightEntityId",
                schema: "Relation",
                table: "ApplicationsAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_LocationId",
                schema: "Local",
                table: "Coordinates",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                schema: "Local",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                schema: "Local",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryStates_CountryId",
                schema: "Local",
                table: "CountryStates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Defaults_Ordinal",
                schema: "Local",
                table: "Defaults",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailAndDetail_RightEntityId",
                schema: "Relation",
                table: "DetailAndDetail",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIdentifiers_Key",
                schema: "Identifier",
                table: "DetailIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIdentifiers_ObjectId",
                schema: "Identifier",
                table: "DetailIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_DefaultId",
                schema: "Local",
                table: "Details",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_Ordinal",
                schema: "Local",
                table: "Details",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endpoints_LocationId",
                schema: "Local",
                table: "Endpoints",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DefaultId",
                schema: "Local",
                table: "Equipment",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Ordinal",
                schema: "Local",
                table: "Equipment",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndDetails_RightEntityId",
                schema: "Relation",
                table: "EquipmentAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndEquipment_RightEntityId",
                schema: "Relation",
                table: "EquipmentAndEquipment",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndMembers_RightEntityId",
                schema: "Relation",
                table: "EquipmentAndMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndSettings_RightEntityId",
                schema: "Relation",
                table: "EquipmentAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentIdentifiers_Key",
                schema: "Identifier",
                table: "EquipmentIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentIdentifiers_ObjectId",
                schema: "Identifier",
                table: "EquipmentIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifier<Application>_ObjectId",
                table: "Identifier<Application>",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Identifier<Service>_ObjectId",
                table: "Identifier<Service>",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureAndInfrastructure_RightEntityId",
                schema: "Relation",
                table: "InfrastructureAndInfrastructure",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureIdentifiers_Key",
                schema: "Identifier",
                table: "InfrastructureIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureIdentifiers_ObjectId",
                schema: "Identifier",
                table: "InfrastructureIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Infrastructures_DefaultId",
                schema: "Local",
                table: "Infrastructures",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Infrastructures_Ordinal",
                schema: "Local",
                table: "Infrastructures",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructuresAndDetails_RightEntityId",
                schema: "Relation",
                table: "InfrastructuresAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructuresAndMembers_RightEntityId",
                schema: "Relation",
                table: "InfrastructuresAndMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructuresAndSettings_RightEntityId",
                schema: "Relation",
                table: "InfrastructuresAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureService_ServicesId",
                schema: "Local",
                table: "InfrastructureService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationId",
                schema: "Local",
                table: "Locations",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberAndMember_RightEntityId",
                schema: "Relation",
                table: "MemberAndMember",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentifiers_Key",
                schema: "Identifier",
                table: "MemberIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_MemberIdentifiers_ObjectId",
                schema: "Identifier",
                table: "MemberIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DefaultId",
                schema: "Local",
                table: "Members",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_Ordinal",
                schema: "Local",
                table: "Members",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembersAndActivities_RightEntityId",
                schema: "Relation",
                table: "MembersAndActivities",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAndDetails_RightEntityId",
                schema: "Relation",
                table: "MembersAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAndResources_RightEntityId",
                schema: "Relation",
                table: "MembersAndResources",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAndSchedules_RightEntityId",
                schema: "Relation",
                table: "MembersAndSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersAndSettings_RightEntityId",
                schema: "Relation",
                table: "MembersAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformAndPlatform_RightEntityId",
                schema: "Relation",
                table: "PlatformAndPlatform",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformIdentifiers_Key",
                schema: "Identifier",
                table: "PlatformIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformIdentifiers_ObjectId",
                schema: "Identifier",
                table: "PlatformIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_DefaultId",
                schema: "Local",
                table: "Platforms",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Ordinal",
                schema: "Local",
                table: "Platforms",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsAndDetails_RightEntityId",
                schema: "Relation",
                table: "PlatformsAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsAndMembers_RightEntityId",
                schema: "Relation",
                table: "PlatformsAndMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsAndSettings_RightEntityId",
                schema: "Relation",
                table: "PlatformsAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedFromAndRelatedTo_RightEntityId",
                schema: "Relation",
                table: "RelatedFromAndRelatedTo",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceAndResource_RightEntityId",
                schema: "Relation",
                table: "ResourceAndResource",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceIdentifiers_Key",
                schema: "Identifier",
                table: "ResourceIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ResourceIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_DefaultId",
                schema: "Local",
                table: "Resources",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Ordinal",
                schema: "Local",
                table: "Resources",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcesAndDetails_RightEntityId",
                schema: "Relation",
                table: "ResourcesAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcesAndSchedules_RightEntityId",
                schema: "Relation",
                table: "ResourcesAndSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcesAndSettings_RightEntityId",
                schema: "Relation",
                table: "ResourcesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAndSchedule_RightEntityId",
                schema: "Relation",
                table: "ScheduleAndSchedule",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleIdentifiers_Key",
                schema: "Identifier",
                table: "ScheduleIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ScheduleIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DefaultId",
                schema: "Local",
                table: "Schedules",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Ordinal",
                schema: "Local",
                table: "Schedules",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndActivities_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndActivities",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndDetails_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndSettings_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAndService_RightEntityId",
                schema: "Relation",
                table: "ServiceAndService",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DefaultId",
                schema: "Local",
                table: "Services",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Ordinal",
                schema: "Local",
                table: "Services",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAndDetails_RightEntityId",
                schema: "Relation",
                table: "ServicesAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAndEquipment_RightEntityId",
                schema: "Relation",
                table: "ServicesAndEquipment",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAndMembers_RightEntityId",
                schema: "Relation",
                table: "ServicesAndMembers",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAndPlatforms_RightEntityId",
                schema: "Relation",
                table: "ServicesAndPlatforms",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesAndSettings_RightEntityId",
                schema: "Relation",
                table: "ServicesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingIdentifiers_Key",
                schema: "Identifier",
                table: "SettingIdentifiers",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_SettingIdentifiers_ObjectId",
                schema: "Identifier",
                table: "SettingIdentifiers",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DefaultId",
                schema: "Local",
                table: "Settings",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Ordinal",
                schema: "Local",
                table: "Settings",
                column: "Ordinal",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndResources",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivityAndActivity",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivityIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "ApplicationAndApplication",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ApplicationsAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ApplicationsAndMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ApplicationsAndServices",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ApplicationsAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "Coordinates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "DetailAndDetail",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "DetailIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "Endpoints",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "EquipmentAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "EquipmentAndEquipment",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "EquipmentAndMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "EquipmentAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "EquipmentIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "Identifier<Application>");

            migrationBuilder.DropTable(
                name: "Identifier<Service>");

            migrationBuilder.DropTable(
                name: "InfrastructureAndInfrastructure",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "InfrastructureIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "InfrastructuresAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "InfrastructuresAndMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "InfrastructuresAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "InfrastructureService",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "MemberAndMember",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MemberIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "MembersAndActivities",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersAndResources",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "MembersAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PlatformAndPlatform",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PlatformIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "PlatformsAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PlatformsAndMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "PlatformsAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "RelatedFromAndRelatedTo",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourceAndResource",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourceIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "ResourcesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourcesAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourcesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ScheduleAndSchedule",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ScheduleIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "SchedulesAndActivities",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SchedulesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SchedulesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServiceAndService",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServicesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServicesAndEquipment",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServicesAndMembers",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServicesAndPlatforms",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ServicesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SettingIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "CountryStates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Details",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Equipment",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Infrastructures",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Platforms",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "Local");
        }
    }
}

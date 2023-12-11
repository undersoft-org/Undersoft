using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Migrations.ServiceReports
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identifier");

            migrationBuilder.EnsureSchema(
                name: "Local");

            migrationBuilder.EnsureSchema(
                name: "Relation");

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
                name: "DetailNodes",
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
                    Document = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    Kind = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailNodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
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
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
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
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Defaults_DefaultId",
                        column: x => x.DefaultId,
                        principalSchema: "Local",
                        principalTable: "Defaults",
                        principalColumn: "Id");
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
                    Path = table.Column<string>(type: "text", nullable: true),
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
                    DefaultId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<JsonDocument>(type: "jsonb", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true),
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
                        principalColumn: "Id");
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
                        name: "FK_DetailIdentifiers_DetailNodes_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsAndDetails",
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
                    table.PrimaryKey("PK_DetailsAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_DetailsAndDetails_DetailNodes_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsAndDetails_DetailNodes_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
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
                        name: "FK_Countries_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountIdentifiers",
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
                    table.PrimaryKey("PK_AccountIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountIdentifiers_Accounts_ObjectId",
                        column: x => x.ObjectId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountsAndAccounts",
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
                    table.PrimaryKey("PK_AccountsAndAccounts", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AccountsAndAccounts_Accounts_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsAndAccounts_Accounts_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountsAndDetails",
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
                    table.PrimaryKey("PK_AccountsAndDetails", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AccountsAndDetails_Accounts_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsAndDetails_DetailNodes_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndAccounts",
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
                    table.PrimaryKey("PK_ActivitiesAndAccounts", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndAccounts_Accounts_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndAccounts_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndActivities",
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
                    table.PrimaryKey("PK_ActivitiesAndActivities", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndActivities_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndActivities_Activities_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
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
                        name: "FK_ActivitiesAndDetails_DetailNodes_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
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
                name: "AccountsAndResources",
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
                    table.PrimaryKey("PK_AccountsAndResources", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AccountsAndResources_Accounts_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsAndResources_Resources_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
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
                        name: "FK_ResourcesAndDetails_DetailNodes_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
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
                name: "ResourcesAndResources",
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
                    table.PrimaryKey("PK_ResourcesAndResources", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ResourcesAndResources_Resources_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourcesAndResources_Resources_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountsAndSchedules",
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
                    table.PrimaryKey("PK_AccountsAndSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AccountsAndSchedules_Accounts_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsAndSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesAndSchedules",
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
                    table.PrimaryKey("PK_ActivitiesAndSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_ActivitiesAndSchedules_Activities_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitiesAndSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
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
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    ResourceId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Accounts_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_Activities_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Local",
                        principalTable: "Activities",
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
                        name: "FK_SchedulesAndDetails_DetailNodes_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "DetailNodes",
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
                name: "SchedulesAndSchedules",
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
                    table.PrimaryKey("PK_SchedulesAndSchedules", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SchedulesAndSchedules_Schedules_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulesAndSchedules_Schedules_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountsAndSettings",
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
                    table.PrimaryKey("PK_AccountsAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_AccountsAndSettings_Accounts_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
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
                name: "SettingsAndSettings",
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
                    table.PrimaryKey("PK_SettingsAndSettings", x => new { x.LeftEntityId, x.RightEntityId });
                    table.ForeignKey(
                        name: "FK_SettingsAndSettings_Settings_LeftEntityId",
                        column: x => x.LeftEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettingsAndSettings_Settings_RightEntityId",
                        column: x => x.RightEntityId,
                        principalSchema: "Local",
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Endpoint",
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
                    LocationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endpoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endpoint_Locations_LocationId",
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
                name: "IX_AccountIdentifiers_Key",
                schema: "Identifier",
                table: "AccountIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_AccountIdentifiers_ObjectId",
                schema: "Identifier",
                table: "AccountIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DefaultId",
                schema: "Local",
                table: "Accounts",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Id",
                schema: "Local",
                table: "Accounts",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Ordinal",
                schema: "Local",
                table: "Accounts",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountsAndAccounts_RightEntityId",
                schema: "Relation",
                table: "AccountsAndAccounts",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsAndDetails_RightEntityId",
                schema: "Relation",
                table: "AccountsAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsAndResources_RightEntityId",
                schema: "Relation",
                table: "AccountsAndResources",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsAndSchedules_RightEntityId",
                schema: "Relation",
                table: "AccountsAndSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsAndSettings_RightEntityId",
                schema: "Relation",
                table: "AccountsAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DefaultId",
                schema: "Local",
                table: "Activities",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Id",
                schema: "Local",
                table: "Activities",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Ordinal",
                schema: "Local",
                table: "Activities",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndAccounts_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndAccounts",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndActivities_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndActivities",
                column: "RightEntityId");

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
                name: "IX_ActivitiesAndSchedules_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesAndSettings_RightEntityId",
                schema: "Relation",
                table: "ActivitiesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityIdentifiers_Key",
                schema: "Identifier",
                table: "ActivityIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ActivityIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

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
                name: "IX_Defaults_Id",
                schema: "Local",
                table: "Defaults",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Defaults_Ordinal",
                schema: "Local",
                table: "Defaults",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailIdentifiers_Key",
                schema: "Identifier",
                table: "DetailIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIdentifiers_ObjectId",
                schema: "Identifier",
                table: "DetailIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_DetailNodes_Id",
                schema: "Local",
                table: "DetailNodes",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_DetailNodes_Ordinal",
                schema: "Local",
                table: "DetailNodes",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailsAndDetails_RightEntityId",
                schema: "Relation",
                table: "DetailsAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Endpoint_LocationId",
                table: "Endpoint",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationId",
                schema: "Local",
                table: "Locations",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceIdentifiers_Key",
                schema: "Identifier",
                table: "ResourceIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ResourceIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_DefaultId",
                schema: "Local",
                table: "Resources",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Id",
                schema: "Local",
                table: "Resources",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

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
                name: "IX_ResourcesAndResources_RightEntityId",
                schema: "Relation",
                table: "ResourcesAndResources",
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
                name: "IX_ScheduleIdentifiers_Key",
                schema: "Identifier",
                table: "ScheduleIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleIdentifiers_ObjectId",
                schema: "Identifier",
                table: "ScheduleIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DefaultId",
                schema: "Local",
                table: "Schedules",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Id",
                schema: "Local",
                table: "Schedules",
                column: "Id")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Ordinal",
                schema: "Local",
                table: "Schedules",
                column: "Ordinal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndDetails_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndDetails",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndSchedules_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndSchedules",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulesAndSettings_RightEntityId",
                schema: "Relation",
                table: "SchedulesAndSettings",
                column: "RightEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingIdentifiers_Key",
                schema: "Identifier",
                table: "SettingIdentifiers",
                column: "Key")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_SettingIdentifiers_ObjectId",
                schema: "Identifier",
                table: "SettingIdentifiers",
                column: "ObjectId")
                .Annotation("Npgsql:IndexMethod", "hash");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DefaultId",
                schema: "Local",
                table: "Settings",
                column: "DefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsAndSettings_RightEntityId",
                schema: "Relation",
                table: "SettingsAndSettings",
                column: "RightEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "AccountsAndAccounts",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AccountsAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AccountsAndResources",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AccountsAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "AccountsAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndAccounts",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndActivities",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndResources",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivitiesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ActivityIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "DetailIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "DetailsAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "Endpoint");

            migrationBuilder.DropTable(
                name: "ResourceIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "ResourcesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourcesAndResources",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourcesAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ResourcesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "ScheduleIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "SchedulesAndDetails",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SchedulesAndSchedules",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SchedulesAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "SettingIdentifiers",
                schema: "Identifier");

            migrationBuilder.DropTable(
                name: "SettingsAndSettings",
                schema: "Relation");

            migrationBuilder.DropTable(
                name: "CountryStates",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "DetailNodes",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Local");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "Local");
        }
    }
}

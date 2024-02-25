using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Undersoft.SSC.Service.Infrastructure.Stores.Migrations.Accounts
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountRoleId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_AccountRoleId",
                        column: x => x.AccountRoleId,
                        principalSchema: "Accounts",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Accounts",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountClaims",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountConsents",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    TermsText = table.Column<string>(type: "text", nullable: true),
                    TermsConsent = table.Column<bool>(type: "boolean", nullable: false),
                    PersonalDataText = table.Column<string>(type: "text", nullable: true),
                    PersonalDataConsent = table.Column<bool>(type: "boolean", nullable: false),
                    MarketingText = table.Column<string>(type: "text", nullable: true),
                    MarketingConsent = table.Column<bool>(type: "boolean", nullable: false),
                    ThirdPartyText = table.Column<string>(type: "text", nullable: true),
                    ThirdPartyConsent = table.Column<bool>(type: "boolean", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConsents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountLogins",
                schema: "Accounts",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AccountOrganizations",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    StreetName = table.Column<string>(type: "text", nullable: true),
                    BuildingNumber = table.Column<string>(type: "text", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    Websites = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountPayments",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    CardType = table.Column<string>(type: "text", nullable: true),
                    Expiration = table.Column<string>(type: "text", nullable: true),
                    CSV = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    TermsConsent = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Provider = table.Column<string>(type: "text", nullable: true),
                    Websites = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountPersonals",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    CityName = table.Column<string>(type: "text", nullable: true),
                    StreetName = table.Column<string>(type: "text", nullable: true),
                    BuildingNumber = table.Column<string>(type: "text", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    Websites = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPersonals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountProffesionals",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Proffesion = table.Column<string>(type: "text", nullable: true),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    SocialMedia = table.Column<string>(type: "text", nullable: true),
                    Websites = table.Column<string>(type: "text", nullable: true),
                    Years = table.Column<float>(type: "real", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProffesionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                schema: "Accounts",
                columns: table => new
                {
                    AccountsId = table.Column<long>(type: "bigint", nullable: false),
                    RolesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => new { x.AccountsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AccountRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "Accounts",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                schema: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AccountRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Accounts",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PersonalId = table.Column<long>(type: "bigint", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Authenticated = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountPersonals_PersonalId",
                        column: x => x.PersonalId,
                        principalSchema: "Accounts",
                        principalTable: "AccountPersonals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountSubscriptions",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    OriginId = table.Column<int>(type: "integer", nullable: false),
                    CodeNo = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    TypeName = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Modified = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Modifier = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Creator = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    SharedServiceCenter = table.Column<string>(type: "text", nullable: true),
                    ApplicationServer = table.Column<string>(type: "text", nullable: true),
                    ServiceApplication = table.Column<string>(type: "text", nullable: true),
                    ServiceServer = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSubscriptions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounts",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountUsers",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsLockedOut = table.Column<bool>(type: "boolean", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUsers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounts",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountTokens",
                schema: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AccountTokens_AccountUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "AccountUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounts",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountClaims_UserId",
                schema: "Accounts",
                table: "AccountClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountConsents_AccountId",
                schema: "Accounts",
                table: "AccountConsents",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLogins_UserId",
                schema: "Accounts",
                table: "AccountLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOrganizations_AccountId",
                schema: "Accounts",
                table: "AccountOrganizations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPayments_AccountId",
                schema: "Accounts",
                table: "AccountPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPersonals_AccountId",
                schema: "Accounts",
                table: "AccountPersonals",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountProffesionals_AccountId",
                schema: "Accounts",
                table: "AccountProffesionals",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RolesId",
                schema: "Accounts",
                table: "AccountRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_RoleId",
                schema: "Accounts",
                table: "AccountRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonalId",
                schema: "Accounts",
                table: "Accounts",
                column: "PersonalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                schema: "Accounts",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubscriptions_AccountId",
                schema: "Accounts",
                table: "AccountSubscriptions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTokens_AccountId",
                schema: "Accounts",
                table: "AccountTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Accounts",
                table: "AccountUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUsers_AccountId",
                schema: "Accounts",
                table: "AccountUsers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Accounts",
                table: "AccountUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_AccountRoleId",
                schema: "Accounts",
                table: "RoleClaims",
                column: "AccountRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Accounts",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Accounts",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountClaims_AccountUsers_UserId",
                schema: "Accounts",
                table: "AccountClaims",
                column: "UserId",
                principalSchema: "Accounts",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountConsents_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountConsents",
                column: "AccountId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLogins_AccountUsers_UserId",
                schema: "Accounts",
                table: "AccountLogins",
                column: "UserId",
                principalSchema: "Accounts",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOrganizations_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountOrganizations",
                column: "AccountId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPayments_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountPayments",
                column: "AccountId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountPersonals_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountPersonals",
                column: "AccountId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProffesionals_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountProffesionals",
                column: "AccountId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Accounts_AccountsId",
                schema: "Accounts",
                table: "AccountRole",
                column: "AccountsId",
                principalSchema: "Accounts",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_AccountUsers_UserId",
                schema: "Accounts",
                table: "AccountRoles",
                column: "UserId",
                principalSchema: "Accounts",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountUsers_UserId",
                schema: "Accounts",
                table: "Accounts",
                column: "UserId",
                principalSchema: "Accounts",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountUsers_UserId",
                schema: "Accounts",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountPersonals_Accounts_AccountId",
                schema: "Accounts",
                table: "AccountPersonals");

            migrationBuilder.DropTable(
                name: "AccountClaims",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountConsents",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountLogins",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountOrganizations",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountPayments",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountProffesionals",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRole",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountRoles",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountSubscriptions",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTokens",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountUsers",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountPersonals",
                schema: "Accounts");
        }
    }
}

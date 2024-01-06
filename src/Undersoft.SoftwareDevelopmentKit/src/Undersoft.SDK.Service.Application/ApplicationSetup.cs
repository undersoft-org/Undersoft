using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Undersoft.SDK.Service.Application;

using DataServer;
using Documentation;
using Account;
using Account.Email;
using Service.Data.Store;
using Undersoft.SDK.Service.Application.Account.Identity;
using OpenTelemetry;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public partial class ApplicationSetup : ServiceSetup, IApplicationSetup
{
    protected IMvcBuilder mvc;

    public ApplicationSetup(IServiceCollection services, IMvcBuilder mvcBuilder = null)
        : base(services)
    {
        if (mvcBuilder != null)
            mvc = mvcBuilder;
        else
            mvc = services.AddControllers();

        registry.MergeServices(services);
    }

    public ApplicationSetup(IServiceCollection services, IConfiguration configuration)
        : base(services, configuration)
    {
        mvc = services.AddControllers();
        registry.MergeServices(services);
    }

    public IApplicationSetup AddDataServer<TServiceStore>(
        DataServerTypes dataServerTypes,
        Action<DataServerBuilder> builder = null
    ) where TServiceStore : IDataServiceStore
    {
        DataServerBuilder.ServiceTypes = dataServerTypes;
        if ((dataServerTypes & DataServerTypes.OData) > 0)
        {
            var ds = new OpenDataServerBuilder<TServiceStore>();
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
            ds.AddODataServicer(mvc);
        }
        if ((dataServerTypes & DataServerTypes.Grpc) > 0)
        {
            var ds = new GrpcDataServerBuilder<TServiceStore>();
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
            ds.AddGrpcServicer();
        }
        if ((dataServerTypes & DataServerTypes.Rest) > 0)
        {
            var ds = new RestDataServerBuilder<TServiceStore>();
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
        }

        registry.MergeServices(true);
        return this;
    }

    public override IServiceSetup AddSourceProviderConfiguration()
    {
        registry.AddObject<ISourceProviderConfiguration>(
            new ApplicationSourceProviderConfiguration()
        );

        return this;
    }

    public IServiceSetup AddHealthChecks()
    {
        services.AddHealthChecks();
        return this;
    }

    public IApplicationSetup AddAccountIdentity<TContext>() where TContext : DbContext
    {
        registry.Services
            .AddIdentity<IdentityUser<long>, IdentityRole<long>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Tokens.ProviderMap.Add(
                    "AccountEmailConfirmationTokenProvider",
                    new TokenProviderDescriptor(
                        typeof(AccountEmailConfirmationTokenProvider<IdentityUser>)
                    )
                );
                options.Tokens.EmailConfirmationTokenProvider =
                    "AccountEmailConfirmationTokenProvider";
                options.Tokens.ProviderMap.Add(
                    "AccountPasswordResetTokenProvider",
                    new TokenProviderDescriptor(
                        typeof(AccountPasswordResetTokenProvider<IdentityUser>)
                    )
                );
                options.Tokens.PasswordResetTokenProvider = "AccountPasswordResetTokenProvider";
                options.Tokens.ProviderMap.Add(
                    "AccountChangeEmailTokenProvider",
                    new TokenProviderDescriptor(
                        typeof(AccountChangeEmailTokenProvider<IdentityUser>)
                    )
                );
                options.Tokens.ChangeEmailTokenProvider = "AccountChangeEmailTokenProvider";
                options.Tokens.ProviderMap.Add(
                    "AccountRegistrationProcessTokenProvider",
                    new TokenProviderDescriptor(
                        typeof(AccountRegistrationProcessTokenProvider<IdentityUser>)
                    )
                );
                options.Tokens.ChangePhoneNumberTokenProvider =
                    "AccountRegistrationProcessTokenProvider";
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TContext>();
        registry.Configure<DataProtectionTokenProviderOptions>(
            o => o.TokenLifespan = TimeSpan.FromHours(3)
        );

        registry.AddTransient<AccountEmailConfirmationTokenProvider<IdentityUser>>();
        registry.AddTransient<AccountPasswordResetTokenProvider<IdentityUser>>();
        registry.AddTransient<AccountChangeEmailTokenProvider<IdentityUser>>();
        registry.AddTransient<AccountRegistrationProcessTokenProvider<IdentityUser>>();

        AddIdentityAuthentication();
        AddIdentityAuthorization();

        registry.AddScoped<IAccountIdentityManager, AccountIdentityManager>();
        registry.AddScoped<AuthorizationService>();
        registry.AddTransient<IEmailSender, AccountEmailSender>();
        registry.Configure<AccountEmailSenderOptions>(configuration);

        return this;
    }

    public IApplicationSetup AddIdentityAuthentication()
    {
        var jwtOptions = new AccountIdentityJWTOptions();
        var jwtFactory = new AccountIdentityJWTGenerator(30, jwtOptions);

        registry.AddObject(jwtFactory);

        registry.Services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtOptions.SecurityKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        return this;
    }

    public IApplicationSetup AddIdentityAuthorization()
    {
        var ic = configuration.Identity;

        registry.Services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            ic.Scopes.ForEach(s => options.AddPolicy(s, policy => policy.RequireClaim("scope", s)));

            ic.Roles.ForEach(s => options.AddPolicy(s, policy => policy.RequireRole(s)));

            ic.Claims.ForEach(s => options.AddPolicy(s, policy => policy.RequireClaim(s)));
        });

        return this;
    }

    public IApplicationSetup AddSwagger()
    {
        string ver = configuration.Version;
        var ao = configuration.Identity;
        registry.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                ao.ApiVersion,
                new OpenApiInfo { Title = ao.ApiName, Version = ao.ApiVersion }
            );
            options.OperationFilter<SwaggerJsonIgnoreFilter>();
            options.DocumentFilter<IgnoreApiDocument>();

            options.AddSecurityDefinition(
                "oauth2",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri($"{ao.BaseUrl}/connect")
                        }
                    }
                }
            );
            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });
        return this;
    }

    public IApplicationSetup AddApiVersions(string[] apiVersions)
    {
        this.apiVersions = apiVersions;
        return this;
    }

    public IApplicationSetup ConfigureApplication(
        bool includeSwagger = true,
        Assembly[] assemblies = null,
        Type[] sourceTypes = null,
        Type[] clientTypes = null
    )
    {
        Assemblies ??= assemblies ??= AppDomain.CurrentDomain.GetAssemblies();

        base.ConfigureServices(Assemblies, sourceTypes, clientTypes)
            .Services.AddHttpContextAccessor();

        AddApplicationSetupInternalImplementations(Assemblies);
        AddApplicationSetupInternalActionImplementations(Assemblies);
        AddApplicationSetupRemoteImplementations(Assemblies);
        AddApplicationSetupRemoteActionImplementations(Assemblies);

        if (includeSwagger)
            AddSwagger();

        Services.MergeServices();

        return this;
    }

    public IApplicationSetup UseDataServices()
    {
        this.LoadOpenDataEdms().ConfigureAwait(true);
        return this;
    }
}

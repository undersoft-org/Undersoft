﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Undersoft.SDK.Service.Server;

using Accounts.Email;
using Accounts;
using Documentation;
using Infrastructure.Repository.Source;
using Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;

public partial class ServerSetup : ServiceSetup, IServerSetup
{
    protected IMvcBuilder mvc;

    public ServerSetup(IServiceCollection services, IMvcBuilder mvcBuilder = null)
        : base(services)
    {
        if (mvcBuilder != null)
            mvc = mvcBuilder;
        else
            mvc = services.AddControllers();

        registry.MergeServices(services);
    }

    public ServerSetup(IServiceCollection services, IConfiguration configuration)
        : base(services, configuration)
    {
        mvc = services.AddControllers();
        registry.MergeServices(services);
    }

    public IServerSetup AddDataServer<TServiceStore>(
        DataServerTypes dataServerTypes,
        Action<DataServerBuilder> builder = null
    ) where TServiceStore : IDataStore
    {
        DataServerBuilder.ServiceTypes = dataServerTypes;
        if ((dataServerTypes & DataServerTypes.OData) > 0)
        {
            var ds = new OpenDataServerBuilder<TServiceStore>(registry);
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
            ds.AddODataServicer(mvc);
        }
        if ((dataServerTypes & DataServerTypes.Grpc) > 0)
        {
            var ds = new GrpcDataServerBuilder<TServiceStore>(registry);
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
            ds.AddGrpcServicer();
        }
        if ((dataServerTypes & DataServerTypes.Rest) > 0)
        {
            var ds = new RestDataServerBuilder<TServiceStore>(registry);
            if (builder != null)
                builder.Invoke(ds);
            ds.Build();
        }

        registry.MergeServices(true);
        return this;
    }

    public override IServiceSetup AddSourceProviderConfiguration()
    {
        var sspc = new ServerSourceProviderConfiguration(manager.Registry);
        registry.AddObject<ISourceProviderConfiguration>(sspc);
        ServiceManager.AddRootObject<ISourceProviderConfiguration>(sspc);

        return this;
    }

    public IServiceSetup AddHealthChecks()
    {
        services.AddHealthChecks();
        return this;
    }

    public IServerSetup AddAccountServer<TContext>() where TContext : DbContext
    {
        registry.Services
            .AddIdentity<AccountUser, Role>(options =>
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

        registry.AddScoped<IAccountManager, AccountManager>();
        registry.AddScoped<AccountService>();
        registry.AddTransient<IEmailSender, AccountEmailSender>();
        registry.Configure<AccountEmailSenderOptions>(configuration);

        return this;
    }

    public IServerSetup AddIdentityAuthentication()
    {
        var jwtOptions = new AccountTokenOptions();
        var jwtFactory = new AccountTokenGenerator(30, jwtOptions);

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

    public IServerSetup AddIdentityAuthorization()
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

    public IServerSetup AddSwagger()
    {
        string ver = configuration.Version;
        var ao = configuration.Identity;
        registry.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                ao.ServiceVersion,
                new OpenApiInfo { Title = ao.ServiceName, Version = ao.ServiceVersion }
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
                            TokenUrl = new Uri($"{ao.ServerBaseUrl}/data/open/Authorization/Signin")
                        }
                    }
                }
            );
            options.OperationFilter<AuthorizeCheckOperationFilter>();
        });
        return this;
    }

    public IServerSetup AddApiVersions(string[] apiVersions)
    {
        this.apiVersions = apiVersions;
        return this;
    }

    public IServerSetup ConfigureServer(
        bool includeSwagger = true,
        Assembly[] assemblies = null,
        Type[] sourceTypes = null,
        Type[] clientTypes = null
    )
    {
        base.ConfigureServices(sourceTypes, clientTypes)
            .Services.AddHttpContextAccessor();

        AddServerSetupInternalImplementations();
        AddServerSetupInternalActionImplementations();
        AddServerSetupRemoteImplementations();
        AddServerSetupRemoteActionImplementations();

        if (includeSwagger)
            AddSwagger();

        Services.MergeServices();

        return this;
    }

    public IServerSetup UseDataServices()
    {
        this.LoadOpenDataEdms().ConfigureAwait(true);
        return this;
    }
}

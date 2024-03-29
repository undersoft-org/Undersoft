﻿using FluentValidation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Reflection;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.Access;
using Undersoft.SDK.Service.Application.GUI.View.Abstraction;
using Undersoft.SDK.Service.Application.GUI.View.Models;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SSC.Service.Application.GUI.Compound.Access;
using Undersoft.SSC.Service.Clients;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Hybrid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var stream = Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(
                $"Undersoft.SSC.Service.Application.Hybrid."
                    + (
                        (DeviceInfo.Platform == DevicePlatform.Android)
                            ? "appsettings.android.json"
                            : "appsettings.json"
                    )
            );
        var config =
            (stream != null) ? new ConfigurationBuilder().AddJsonStream(stream).Build() : null;

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();

        builder.Services.AddFluentUIComponents();

        if (config != null)
            builder.Configuration.AddConfiguration(config);

        var manager = builder.Services
            .AddServiceSetup(config)
            .ConfigureServices(new[] { typeof(ApplicationClient), typeof(AccessClient) })
            .Manager;

        _ = manager
            .BuildInternalProvider()
            .UseServiceClientsAsync();

        builder.ConfigureContainer(
            manager.GetProviderFactory(),
            (services) =>
            {
                var reg = manager.GetRegistry();
                reg.AddMauiBlazorWebView();
                reg.AddAuthorizationCore()
                    .AddFluentUIComponents((o) => o.UseTooltipServiceProvider = true)
                    .AddSingleton<AppearanceState>()
                    .AddScoped<IRemoteRepository<IAccountStore, Account>, RemoteRepository<IAccountStore, Account>>()
                    .AddScoped<AccessProvider<Account>>()
                    .AddScoped<AuthenticationStateProvider, AccessProvider<Account>>(sp => sp.GetRequiredService<AccessProvider<Account>>())
                    .AddScoped<IAccountAccess, AccessProvider<Account>>(sp => sp.GetRequiredService<AccessProvider<Account>>())
                    .AddScoped<IAccountService<Account>, AccessProvider<Account>>(sp => sp.GetRequiredService<AccessProvider<Account>>())
                    .AddScoped<IValidator<IViewData<Credentials>>, AccessValidator>()
                    .AddScoped<IValidator<IViewData<Account>>, AccountValidator>()
                    .AddScoped<AccountValidator>()
                    .AddScoped<AccessValidator>();
                reg.MergeServices(services, true);
            }
        );

        var host = builder.Build();
        manager.ReplaceProvider(host.Services);
        return host;
    }
}

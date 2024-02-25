﻿using Microsoft.AspNetCore.Components.Routing;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Reflection;
using System.Text.Json;
using Undersoft.SDK.Service.Application.Extensions;
using Undersoft.SDK.Service.Application.GUI.Models;
using Undersoft.SDK.Updating;

namespace Undersoft.SDK.Service.Application.GUI.Generic;

public partial class GenericLayout : LayoutComponentBase
{
    private const string JAVASCRIPT_FILE =
        "./_content/Undersoft.SDK.Service.Application.GUI/Generic/GenericLayout.razor.js";
    public string? Version;
    public bool IsDarkMode;
    public bool IsDevice;
    protected bool _mobile;
    protected string? _prevUri;
    private GenericPageContents? _toc;
    private bool _menuChecked = true;
    private readonly string APPEARANCEKEY = "APPEARANCEKEY";

    [Parameter]
    public string? Color { get; set; } = default!;

    public DesignThemeModes Mode { get; set; }

    [Parameter]
    public int? Density { get; set; } = 0;

    [Parameter]
    public int? ControlCornerRadius { get; set; } = 3;

    [Parameter]
    public int? LayerCornerRadius { get; set; } = 5;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    public IJSRuntime JS { get; set; } = default!;

    [Inject]
    private AppearanceState AppearanceState { get; set; } = default!;

    [Inject]
    private GlobalState GlobalState { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (!AppearanceState.IsLoaded)
        {
            var appearanceState = await JS.GetFromLocalStorage(APPEARANCEKEY);
            if (appearanceState != null)
                AppearanceState.PatchFromJson<AppearanceState, AppearanceState>(appearanceState);
            else
                await JS.SetInLocalStorage(APPEARANCEKEY, this.PatchTo(AppearanceState).ToJsonString());
        }
        AppearanceState.IsLoaded = true;
        Mode = AppearanceState.IsDarkMode ? DesignThemeModes.Dark : DesignThemeModes.Light;
        Color = AppearanceState.Color;
        Density = AppearanceState.Density;
        ControlCornerRadius = AppearanceState.ControlCornerRadius;
        LayerCornerRadius = AppearanceState.LayerCornerRadius;

        var versionAttribute = Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>();

        if (versionAttribute != null)
        {
            var version = versionAttribute.InformationalVersion.Split('+')[0];
            AppearanceState.Version = version;
        }

        _prevUri = NavigationManager.Uri;
        NavigationManager.LocationChanged += LocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var jsModule = await JS.InvokeAsync<IJSObjectReference>(
                "import",
                JAVASCRIPT_FILE
            );
            AppearanceState.IsDevice = _mobile = await jsModule.InvokeAsync<bool>("isDevice");
            await jsModule.DisposeAsync();
        }
    }

    public EventCallback OnRefreshTableOfContents =>
        EventCallback.Factory.Create(this, RefreshTableOfContentsAsync);

    private async Task RefreshTableOfContentsAsync()
    {
        await _toc!.RefreshAsync();
    }

    private void HandleChecked()
    {
        _menuChecked = !_menuChecked;
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        if (
            !e.IsNavigationIntercepted
            && new Uri(_prevUri!).AbsolutePath != new Uri(e.Location).AbsolutePath
        )
        {
            _prevUri = e.Location;
            if (_mobile && _menuChecked == true)
            {
                _menuChecked = false;
                StateHasChanged();
            }
        }
    }
}

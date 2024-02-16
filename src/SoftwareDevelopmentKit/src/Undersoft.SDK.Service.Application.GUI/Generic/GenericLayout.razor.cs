using Microsoft.AspNetCore.Components.Routing;
using System.Reflection;
using Undersoft.SDK.Service.Application.GUI.Models;

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

    [Parameter]
    public string Color { get; set; } = "#194d6d";

    [Parameter]
    public int? Density { get; set; } = 1;

    [Parameter]
    public int? ControlCornerRadius { get; set; } = 3;

    [Parameter]
    public int? LayerCornerRadius { get; set; } = 5;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    private AppearanceState AppearanceState { get; set; } = default!;

    protected override void OnInitialized()
    {
        AppearanceState = new AppearanceState()
        {
            Color = Color,
            Density = Density,
            ControlCornerRadius = ControlCornerRadius,
            LayerCornerRadius = LayerCornerRadius
        };
        var versionAttribute = Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (versionAttribute != null)
        {
            var version = versionAttribute.InformationalVersion;
            var plusIndex = version.IndexOf('+');
            if (plusIndex >= 0 && plusIndex + 9 < version.Length)
            {
                AppearanceState.Version = version[..(plusIndex + 9)];
            }
            else
            {
                AppearanceState.Version = version;
            }
        }

        _prevUri = NavigationManager.Uri;
        NavigationManager.LocationChanged += LocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>(
                "import",
                JAVASCRIPT_FILE
            );
            AppearanceState.IsDevice = _mobile = await jsModule.InvokeAsync<bool>("isDevice");
            AppearanceState.IsDarkMode = await jsModule.InvokeAsync<bool>("isDarkMode");
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

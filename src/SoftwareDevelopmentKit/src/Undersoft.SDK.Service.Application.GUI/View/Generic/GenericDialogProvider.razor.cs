using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View.Generic;

public partial class GenericDialogProvider : FluentDialogProvider
{
    [Inject]
    public IDialogService DialogService { get; set; } = default!;

    public GenericDialogProvider() : base()
    {
    }

    protected override void OnInitialized()
    {

        base.OnInitialized();
    }
}

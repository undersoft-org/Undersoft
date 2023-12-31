﻿namespace Undersoft.SDK.Blazor.Components;

public partial class BootstrapInputGroup
{
    private string? ClassString => CssBuilder.Default("Input-group")
        .AddClassFromAttributes(AdditionalAttributes)
        .Build();

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}

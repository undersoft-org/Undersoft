using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.Models;

public class AppearanceState : ViewwModel
{
    public LocalizationDirection Dir { get; set; } = LocalizationDirection.LeftToRight;
    public StandardLuminance Luminance { get; set; } = StandardLuminance.LightMode;

    public ElementReference Container { get; set; } = default!;

    public string? Color { get; set; }

    public event Action? OnChange;

    public void SetDirection(LocalizationDirection dir)
    {
        Dir = dir;
        NotifyStateHasChanged();
    }

    public void SetLuminance(StandardLuminance luminance)
    {
        Luminance = luminance;
        NotifyStateHasChanged();
    }

    public void SetContainer(ElementReference container)
    {
        Container = container;
        NotifyStateHasChanged();
    }

    public void SetColor(string? color)
    {
        Color = color;
        NotifyStateHasChanged();
    }

    private void NotifyStateHasChanged()
    {
        OnChange?.Invoke();
    }


}

using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Security;

namespace Undersoft.SSC.Service.Application.UI.Compound;

public class AccessDialog<TDialog, TModel> where TDialog : IDialogContentComponent<TModel> where TModel : class, IOrigin, IInnerProxy
{
    [Inject]
    public IDialogService? DialogService { get; private set; }

    [Inject]
    public IJSRuntime? JS { get; private set; }

    public TModel? Data { get; private set; }

    public async Task Show(TModel data, AccessKind command, params string[] allowedList)
    {
        if (allowedList != null && allowedList.Any())
            data.Proxy.Rubrics.ForOnly(r => allowedList.Contains(r.RubricName), r => r.Visible = true).Commit();

        if (DialogService != null)
        {
            var dialog = await DialogService.ShowDialogAsync<TDialog>(data, new DialogParameters()
            {
                Height = "500px",
                Title = $"{command.ToString()} the {data.Label.ToLower()}",
                PreventDismissOnOverlayClick = true,
                ShowDismiss = false,
                PreventScroll = true,
                OnDialogClosing = EventCallback.Factory.Create<DialogInstance>(this, async (instance) =>
                {
                    if (JS != null)
                    {
                        await JS.InvokeVoidAsync("eval", $@"
                        async function func() {{
                            let dialog = document.getElementById('{instance.Id}')?.dialog;
                            if (!dialog) return;
                            dialog.style.opacity = '0.0';
                            let animation = dialog.animate([
                                {{ opacity: '1', transform: '' }},
                                {{ opacity: '0', transform: 'translateX(-100%)' }}
                            ], {{
                                duration: 2000,
                            }});
                            return animation.finished; // promise that resolves when the animation is complete or interrupted
                        }};
                        func();
                    ");
                    }
                }),
                OnDialogOpened = EventCallback.Factory.Create<DialogInstance>(this, async (instance) =>
                {
                    if (JS != null)
                    {
                        await JS.InvokeVoidAsync("eval", $@"
                        async function func() {{
                            let dialog = document.getElementById('{instance.Id}')?.dialog;
                            if (!dialog) return;
                            let animation = dialog.animate([
                                {{ opacity: '0', transform: 'translateX(-100%)' }},
                                {{ opacity: '1', transform: '' }},
                            ], {{
                                duration: 2000,
                            }});
                            return animation.finished; // promise that resolves when the animation is complete or interrupted
                        }};
                        func();
                    ");
                    }
                }),

            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Data = (TModel)result.Data;
            }
        }
    }
}

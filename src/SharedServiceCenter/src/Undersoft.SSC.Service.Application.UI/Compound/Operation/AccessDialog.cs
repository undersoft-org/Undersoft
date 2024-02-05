using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;

namespace Undersoft.SSC.Service.Application.UI.Compound;

public class AccessDialog<TDialog, TModel> where TDialog : IDialogContentComponent<TModel> where TModel : class, IOrigin, IInnerProxy
{
    public AccessDialog(IDialogService dialogService, IJSRuntime jS)
    {
        DialogService = dialogService;
        JS = jS;
    }

    public IDialogService DialogService { get; private set; }

    public IJSRuntime JS { get; private set; }

    public TModel? Data { get; private set; }

    public async Task Show(TModel data, string title, params string[] allowedList)
    {
        if (allowedList != null && allowedList.Any())
            data.Proxy.Rubrics.ForOnly(r => allowedList.Contains(r.RubricName), r => r.Visible = true).Commit();

        if (DialogService != null)
        {
            var dialog = await DialogService.ShowDialogAsync<TDialog>(data, new DialogParameters()
            {
                Width = "25%",
                Title = title,
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
                                duration: 1000,
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
                                duration: 1000,
                            }});
                            return animation.finished; // promise that resolves when the animation is complete or interrupted
                        }};
                        func();
                    ");
                    }
                })
            });

            var result = await dialog.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Data = (TModel)result.Data;
            }
        }
    }
}

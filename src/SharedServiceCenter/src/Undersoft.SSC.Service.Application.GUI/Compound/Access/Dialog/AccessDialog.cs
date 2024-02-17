using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Service.Application.GUI.View;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access.Dialog;

public class AccessDialog<TDialog, TModel> : ViewDialog<TDialog, TModel> where TDialog : IDialogContentComponent<IViewData<TModel>> where TModel : class, IOrigin, IInnerProxy
{
    public AccessDialog(IDialogService dialogService, IJSRuntime jS) : base(dialogService)
    {
        JS = jS;
    }

    public IJSRuntime JS { get; private set; }

    public override async Task Show(IViewData<TModel> data)
    {
        if (Service != null)
        {
            Reference = await Service.ShowDialogAsync<TDialog>(data, new DialogParameters<IViewData<TModel>>()
            {
                Height = data.Height,
                Width = data.Width,
                Title = data.Title,
                Content = data,
                PreventDismissOnOverlayClick = true,
                ShowDismiss = false,
                Modal = false,
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
                                {{ opacity: '0', transform: 'translateX(100%)' }}
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

            var result = await Reference.Result;
            if (!result.Cancelled && result.Data != null)
            {
                Content = (IViewData<TModel>)result.Data;
            }
        }
    }
}

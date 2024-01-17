﻿namespace Undersoft.SDK.Service.Application.Components;

public class DialogService : PresenterService<DialogOption>
{
    public Task Show(DialogOption option, Dialog? dialog = null) => Invoke(option, dialog);
}
namespace Undersoft.SDK.Service.Application.Components;

public class PrintService : PresenterService<DialogOption>
{
    public Task PrintAsync(DialogOption option) => Invoke(option);
}

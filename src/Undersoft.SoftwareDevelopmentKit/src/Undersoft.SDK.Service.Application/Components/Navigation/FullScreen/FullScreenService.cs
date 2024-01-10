namespace Undersoft.SDK.Service.Application.Components;

public class FullScreenService : PresenterService<FullScreenOption>
{
    public Task Toggle(FullScreenOption? option = null) => Invoke(option ?? new());
}

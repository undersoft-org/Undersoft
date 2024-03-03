using Undersoft.SDK.Series.Base;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.Application.GUI.View;

public class ViewDelegates : ListingBase<ViewDelegate>
{
}

public class ViewDelegate : DataObject
{
    public string? Name { get; set; }

    public Delegate? Delegate { get; set; }
}
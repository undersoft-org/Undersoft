using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Undersoft.SDK.Service.Data.Entity;
using Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Data.ViewModel;

[DataContract]
[StructLayout(LayoutKind.Sequential)]
public class OpenViewModel<TViewModel, TDetail, TSetting, TGroup> : DataObject, IViewModel
    where TViewModel : IDataObject
    where TDetail : class, IDetail
    where TSetting : class, ISetting
    where TGroup : struct, Enum
{
    public OpenViewModel() : base() { }

    [DataMember(Order = 12)]
    public virtual Identifiers<TViewModel> Identifiers { get; set; }

    [Details]
    [DataMember(Order = 13)]
    public virtual Details<TDetail> Details { get; set; }

    [Settings]
    [DataMember(Order = 14)]
    public virtual Settings<TSetting> Settings { get; set; }

    [DataMember(Order = 15)]
    public virtual TGroup Group { get; set; }
}

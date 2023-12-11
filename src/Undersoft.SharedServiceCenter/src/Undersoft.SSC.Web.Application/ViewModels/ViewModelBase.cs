using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Entity;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;

namespace Undersoft.SSC.Web.Application.ViewModels;

[DataContract]
public class ViewModelBase<TViewModel, TDetail, TSetting, TGroup>
    : OpenViewModel<TViewModel, TDetail, TSetting, TGroup>
    where TViewModel : class, IDataObject
    where TDetail : class, IDetail, new()
    where TSetting : class, ISetting, new()
    where TGroup : struct, Enum
{
    public ViewModelBase() : base() { }

    [DataMember(Order = 16)]
    public long? DefaultId { get; set; }

    [DataMember(Order = 17)]
    public long? LocationId { get; set; }
}

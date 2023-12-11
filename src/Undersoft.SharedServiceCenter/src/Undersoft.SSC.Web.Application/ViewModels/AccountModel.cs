using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Data.ViewModel;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Application.ViewModels;

[DataContract]
public class AccountModel : ViewModelBase<AccountModel, Detail, Setting, AccountGroup>
{
    [DataMember(Order = 18)]
    public virtual DataObjects<AccountModel>? RelatedFrom { get; set; }

    [DataMember(Order = 19)]
    public virtual DataObjects<AccountModel>? RelatedTo { get; set; }

    [DataMember(Order = 21)]
    public virtual DataObjects<ResourceBase>? Resources { get; set; }

    [DataMember(Order = 23)]
    public virtual Default? Default { get; set; }

    [DataMember(Order = 24)]
    public virtual Location? Location { get; set; }
}

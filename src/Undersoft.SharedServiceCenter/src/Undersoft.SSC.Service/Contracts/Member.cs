using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SSC.Service.Contracts.Details;
using Undersoft.SSC.Service.Contracts.Settings;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Member : Account
{
    [Detail]
    public IdentityDetail? Identity { get; set; }

    [Setting]
    public ProfileSetting? Profile { get; set; }

    [Detail]
    public CompanyDetail? Company { get; set; }

    [Detail]
    public DataObjects<EmployeeDetail>? Employees { get; set; }
}



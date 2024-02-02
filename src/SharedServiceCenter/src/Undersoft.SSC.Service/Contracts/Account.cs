using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Undersoft.SDK;
using Undersoft.SDK.Security;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Microsoft.OData;
using Microsoft.OData.ModelBuilder;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Account : Authorization, IContract
{
    [AutoExpand]
    [DataMember(Order = 12)]
    public AccountUser? User { get; set; }

    [AutoExpand]
    [DataMember(Order = 13)]
    public ObjectSet<Role>? Roles { get; set; }

    [AutoExpand]
    [DataMember(Order = 14)]
    public ObjectSet<Claim>? Claims { get; set; }

    [DataMember(Order = 15)]
    public ObjectSet<Token>? Tokens { get; set; }

}

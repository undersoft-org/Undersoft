using System.Runtime.Serialization;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Contracts;

[DataContract]
public class Projection : Account
{
    [Detail]
    public DataObjects<CostDetail>? Costs { get; set; }

    [Detail]
    public DataObjects<RevenueDetail>? Revenues { get; set; }
}



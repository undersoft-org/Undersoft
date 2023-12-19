using System.Runtime.Serialization;
using Undersoft.SDK.Serialization;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Enums;

namespace Undersoft.SSC.Web.Contracts;

[DataContract]
public class Detail : ObjectDetail<Detail, DetailKind>, ISerializableObject, IDetail, IContract
{
    public Detail() : base() { }

    public Detail(DetailKind kind) : base(kind) { }
}

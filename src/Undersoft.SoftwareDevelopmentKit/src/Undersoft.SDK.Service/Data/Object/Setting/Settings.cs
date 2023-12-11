using System.Collections.ObjectModel;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SDK.Service.Data.Object.Setting;

public class Settings<TDto> : Details<TDto> where TDto : class, ISetting
{

}

using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Contracts.Details;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Web.Appllication.ViewModels;

public class RegistrationtActivity : Activity, IViewModel
{
    [Detail]
    public RegistrationDetail? Registration { get; set; }
}

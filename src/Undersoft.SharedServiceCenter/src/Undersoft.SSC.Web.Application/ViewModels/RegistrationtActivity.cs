using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Contracts.Details;

namespace Undersoft.SSC.Web.Application.ViewModels;

public class RegistrationtActivity : Activity, IViewModel
{
    [Detail]
    public RegistrationDetail? Registration { get; set; }
}

using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Service.Contracts;
using Undersoft.SSC.Service.Contracts.Details;

namespace Undersoft.SSC.Service.Application.Models;

public class ResponseActivity : Activity, IModel
{
    [Detail]
    public RegistrationDetail? Registration { get; set; }
}

using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.Models;

public class RequestActivity : Account, IModel
{
    public RequestActivity() { Group = AccountGroup.Servicer; }

}

using IdentityModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Security;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.Extensions;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;
using Claim = System.Security.Claims.Claim;

namespace Undersoft.SDK.Service.Application.Access;

public class AccessState : AuthenticationState
{
    public AccessState(ClaimsPrincipal user) : base(user)
    {
    }
}

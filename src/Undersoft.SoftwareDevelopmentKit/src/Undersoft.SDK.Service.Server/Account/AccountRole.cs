using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Undersoft.SDK.Logging;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;
using System.Security.Claims;

namespace Undersoft.SDK.Service.Application.Account;

public class AccountRole<TKey> : UniqueIdentifiable where TKey : IEquatable<TKey>
{
    public IdentityRole<TKey> Info { get; set; } = new IdentityRole<TKey>();

    public Claim Role => new Claim("role", Info.Name);

    public Registry<AccountRoleClaim<TKey>> Claims { get; set; }
}

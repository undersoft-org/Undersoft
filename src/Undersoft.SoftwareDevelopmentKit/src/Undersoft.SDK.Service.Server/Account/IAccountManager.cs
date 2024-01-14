using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Application.Account
{
    public interface IAccountManager
    {
        IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long> Context { get; set; }
        RoleManager<IdentityRole<long>> Role { get; set; }
        SignInManager<IdentityUser<long>> SignIn { get; set; }
        AccountTokenGenerator Token { get; set; }
        UserManager<IdentityUser<long>> User { get; set; }

        Task<Account> CheckPassword(string email, string password);
        Task<bool> CheckToken(string token);
        Task<string> RenewToken(string token);
        Task<bool> Delete(string email);
        Task<Account> GetByEmail(string email);
        Task<Account> GetById(long id);
        Task<Account> GetByName(string name);
        Task<string> GetToken(string email, string password);
        string GetToken(IAuthorization account);
        Task<IdentityRole<long>> SetRole(string roleName);
        Task<bool> SetRoleClaim(string roleName, Claim claim);
        Task<Account> SetUser(string username, string email, string password, IEnumerable<string> roles, IEnumerable<string> scopes = null);
        Task<bool> SetUserClaim(string email, Claim claim);
        AccountRole<long> SetUserRole(string email, string current, string previous = null);
        bool TryGetByEmail(string email, out IAccount<long> account);
        bool TryGetById(long id, out IAccount<long> account);
        Task<Account> MapAccount(Account account);

    }
}
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Server.Accounts
{
    public interface IAccountManager
    {
        RoleManager<Role> Role { get; set; }
        SignInManager<AccountUser> SignIn { get; set; }
        AccountTokenGenerator Token { get; set; }
        UserManager<AccountUser> User { get; set; }

        Task<Account> CheckPassword(string email, string password);
        Task<bool> CheckToken(string token);
        Task<string> RenewToken(string token);
        Task<bool> Delete(string email);
        Task<Account> GetByEmail(string email);
        Task<Account> GetById(long id);
        Task<Account> GetByName(string name);
        Task<string> GetToken(string email, string password);
        string GetToken(IAuthorization account);
        Task<Role> SetRole(string roleName);
        Task<bool> SetRoleClaim(string roleName, Claim claim);
        Task<Account> SetUser(string username, string email, string password, IEnumerable<string> roles, IEnumerable<string> scopes = null);
        Task<bool> SetUserClaim(string email, Claim claim);
        Role SetUserRole(string email, string current, string previous = null);
        bool TryGetByEmail(string email, out IAccount account);
        bool TryGetById(long id, out IAccount account);
        Task<Account> MapAccount(Account account);

    }
}
﻿using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Server.Account;

public class AccountCredentials : Credentials
{
    public AccountCredentials() { }

    public void MapUser(IdentityUser<long> account)
    {
        UserName = account.UserName;
        Email = account.Email;
        PhoneNumber = account.PhoneNumber;
        EmailConfirmed = account.EmailConfirmed;
        PhoneNumberConfirmed = account.PhoneNumberConfirmed;
        AccessFailedCount = account.AccessFailedCount;
        NormalizedUserName = account.NormalizedUserName;
    }
}

﻿using IdentityModel;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.Service.Application.Services;

public class AccountAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateService
{
    private readonly IJSRuntime js;
    private readonly IAuthorization _authorization;
    private readonly IRemoteRepository<IAccountStore, Authorization> _repository;
    private readonly string TOKENKEY = "TOKENKEY";
    private readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";

    private AuthenticationState Anonymous =>
        new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public AccountAuthenticationStateProvider(
        IJSRuntime js,
        IRemoteRepository<IAccountStore, Authorization> repository,
        IAuthorization authorization
    )
    {
        this.js = js;
        this._repository = repository;
        _authorization = authorization;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await js.GetFromLocalStorage(TOKENKEY);

        if (string.IsNullOrEmpty(token))
        {
            return Anonymous;
        }

        var expirationTimeString = await js.GetFromLocalStorage(EXPIRATIONTOKENKEY);
        DateTime expirationTime;

        if (DateTime.TryParse(expirationTimeString, out expirationTime))
        {
            if (IsTokenExpired(expirationTime))
            {
                await CleanUp();
                return Anonymous;
            }
            if (IsTokenExpired(expirationTime.AddMinutes(-5)))
            {
                var auth = (await _repository.Function("Renew", new Argument("Authorization", token)));
                if (auth != null)
                {
                    _authorization.Credentials = auth.Credentials;
                    token = auth.Credentials.SessionToken;
                }
                if (token == null)
                    return Anonymous;
            }
        }

        return BuildAuthenticationState(token);
    }

    public AuthenticationState BuildAuthenticationState(string token)
    {
        _authorization.Credentials.SessionToken = token;
        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"))
        );
    }

    private ISeries<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new Registry<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);

        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        if (keyValuePairs != null)
            keyValuePairs.ForEach(kvp =>
            {
                claims.Add(kvp.Key, new Claim(kvp.Key, kvp.Value.ToString() ?? ""));
            });

        if (claims.TryGet(JwtClaimTypes.Expiration, out Claim expiration))
            js.SetInLocalStorage(EXPIRATIONTOKENKEY, expiration.Value);

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }
        return Convert.FromBase64String(base64);
    }

    private bool IsTokenExpired(DateTime expirationTime)
    {
        return expirationTime <= DateTime.UtcNow;
    }

    public async Task SignIn(Authorization authorization)
    {
        _authorization.Credentials = authorization.Credentials;
        await js.SetInLocalStorage(TOKENKEY, _authorization.Credentials.SessionToken);
        var authState = BuildAuthenticationState(_authorization.Credentials.SessionToken);
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    public async Task SignOut()
    {
        var arg = new Arguments();
        arg.Put(new Argument("Authorization", _authorization));
        await _repository.Action("SignOut", arg);
        await CleanUp();
        NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
    }

    private async Task CleanUp()
    {
        await js.RemoveItem(TOKENKEY);
        await js.RemoveItem(EXPIRATIONTOKENKEY);
        _authorization.Credentials.SessionToken = null;
        _authorization.Credentials = null;
        _repository.Context.SetSecurityString(null);
    }
}

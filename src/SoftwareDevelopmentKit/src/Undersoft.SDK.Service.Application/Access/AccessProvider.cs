﻿using IdentityModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Security;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Application.Extensions;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using Claim = System.Security.Claims.Claim;

namespace Undersoft.SDK.Service.Application.Access;

public class AccessProvider<TAccount> : AuthenticationStateProvider, IAccountAccess
    where TAccount : class, IAuthorization
{
    private readonly IJSRuntime js;
    private readonly IAuthorization _authorization;
    private readonly IRemoteRepository<IAccountStore, TAccount> _repository;
    private readonly string TOKENKEY = "TOKENKEY";
    private readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";

    private AuthenticationState Anonymous =>
        new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public AccessProvider(
        IJSRuntime js,
        IRemoteRepository<IAccountStore, TAccount> repository,
        IAuthorization authorization
    )
    {
        this.js = js;
        _repository = repository;
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
                var auth = await Renew(
                    new Authorization() { Credentials = new Credentials() { SessionToken = token } }
                );

                if (auth != null)
                {
                    _authorization.Credentials = auth.Credentials;
                    token = auth.Credentials.SessionToken;
                }
                if (token == null)
                    return Anonymous;
            }
        }

        return GetAccessState(token);
    }

    public AccessState GetAccessState(string token)
    {
        _authorization.Credentials.SessionToken = token;
        return new AccessState(new ClaimsPrincipal(new ClaimsIdentity(GetTokenClaims(token), "jwt")));
    }

    private ISeries<Claim> GetTokenClaims(string jwt)
    {
        var claims = new Registry<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = GetJsonToken(payload);

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

    private byte[] GetJsonToken(string base64)
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

    public async Task<IAuthorization?> SignIn(IAuthorization auth)
    {
        var _auth = (
            await _repository.Access(nameof(SignIn), auth)
        );

        if (_auth == null)
            return null;

        _authorization.Credentials = _auth.Credentials;
        if (_auth.Credentials.SessionToken != null)
        {
            await js.SetInLocalStorage(TOKENKEY, _authorization.Credentials.SessionToken);
            var authState = GetAccessState(_authorization.Credentials.SessionToken);
            NotifyAuthenticationStateChanged(Task.FromResult((AuthenticationState)authState));
        }
        return _auth;
    }

    public async Task<IAuthorization> SignUp(IAuthorization auth)
    {
        return await _repository.Access(nameof(SignUp), auth);
    }

    public async Task<IAuthorization> SignOut(IAuthorization auth)
    {
        var _auth = await _repository.Access(nameof(SignOut), auth);
      
        await CleanUp();
        NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        return _auth;
    }

    public async Task<IAuthorization?> Renew(IAuthorization auth)
    {
        var _auth = await _repository.Access(nameof(Renew), auth);

        if (_auth == null)
            return null;

        _authorization.Credentials = _auth.Credentials;
        if (_auth.Credentials.SessionToken != null)
        {
            await js.SetInLocalStorage(TOKENKEY, _authorization.Credentials.SessionToken);
            var authState = GetAccessState(_authorization.Credentials.SessionToken);
            NotifyAuthenticationStateChanged(Task.FromResult((AuthenticationState)authState));
        }
        return _auth;
    }

    private async Task CleanUp()
    {
        await js.RemoveItem(TOKENKEY);
        await js.RemoveItem(EXPIRATIONTOKENKEY);
        _authorization.Credentials.SessionToken = null;
        _authorization.Credentials = null;
        _repository.Context.SetAuthorizationHeader(null);
    }
}

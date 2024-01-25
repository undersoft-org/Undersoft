using IdentityModel;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Security;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Series;
using Claim = System.Security.Claims.Claim;

namespace Undersoft.SDK.Service.Application.Services;

public class AccountAuthenticationStateProvider
    : AuthenticationStateProvider,
        IAuthenticationStateService
{
    private readonly IJSRuntime js;
    private readonly IAuthorization _authorization;
    private readonly IRemoteRepository<IAccountStore, Account> _repository;
    private readonly string TOKENKEY = "TOKENKEY";
    private readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";

    private AuthenticationState Anonymous =>
        new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public AccountAuthenticationStateProvider(
        IJSRuntime js,
        IRemoteRepository<IAccountStore, Account> repository,
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
                var auth = (
                    await _repository.Access("Renew", new Arguments("Account", token))
                ).FirstOrDefault();
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

    public async Task SignIn(IAuthorization authorization)
    {
        var auth = (
            await _repository.Access<IAccountAccess>(
                a => a.SignIn,
                new Arguments("Account", authorization)
            )
        ).FirstOrDefault();
        
        if (auth == null)
            return;        
        
        _authorization.Credentials = auth.Credentials;
        await js.SetInLocalStorage(TOKENKEY, _authorization.Credentials.SessionToken);
        var authState = BuildAuthenticationState(_authorization.Credentials.SessionToken);
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    public async Task SignUp(IAuthorization authorization)
    {
        await _repository.Access<IAccountAccess>(
            a => a.SignUp,
            new Arguments("Account", authorization)
        );
    }

    public async Task SignOut()
    {
        await _repository.Access<IAccountAccess>(
            a => a.SignOut,
            new Arguments("Account", _authorization)
        );
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

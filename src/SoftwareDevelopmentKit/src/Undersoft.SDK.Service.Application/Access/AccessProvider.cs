using IdentityModel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;
using Undersoft.SDK.Series;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.Extensions;
using Undersoft.SDK.Service.Data.Remote.Repository;
using Undersoft.SDK.Service.Data.Store;
using Claim = System.Security.Claims.Claim;

namespace Undersoft.SDK.Service.Application.Access;

public class AccessProvider<TAccount> : AuthenticationStateProvider, IAccountAccess
    where TAccount : class, IAuthorization
{
    private readonly IJSRuntime js;
    private IAuthorization _authorization;
    private readonly IRemoteRepository<IAccountStore, TAccount> _repository;
    private readonly string TOKENKEY = "TOKENKEY";
    private readonly string EXPIRATIONTOKENKEY = "EXPIRATIONTOKENKEY";
    private readonly string EMAIL = "EMAIL";

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
        var email = await js.GetFromLocalStorage(EMAIL);

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
                    new Authorization() { Credentials = new Credentials() { Email = email, SessionToken = token } }
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
        var token = GetJsonToken(payload);

        var keyValuePairs = token.FromJson<Dictionary<string, object>>();
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
        var result = await _repository.Access(nameof(SignIn), auth);

        if (result == null)
            return null;

        _authorization.Credentials = result.Credentials;
        _authorization.Notes = result.Notes;
        if (result.Credentials.SessionToken != null)
        {
            await js.SetInLocalStorage(TOKENKEY, result.Credentials.SessionToken);
            await js.SetInLocalStorage(EMAIL, result.Credentials.Email);
            var authState = GetAccessState(result.Credentials.SessionToken);
            NotifyAuthenticationStateChanged(Task.FromResult((AuthenticationState)authState));
        }
        return _authorization;
    }

    public async Task<IAuthorization> SignUp(IAuthorization auth)
    {
        var result = await _repository.Access(nameof(SignUp), auth);
        _authorization.Credentials = result.Credentials;
        _authorization.Notes = result.Notes;
        return result;
    }

    public async Task<IAuthorization> SignOut(IAuthorization auth)
    {
        auth.Credentials.Email = await js.GetFromLocalStorage(EMAIL);

        var result = await _repository.Access(nameof(SignOut), auth);

        await CleanUp();
        NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        return result;
    }

    public async Task<IAuthorization?> Renew(IAuthorization auth)
    {
        var result = await _repository.Access(nameof(Renew), auth);

        if (result == null)
            return null;

        _authorization = result;
        if (result.Credentials.SessionToken != null)
        {
            await js.SetInLocalStorage(TOKENKEY, result.Credentials.SessionToken);
            await js.SetInLocalStorage(EMAIL, result.Credentials.Email);
            var authState = GetAccessState(result.Credentials.SessionToken);
            NotifyAuthenticationStateChanged(Task.FromResult((AuthenticationState)authState));
        }
        return _authorization;
    }

    public async Task<IAuthorization?> ResetPassword(IAuthorization auth)
    {
        var result = await _repository.Action(nameof(ResetPassword), auth);

        if (result == null)
            return null;

        return _authorization = result;
    }

    public async Task<IAuthorization?> ChangePassword(IAuthorization auth)
    {
        var result = await _repository.Setup(nameof(ChangePassword), auth);

        if (result == null)
            return null;

        return _authorization = result;
    }

    public IAuthorization? AccountInfo(IAuthorization auth)
    {
        var result = _repository.Access(nameof(AccountInfo), auth);

        if (result == null)
            return null;

        Task.WaitAll(result);

        return _authorization = result.Result;
    }

    public async Task<IAuthorization?> ConfirmEmail(IAuthorization auth)
    {
        var result = await _repository.Action(nameof(ConfirmEmail), auth);

        if (result == null)
            return null;

        return _authorization = result;
    }

    public async Task<IAuthorization?> CompleteRegistration(IAuthorization auth)
    {
        var result = await _repository.Action(nameof(CompleteRegistration), auth);

        if (result == null)
            return null;

        return _authorization = result;
    }

    private async Task CleanUp()
    {
        var auth = _authorization;
        await js.RemoveItem(TOKENKEY);
        await js.RemoveItem(EXPIRATIONTOKENKEY);
        await js.RemoveItem(EMAIL);
        auth.Notes = null;
        auth.Credentials.SessionToken = null;
        auth.Credentials = null;
        _repository.Context.SetAuthorizationHeader(null);
    }
}

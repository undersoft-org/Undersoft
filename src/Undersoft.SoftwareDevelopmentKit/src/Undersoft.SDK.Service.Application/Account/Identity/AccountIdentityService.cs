namespace Undersoft.SDK.Service.Application.Account.Identity;

public class AccountIdentityService
{
    private IServicer _servicer;
    private IAccountIdentityManager _manager;

    public AccountIdentityService(
        IServicer servicer,
        IAccountIdentityManager accountManager
    ) : base()
    {
        _servicer = servicer;
        _manager = accountManager;
    }

    public async Task<IAccountIdentity<long>> SignIn(IAccountIdentity<long> identity)
    {
        var account = await CompleteRegistration(
            await ConfirmEmail(await Authorize(Authenticate(identity)))
        );

        if (account.Authorized)
        {
            account.Credentials.SessionToken = _manager.GetToken(account);
            account.Notes = new AccountIdentityNotes()
            {
                Success = "Signed in",
                Status = SigningStatus.SignedIn
            };
            await _manager.SignIn.SignInWithClaimsAsync(
                account.Info,
                account.Credentials.SaveAccountInCookies,
                account.GetClaims()
            );
        }
        return account;
    }

    public async Task<IAccountIdentity<long>> SignUp(IAccountIdentity<long> identity)
    {
        var _creds = identity.Credentials;
        if (!_manager.TryGetByEmail(_creds.Email, out var account))
            account = await _manager.SetUser(
                _creds.UserName,
                _creds.Email,
                _creds.Password,
                new string[] { "User" }
            );
        await _manager.SignIn.CreateUserPrincipalAsync(account.Info);
        account = await ConfirmEmail(await Authorize(Authenticate(identity)));
        account.Authorized = false;
        return account;
    }

    public async Task<IAccountIdentity<long>> SignOut(IAccountIdentity<long> identity)
    {
        var account = Authenticate(identity);

        if (account.Authenticated)
        {
            var principal = await _manager.SignIn.CreateUserPrincipalAsync(account.Info);
            if (_manager.SignIn.IsSignedIn(principal))
                await _manager.SignIn.SignOutAsync();
            account.Notes = new AccountIdentityNotes()
            {
                Success = "Signed out",
                Status = SigningStatus.SignedOut
            };
        }
        return account;
    }

    public IAccountIdentity<long> Authenticate(IAccountIdentity<long> identity, bool isAuthorized = false)
    {
        var _creds = identity.Credentials;
        if (!_manager.TryGetByEmail(_creds.Email, out var account))
        {
            _creds.Password = null;
            return new AccountIdentity()
            {
                Notes = new AccountIdentityNotes()
                {
                    Errors = "Invalid email",
                    Status = SigningStatus.InvalidEmail
                },
                Credentials = _creds
            };
        }
        account.Credentials.PatchFrom(_creds);
        account.Credentials.PatchFrom(account.Info);
        account.Authenticated = true;
        account.Authorized = isAuthorized;
        return account;
    }

    public async Task<IAccountIdentity<long>> Authorize(IAccountIdentity<long> account)
    {
        if (account != null && account.Authenticated)
        {
            var _creds = account.Credentials;
            account = await _manager.CheckPassword(_creds.Email, _creds.Password);
            if (account == null)
            {
                _creds.Password = null;
                return new AccountIdentity()
                {
                    Notes = new AccountIdentityNotes()
                    {
                        Errors = "Invalid password",
                        Status = SigningStatus.InvalidPassword
                    },
                    Credentials = _creds
                };
            }
            else
            {
                account.Authorized = true;
            }
        }
        account.Credentials.Password = null;
        return account;
    }

    public async Task<IAccountIdentity<long>> ConfirmEmail(IAccountIdentity<long> account)
    {
        if (account != null && account.Authenticated && account.Authorized)
        {
            var _creds = account.Credentials;
            if (!_creds.EmailConfirmed)
            {
                if (_creds.EmailConfirmationToken != null)
                {
                    if (
                        (await _manager.User.ConfirmEmailAsync(
                            account.Info,
                            _creds.EmailConfirmationToken
                        )).Succeeded
                    )
                    {
                        _creds.EmailConfirmationToken = null;
                        _creds.EmailConfirmed = true;
                        account.Authorized = true;
                        account.Notes = new AccountIdentityNotes() { Info = "Email has been confirmed", };
                        return account;
                    }                    
                }
                _creds.EmailConfirmationToken =
                    await _manager.User.GenerateEmailConfirmationTokenAsync(account.Info);
                account.Notes = new AccountIdentityNotes()
                {
                    Info = "Please confirm your email",
                    Status = SigningStatus.EmailNotConfirmed,
                };
                account.Authorized = false;
            }
            else
            {
                account.Notes = new AccountIdentityNotes() { Info = "Email has been confirmed" };
                account.Authorized = true;
            }
        }
        return account;
    }

    public async Task<IAccountIdentity<long>> ResetPassword(IAccountIdentity<long> account)
    {
        if (account != null && account.Authenticated && account.Authorized)
        {
            var _creds = account.Credentials;
            if (_creds.PasswordResetToken != null)
            {
                if (
                    (await _manager.User.ResetPasswordAsync(
                        account.Info,
                        _creds.EmailConfirmationToken,
                        _creds.Password
                    )).Succeeded
                )
                {
                    _creds.PasswordResetToken = null;
                    account.Authorized = true;
                    account.Notes = new AccountIdentityNotes() { Info = "Password has been reset", };
                    return account;
                }
                _creds.PasswordResetToken = null;
            }
            _creds.PasswordResetToken =
                await _manager.User.GeneratePasswordResetTokenAsync(account.Info);
            account.Notes = new AccountIdentityNotes()
            {
                Info = "Please confirm reset password by email",
                Status = SigningStatus.ResetPasswordNotConfirmed,
            };
            account.Authorized = false;
        }
        return (AccountIdentity)account;
    }

    public async Task<IAccountIdentity<long>> CompleteRegistration(
        IAccountIdentity<long> account
    )
    {
        if (
            account != null
            && account.Authenticated
            && account.Authorized
            && account.Credentials.EmailConfirmed
        )
        {
            var _creds = account.Credentials;
            if (!_creds.RegistrationCompleted)
            {
                if (_creds.RegistrationCompleteToken != null)
                {
                    if (
                        await _manager.User.VerifyUserTokenAsync(
                            account.Info,
                            "AccountRegistrationProcessTokenProvider",
                            "Registration",
                            _creds.RegistrationCompleteToken
                        )
                    )
                    {
                        _creds.RegistrationCompleted = true;
                        account.Authorized = true;
                        account.Notes = new AccountIdentityNotes() { Info = "Registration completed", };
                        return account;
                    }
                    _creds.RegistrationCompleteToken = null;
                }
                _creds.RegistrationCompleteToken = await _manager.User.GenerateUserTokenAsync(
                    account.Info,
                    "AccountRegistrationProcessTokenProvider",
                    "Registration"
                );
                account.Notes = new AccountIdentityNotes()
                {
                    Info = "Please complete registration process",
                    Status = SigningStatus.RegistrationNotCompleted
                };
                account.Authorized = false;
            }
            else
                account.Notes = new AccountIdentityNotes() { Info = "Registration completed" };
        }
        return account;
    }
}

public enum SigningStatus
{
    Unsigned,
    Failure,
    Succeed,
    SignedIn,
    SignedOut,
    TryoutsOverlimit,
    InvalidEmail,
    InvalidPassword,
    RegistrationNotCompleted,
    EmailNotConfirmed,
    ResetPasswordNotConfirmed,
    ActionRequired
}
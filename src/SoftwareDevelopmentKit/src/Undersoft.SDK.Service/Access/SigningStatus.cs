namespace Undersoft.SDK.Service.Access
{
    public enum SigningStatus
    {
        Unsigned,
        Failure,
        Succeed,
        SignedIn,
        SignedOut,
        EmailConfirmed,
        TryoutsOverlimit,
        InvalidEmail,
        InvalidPassword,
        RegistrationCompleted,
        RegistrationNotCompleted,
        EmailNotConfirmed,
        ResetPasswordConfirmed,
        ResetPasswordNotConfirmed,
        ActionRequired
    }
}

using System.IdentityModel.Tokens.Jwt;
using Undersoft.SDK.Instant.Updating;

namespace Undersoft.SDK.Security.Identity
{
     [Serializable]
    public class Authorization : Origin, IAuthorization
    {
        public void Map(object user)
        {
            this.PatchFrom(user);
        }

        public ICredentials Credentials { get; set; } = new Credentials();

        public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();
    }

    public class AuthorizationNotes
    {
        public string Errors { get; set; }

        public string Success { get; set; }

        public string Info { get; set; }

        public SigningStatus Status { get; set; }
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
}

using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Updating;

namespace Undersoft.SDK.Security.Identity
{
     [Serializable]
    public class Authorization : Origin, IInnerProxy, IAuthorization
    {
        public void Map(object user)
        {
            this.PatchFrom(user);
        }

        public Credentials Credentials { get; set; } = new Credentials();

        public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();

        IProxy IInnerProxy.Proxy => throw new NotImplementedException();

        object IInnerProxy.this[int fieldId] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IInnerProxy.this[string propertyName] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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

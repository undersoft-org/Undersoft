using Undersoft.SDK;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SSC.Service.Application.Models
{
    [Serializable]
    public class Account : Origin, IInnerProxy, IAuthorization
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
}

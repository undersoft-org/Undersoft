using System.Runtime.Serialization;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Updating;

namespace Undersoft.SDK.Security
{
    [DataContract]
    public class Authorization : Origin, IInnerProxy, IAuthorization
    {
        [DataMember(Order = 16)]
        public Credentials Credentials { get; set; } = new Credentials();

        [DataMember(Order = 17)]
        public AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();

        [DataMember(Order = 18)]
        public bool Authorized { get; set; }

        [DataMember(Order = 19)]
        public bool Authenticated { get; set; }

        public void Map(object user)
        {
            this.PatchFrom(user);
        }

        IProxy IInnerProxy.Proxy => throw new NotImplementedException();

        object IInnerProxy.this[int fieldId] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IInnerProxy.this[string propertyName] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

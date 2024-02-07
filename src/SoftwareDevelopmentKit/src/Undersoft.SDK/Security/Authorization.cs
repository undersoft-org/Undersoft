using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Undersoft.SDK.Instant.Proxies;
using Undersoft.SDK.Instant.Updating;

namespace Undersoft.SDK.Security
{
    [DataContract]
    public class Authorization : InnerProxy, IAuthorization
    {
        [NotMapped]
        [DataMember(Order = 16)]
        public virtual Credentials Credentials { get; set; } = new Credentials();

        [NotMapped]
        [DataMember(Order = 17)]
        public virtual AuthorizationNotes Notes { get; set; } = new AuthorizationNotes();

        [DataMember(Order = 18)]
        public virtual bool IsAvailable { get; set; }

        [DataMember(Order = 19)]
        public virtual bool Authenticated { get; set; }

        public virtual void Map(object user)
        {
            this.PatchFrom(user);
        }
    }
}

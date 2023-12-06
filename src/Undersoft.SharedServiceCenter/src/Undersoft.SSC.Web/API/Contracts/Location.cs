using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.API.Contracts.Locations;

namespace Undersoft.SSC.Web.API.Contracts;

public class Location : DataObject
{
    public virtual string? Name { get; set; }

    public virtual LocaleType LocaleType { get; set; }

    public virtual string? Email { get; set; }

    public virtual PhoneType PhoneType { get; set; }

    public virtual string? PhoneNumber { get; set; }

    public virtual string? Notices { get; set; }

    public virtual string? Website { get; set; }

    public virtual string? SocialMedia { get; set; }

    public virtual DataObjects<Address>? Addresses { get; set; }

    public virtual DataObjects<Endpoint>? Endpoints { get; set; }
}

using Undersoft.SDK.Proxies;

namespace Undersoft.SDK.Service.Access
{
    public interface IAuthorization : IOrigin, IInnerProxy
    {
        Credentials Credentials { get; set; }

        AuthorizationNotes Notes { get; set; }
    }
}
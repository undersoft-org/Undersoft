namespace Undersoft.SDK.Security.Identity
{
    public interface IAuthorization
    {
        ICredentials Credentials { get; set; }

        AuthorizationNotes Notes { get; set; }
    }
}
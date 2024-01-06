namespace Undersoft.SDK.Security.Identity
{
    public interface IAuthorization
    {
        Credentials Credentials { get; set; }

        AuthorizationNotes Notes { get; set; }
    }
}
namespace Undersoft.SDK.Security
{
    public interface IClaim
    {
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
    }
}
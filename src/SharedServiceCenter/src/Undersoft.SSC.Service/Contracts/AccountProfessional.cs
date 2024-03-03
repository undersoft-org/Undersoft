namespace Undersoft.SSC.Service.Contracts;

public class AccountProfessional : DataObject
{
    public string? Title { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Profession { get; set; }

    public string? Industry { get; set; }

    public string? Image { get; set; }

    public string? SocialMedia { get; set; }

    public string? Websites { get; set; }

    public float Experience { get; set; }

    public long? AccountId { get; set; }
}

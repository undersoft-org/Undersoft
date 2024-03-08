namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountProfessional : DataObject
{
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Profession { get; set; }

    public string Industry { get; set; }

    public string SocialMedia { get; set; }

    public string Websites { get; set; }

    public float Experience { get; set; }

    public long? AccountId { get; set; }
    public virtual Account Account { get; set; }
}

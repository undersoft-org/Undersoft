namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountProffesional : DataObject
{
    public string Title { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Proffesion { get; set; }

    public string Industry { get; set; }

    public string Image { get; set; }

    public string SocialMedia { get; set; }

    public string Websites { get; set; }

    public float Years { get; set; }

    public long? AccountId { get; set; }
    public virtual Account Account { get; set; }
}

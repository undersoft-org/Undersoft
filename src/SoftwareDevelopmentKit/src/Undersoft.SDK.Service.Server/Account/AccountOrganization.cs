namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountOrganization : DataObject
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string FullName { get; set; }

    public string Position { get; set; }

    public string Image { get; set; }

    public string Industry { get; set; }

    public long? AccountId { get; set; }
    public virtual Account Account { get; set; }
}

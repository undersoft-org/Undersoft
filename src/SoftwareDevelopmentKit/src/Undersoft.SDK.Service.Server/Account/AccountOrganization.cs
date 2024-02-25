namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountOrganiuzation : DataObject
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string FullName { get; set; }

    public string Position { get; set; }

    public string Image { get; set; }

    public string Industry { get; set; }

    public int Size { get; set; }

    public string Country { get; set; }

    public string State { get; set; }

    public string CityName { get; set; }

    public string StreetName { get; set; }

    public string BuildingNumber { get; set; }

    public string ApartmentNumber { get; set; }

    public string Postcode { get; set; }

    public string SocialMedia { get; set; }

    public string Websites { get; set; }

    public virtual Account Account { get; set; }
}

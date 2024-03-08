namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountAddress : DataObject
{
    public string Country { get; set; }

    public string State { get; set; }

    public string CityName { get; set; }

    public string StreetName { get; set; }

    public string BuildingNumber { get; set; }

    public string ApartmentNumber { get; set; }

    public string Postcode { get; set; }

    public string SocialMedia { get; set; }

    public string Websites { get; set; }

    public long? AccountId { get; set; }
    public virtual Account Account { get; set; }
}

namespace Undersoft.SDK.Service.Server.Accounts;

public class AccountSubscription : DataObject
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime EndDate { get; set; }

    public string SharedServiceCenter { get; set; }

    public string ApplicationServer { get; set; }

    public string ServiceApplication { get; set; }

    public string ServiceServer { get; set; }

    public virtual Account Account { get; set; }
}



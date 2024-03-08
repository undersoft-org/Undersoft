namespace Undersoft.SSC.Service.Contracts;

public class AccountSubscription : DataObject
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime EndDate { get; set; }

    public double Quantity { get; set; }

    public double Value { get; set; }

    public string? Currency { get; set; }

    public long? AccountId { get; set; }
}



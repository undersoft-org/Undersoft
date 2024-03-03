namespace Undersoft.SSC.Service.Contracts;

public class AccountPayment : DataObject
{
    public string? Title { get; set; }

    public string? CardNumber { get; set; }

    public string? CardType { get; set; }

    public string? Expiration { get; set; }

    public string? CSV { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool TermsConsent { get; set; }

    public string? PaymentType { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Image { get; set; }

    public string? Provider { get; set; }

    public string? Websites { get; set; }

    public long? AccountId { get; set; }
}

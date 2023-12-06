namespace Undersoft.SSC.Web.API.Contracts.Details;

public class CompanyDetail : DataObject
{
    public CompanyDetail() { }

    public string? Name { get; set; }

    public string? ShortName { get; set; }

    public string? Description { get; set; }

    public string? TaxId { get; set; }

    public string? CompanySize { get; set; }

    public string? Revenue { get; set; }

    public string? Website { get; set; }

}

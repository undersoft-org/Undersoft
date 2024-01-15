using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts.Details;

[Detail]
public class RequestDetail : DataObject
{
    public RequestDetail() { }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Position { get; set; }

    public bool? Invited { get; set; }
}

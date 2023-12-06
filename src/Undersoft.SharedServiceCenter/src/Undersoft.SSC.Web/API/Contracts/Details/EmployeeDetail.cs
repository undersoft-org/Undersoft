namespace Undersoft.SSC.Web.API.Contracts.Details;

public class EmployeeDetail : DataObject
{
    public EmployeeDetail() { }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Position { get; set; }

    public bool? Invited { get; set; }
}

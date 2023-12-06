namespace Undersoft.SSC.Web.API.Contracts.Details;

public class PersonalDetail : DataObject
{
    public PersonalDetail() { }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? BirthDate { get; set; }

    public string? Age { get; set; }

    public string? Gender { get; set; }

}

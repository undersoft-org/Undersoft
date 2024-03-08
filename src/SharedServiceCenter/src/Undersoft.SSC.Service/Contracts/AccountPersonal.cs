using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SSC.Service.Contracts;

public class AccountPersonal : DataObject
{
    [VisibleRubric]
    public string FirstName { get; set; } = default!;

    [VisibleRubric]
    public string LastName { get; set; } = default!;

    [VisibleRubric]
    public string Email { get; set; } = default!;

    [VisibleRubric]
    public string PhoneNumber { get; set; } = default!;

    [VisibleRubric]
    public DateTime Birthdate { get; set; }

    [VisibleRubric]
    public string Gender { get; set; } = default!;

    [VisibleRubric]
    public string Image { get; set; } = default!;

    public long? AccountId { get; set; }
}

using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SSC.Service.Contracts;

public class AccountAddress : DataObject
{
    [VisibleRubric]
    public string Country { get; set; } = default!;

    [VisibleRubric]
    public string State { get; set; } = default!;

    [VisibleRubric]
    public string CityName { get; set; } = default!;

    [VisibleRubric]
    public string Postcode { get; set; } = default!;

    [VisibleRubric]
    public string StreetName { get; set; } = default!;

    [VisibleRubric]
    public string BuildingNumber { get; set; } = default!;

    [VisibleRubric]
    [RequiredRubric]
    public string ApartmentNumber { get; set; } = default!;

    public long? AccountId { get; set; }
}

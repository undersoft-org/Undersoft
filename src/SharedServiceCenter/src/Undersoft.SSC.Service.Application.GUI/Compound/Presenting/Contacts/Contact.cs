using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Contacts;

public class Contact : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Author")]
    public string Author { get; set; } = "/presenting/contact/author";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Invite")]
    public string Invite { get; set; } = "/presenting/contact/invite";

    [Link]
    [VisibleRubric]
    [DisplayRubric("Donate")]
    public string Donate { get; set; } = "/presenting/contact/donate";
}


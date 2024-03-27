using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Contacts;

public class PresentingContact : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Author")]
    public string Author { get; set; } = "/presenting/contact/author";
    public Icon AuthorIcon = new Icons.Regular.Size20.PenSparkle();

    [Link]
    [VisibleRubric]
    [DisplayRubric("Invite")]
    public string Invite { get; set; } = "/presenting/contact/invite";
    public Icon InviteIcon = new Icons.Regular.Size20.PersonAdd();

    [Link]
    [VisibleRubric]
    [DisplayRubric("Donate")]
    public string Donate { get; set; } = "/presenting/contact/donate";
    public Icon DonateIcon = new Icons.Regular.Size20.MoneyHand();
}


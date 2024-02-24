using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Categories;

public class CategoriesMenu : DataObject
{
    [Link]
    [VisibleRubric]
    public string Overview { get; set; } = "/landing/overwiew";

    [Link]
    [VisibleRubric]
    public string Technology { get; set; } = "/landing/technology";

    [Link]
    [VisibleRubric]
    public string Software { get; set; } = "/landing/software";

    [Link]
    [VisibleRubric]
    public string Advantage { get; set; } = "/landing/advantage";

    [Link]
    [VisibleRubric]
    public string Access { get; set; } = "/landing/access";
}


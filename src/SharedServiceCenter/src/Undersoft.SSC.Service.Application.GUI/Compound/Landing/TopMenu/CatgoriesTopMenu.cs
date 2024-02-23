using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu.Categories;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Landing.TopMenu;

public class CatgoriesTopMenu : DataObject
{
    [VisibleRubric]
    public CategoriesMenu Categories { get; set; } = new CategoriesMenu();
}


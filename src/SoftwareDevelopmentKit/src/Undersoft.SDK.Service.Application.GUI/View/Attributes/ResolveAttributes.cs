using Undersoft.SDK.Invoking;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;
using Undersoft.SDK.Updating;

namespace Undersoft.SDK.Service.Application.GUI.View.Attributes
{
    public static class ViewAttributes
    {
        public static ISeries<IInvoker> Registry;
        private static ViewAttributeResolvers ViewResolveAttributes;

        static ViewAttributes()
        {
            Registry = new Registry<IInvoker>();
            ViewResolveAttributes = new ViewAttributeResolvers();

            Registry.Add(
                typeof(ClassAttribute),
                new Invoker<ViewAttributeResolvers>(
                    ViewResolveAttributes,
                    m => m.ResolveClassAttributes
                )
            );
            Registry.Add(
                typeof(StyleAttribute),
                new Invoker<ViewAttributeResolvers>(
                    ViewResolveAttributes,
                    m => m.ResolveStyleAttributes
                )
            );
            Registry.Add(
                typeof(GridAttribute),
                new Invoker<ViewAttributeResolvers>(
                    ViewResolveAttributes,
                    m => m.ResolveGridAttributes
                )
            );
            Registry.Add(
                typeof(StackAttribute),
                new Invoker<ViewAttributeResolvers>(
                    ViewResolveAttributes,
                    m => m.ResolveStackAttributes
                )
            );
        }

        public static ViewRubric Resolve(ViewRubric mr)
        {

            var mi = ((IMemberRubric)mr.RubricInfo).MemberInfo;

            var customAttributes = mi.GetCustomAttributes(false);

            if (customAttributes.Any())
            {
                var duplicateCheck = new HashSet<string>();

                customAttributes.ForEach(a =>
                {
                    var type = a.GetType();
                    if (
                        ViewAttributes.Registry.TryGet(type, out IInvoker invoker)
                        && duplicateCheck.Add(invoker.MethodName)
                    )
                    {
                        invoker.Invoke(mr);
                    }
                });
            }
            return mr;
        }

    }

    public class ViewAttributeResolvers
    {
        public void ResolveClassAttributes(ViewRubric mr)
        {
            var mi = ((IMemberRubric)mr.RubricInfo).MemberInfo;

            object? o = mi.GetCustomAttributes(typeof(ClassAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                ClassAttribute fta = (ClassAttribute)o;

                mr.Class = fta.Class;
            }
        }

        public void ResolveStyleAttributes(ViewRubric mr)
        {
            var mi = ((IMemberRubric)mr.RubricInfo).MemberInfo;

            object? o = mi.GetCustomAttributes(typeof(StyleAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                StyleAttribute fta = (StyleAttribute)o;

                mr.Style = fta.Style;
            }
        }

        public void ResolveGridAttributes(ViewRubric mr)
        {
            var mi = ((IMemberRubric)mr.RubricInfo).MemberInfo;

            object? o = mi.GetCustomAttributes(typeof(GridAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                GridAttribute fta = (GridAttribute)o;

                mr.Grid = fta.PutTo<ViewGrid>();
            }
        }

        public void ResolveStackAttributes(ViewRubric mr)
        {
            var mi = ((IMemberRubric)mr.RubricInfo).MemberInfo;

            object? o = mi.GetCustomAttributes(typeof(StackAttribute), false).FirstOrDefault();
            if ((o != null))
            {
                StackAttribute fta = (StackAttribute)o;

                mr.Stack = fta.PutTo<ViewStack>();
            }
        }
    }
}

using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Instant.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class StackAttribute : Attribute
    {
        public StackAttribute() { }

        public Orientation? Orientation { get; set; }


        public HorizontalAlignment? HorizontalAlignment { get; set; }


        public VerticalAlignment? VerticalAlignment { get; set; }


        public int? VerticalGap { get; set; }


        public int? HorizontalGap { get; set; }
    }
}

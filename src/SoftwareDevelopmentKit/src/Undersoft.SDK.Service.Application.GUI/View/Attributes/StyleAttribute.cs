namespace Undersoft.SDK.Instant.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class StyleAttribute : Attribute
    {
        public StyleAttribute(string style) { Style = style; }

        public string Style { get; set; }
    }
}

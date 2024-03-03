namespace Undersoft.SDK.Instant.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ClassAttribute : Attribute
    {
        public ClassAttribute(string @class) { Class = @class; }

        public string Class { get; set; }
    }
}

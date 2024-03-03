namespace Undersoft.SDK.Instant.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ComponentAttribute : Attribute
    {
        public ComponentAttribute() { }

        public string? TypeName { get; set; }

        public Type? Type { get; set; }
    }
}

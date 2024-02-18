namespace Undersoft.SDK.Rubrics.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class LinkAttribute : RubricAttribute
    {
        public string Value;

        public OperationType Operation = OperationType.Any;

        public LinkAttribute() { }

        public LinkAttribute(string link)
        {
            Value = link;
        }

        public LinkAttribute(OperationType operation, string link)
        {
            Value = link;
            Operation = operation;
        }
    }
}

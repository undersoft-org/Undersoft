namespace Undersoft.SDK.Instant.Rubrics.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RubricAggregateAttribute : RubricAttribute
    {
        public AggregationOperand Operand = AggregationOperand.None;

        public RubricAggregateAttribute() { }
    }
}

namespace Undersoft.SDK.Rubrics.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class FileRubricAttribute : RubricAttribute
    {
        public FileRubricType Type { get; set; }

        public FileRubricAttribute() { }

        public FileRubricAttribute(FileRubricType type) { Type = type; }
    }

    public enum FileRubricType
    {
        None,
        Path,
        Stream,
        Blob
    }
}

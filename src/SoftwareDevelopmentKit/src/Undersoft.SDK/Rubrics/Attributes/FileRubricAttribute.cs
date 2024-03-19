namespace Undersoft.SDK.Rubrics.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class FileRubricAttribute : RubricAttribute
    {
        public FileRubricType Type { get; set; }

        public string DataRubricName { get; set; }

        public FileRubricAttribute() { }

        public FileRubricAttribute(FileRubricType type, string dataRubricName = null) { Type = type; DataRubricName = dataRubricName; }
    }

    public enum FileRubricType
    {
        None,
        Path,
        Stream,
        Blob
    }
}

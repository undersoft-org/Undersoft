namespace Undersoft.SDK.Service
{
    public interface IOperation
    {
        public object Input { get; }

        public object Output { get; }

        public Delegate Processings { get; set; }
    }
}

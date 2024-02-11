namespace Undersoft.SDK.Service.Operation
{
    [Flags]
    public enum OperationType
    {
        Any = 65555,
        Create = 1,
        Change = 2,
        Update = 4,
        Delete = 8,
        Upsert = 16,
        Reset = 32,
        Confirm = 64,
        Notify = 128,
        Action = 256,
        Setup = 512,
        Access = 1024,
        Query = 2048,
        Aggregate = 4096,
        Compute = 8192,
        Upload = 16384,
        Download = 32768
    }
}

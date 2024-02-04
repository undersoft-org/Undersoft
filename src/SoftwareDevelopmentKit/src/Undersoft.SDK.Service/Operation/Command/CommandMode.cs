namespace Undersoft.SDK.Service.Operation.Command
{
    [Flags]
    public enum CommandMode
    {
        Any = 31,
        Create = 1,
        Change = 2,
        Update = 4,
        Delete = 8,
        Upsert = 16,
        Action = 64,
        Setup = 128,
        Access = 256
    }
}

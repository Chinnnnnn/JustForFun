namespace Tools.Enums
{
    public enum Status : byte
    {
        Disabled = 0,
        Enabled = 1,
        Deleted = 99
    }

    public enum NoYes : byte
    {
        No = 0,
        Yes = 1
    }

    public enum Result : byte
    {
        Error = 0,
        Success = 1,
        Halt = 2,
    }
}

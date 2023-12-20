namespace Lab4;

public static class ReadyPlayerState
{
    internal static int CountReady { get; set; }
    internal static readonly object LockObject = new();
}
namespace DatabaseObjectPackageInstaller.Constants
{
    internal sealed class MessageStrings
    {
        internal static readonly string ProgressComplete = "Task Finished.";
        internal static readonly string ProgressFailed = "Task Finished with Errors.";
        internal static readonly string ConsoleComplete = "Press enter to exit...";
        internal static readonly string ProgressCancelled = "Task Canceled.";
        internal static readonly string Executing = "Executing: {0}";
        internal static readonly string GatheringDatabaseObjects = "Gathering Database Objects...";
        internal static readonly string StartingInstaler = "Preparing to Install Database Objects";
        internal static readonly string CmdCancelMessage = $"{System.Environment.NewLine}Press Ctrl + c to Cancel the command.{System.Environment.NewLine}";
    }
}

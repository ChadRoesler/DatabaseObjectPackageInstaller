namespace DatabaseObjectPackageInstaller.Constants
{
    internal sealed class ErrorStrings
    {
        internal readonly static string ErrorSqlExecution = $"[!!!] Error: An Error occurred while executing the following Sql Statement: {{0}}.{System.Environment.NewLine}    Error: {{1}}";
        internal readonly static string UnableToLocatePath = "Unable to locate the following Path: {0}";
        internal readonly static string PackageNoneError = $"The following Package: {{0}} does not contain either: a sequence manifest, or sql directory.";
        internal readonly static string PackageMultipleError = $"The following Package: {{0}} contains too many of either: sequence manifests, or sql directories.";
        internal readonly static string SqlUnableToConnect = $"Unable to connect to the Sql Server with the connection string {{0}}.{System.Environment.NewLine} The following Error occurred: {{1}}";
        internal readonly static string RequiredFieldFormat = "The field \"{0}\" is required.";
        internal readonly static string RequiredFieldFormatWithSpecial = "The field \"{0}\" is required when '{1}' is specified.";
    }
}

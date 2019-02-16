namespace DatabaseObjectPackageInstaller.Constants
{
    internal sealed class CommandStrings
    {
        internal const string DatabasePackagePathHelp = @"Aboslute path to the database package.";
        internal const string DatabaseNameHelp = @"Database to execute the database object package against.";
        internal const string ServerNameHelp = @"Sql Server to execute the database object package against.";
        internal const string UserNameHelp = @"UserName to log into the target SQL Server.";
        internal const string PasswordHelp = @"Password to log into the target SQL Server.";
        internal const string VerboseHelp = @"Print info as Tasks are run.";
        internal const string CustomHelp = @"True to deploy custom objects, this alters error handling.";
        internal const string HelpText = @"Displays Help information.";
    }
}

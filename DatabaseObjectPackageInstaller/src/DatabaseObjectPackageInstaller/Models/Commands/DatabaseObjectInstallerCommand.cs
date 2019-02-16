using CommandLine;
using CommandLine.Text;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Models.Commands
{
    public class DatabaseObjectInstallerCommand : ICommonSettings, IDatabaseSettings, IPackageSettings
    {
        [Option('c', "databasePackagePath", HelpText = CommandStrings.DatabasePackagePathHelp, Required = true)]
        public string PackagePath { get; set; }

        [Option ('x', "custom", HelpText = CommandStrings.CustomHelp, DefaultValue = false)]
        public bool Custom { get; set; }

        [Option('s', "server", HelpText = CommandStrings.ServerNameHelp, Required = true)]
        public string Server { get; set; }

        [Option('d', "database", HelpText = CommandStrings.DatabaseNameHelp, Required = true)]
        public string Database { get; set; }

        [Option('u', "userName", HelpText = CommandStrings.UserNameHelp, Required = false)]
        public string UserName { get; set; }

        [Option('p', "password", HelpText = CommandStrings.PasswordHelp, Required = false)]
        public string Password { get; set; }

        [Option('v', "verbose", HelpText = CommandStrings.VerboseHelp, DefaultValue = false)]
        public bool Verbose { get; set; }


        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpVerbOption("help", HelpText = CommandStrings.HelpText)]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}

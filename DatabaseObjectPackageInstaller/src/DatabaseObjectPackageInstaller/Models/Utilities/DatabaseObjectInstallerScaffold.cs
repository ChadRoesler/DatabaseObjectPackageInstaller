using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;
using HybridScaffolding;
using HybridScaffolding.Enums;
using log4net;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.Models.Commands;
using DatabaseObjectPackageInstaller.Workers;

namespace DatabaseObjectPackageInstaller.Models.Utilities
{
    class DatabaseObjectInstallerScaffold : HybridScaffold
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static CancellationTokenSource CancelSource { get; set; }

        public override void ConsoleMain(string[] arguments, RunTypes runType)
        {
            var task = ConsoleTask(arguments);
            task.Wait();
            base.ConsoleMain(arguments, runType);
        }

        public override object PreGuiExec(string[] arguments, object passableObject)
        {
            return base.PreGuiExec(arguments, passableObject);
        }

        private async static Task ConsoleTask(string[] arguments)
        {
            var dopiCommands = new DatabaseObjectInstallerCommand();
            var parsingStatus = Parser.Default.ParseArguments(arguments, dopiCommands);

            if (!parsingStatus)
            {
                Console.Write(dopiCommands.GetUsage());
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
            try
            {
                ConsoleProgress<Dictionary<ProgressType, string>> progressDictionary = new ConsoleProgress<Dictionary<ProgressType, string>>(value =>
                {
                    if (value.ContainsKey(ProgressType.Output))
                    {
                        Log.Info(value[ProgressType.Output]);
                    }
                    if (value.ContainsKey(ProgressType.Error))
                    {
                        Log.Error(value[ProgressType.Error]);
                        if (!dopiCommands.Custom)
                        {
                            throw new Exception(value[ProgressType.Error]);
                        }
                    }
                    if (value.ContainsKey(ProgressType.Warning))
                    {
                        Log.Warn(value[ProgressType.Warning]);
                    }
                    if (value.ContainsKey(ProgressType.Name))
                    {
                        if (value[ProgressType.Name] == MessageStrings.ProgressComplete)
                        {
                            Log.Info(MessageStrings.ConsoleComplete);
                        }
                        if (value[ProgressType.Name] == MessageStrings.ProgressFailed)
                        {
                            Log.Info(MessageStrings.ConsoleComplete);
                        }
                    }
                });

                var errorList = new List<string>();
                errorList.AddRange(ConsoleValidation.DatabaseObjectConnectionValidation(dopiCommands));
                errorList.AddRange(ConsoleValidation.DatabaseObjectPackageValidation(dopiCommands));

                CancelSource = new CancellationTokenSource();
                var cancelToken = CancelSource.Token;

                if (errorList.Count > 0)
                {
                    throw new Exception(string.Join(ResourceStrings.NewLineHandler, errorList));
                }
                else
                {
                    Log.Warn(MessageStrings.CmdCancelMessage);
                    Console.CancelKeyPress += (sender, eventargs) =>
                    {
                        CancelSource.Cancel();
                        eventargs.Cancel = true;
                    };
                    var executor = new PackageExecutor(dopiCommands, dopiCommands, dopiCommands);
                    await executor.Install(progressDictionary, cancelToken);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                Log.Error(dopiCommands.GetUsage());
                Environment.Exit(1);
            }
        }

        public override void GuiMain(string[] arguments, object passableObject)
        {
            base.GuiMain(arguments, passableObject);
        }
    }
}

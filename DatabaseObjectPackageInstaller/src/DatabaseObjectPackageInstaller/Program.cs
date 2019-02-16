using System;
using DatabaseObjectPackageInstaller.Models.Utilities;
using DatabaseObjectPackageInstaller.Forms;
using HybridScaffolding;

namespace DatabaseObjectPackageInstaller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
#if DEBUG
            System.Diagnostics.Debugger.Launch();
#endif
            var dopiScaffold = new DatabaseObjectInstallerScaffold();
            try
            {
                HybridExecutor.DispatchExecutor(dopiScaffold, arguments, typeof(frmDatabaseObjectPackageInstaller));
            }
            catch(Exception ex)
            {
                if (dopiScaffold.RunType == RunTypes.Console)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}

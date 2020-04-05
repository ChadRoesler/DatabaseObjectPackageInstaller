using System;
using System.Windows.Forms;
using DatabaseObjectPackageInstaller.Models.Utilities;
using DatabaseObjectPackageInstaller.Forms;
using HybridScaffolding;
using HybridScaffolding.Enums;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var dopiScaffold = new DatabaseObjectInstallerScaffold();
            try
            {
                HybridExecutor.DispatchExecutor(dopiScaffold, arguments, typeof(frmDatabaseObjectPackageInstaller));
            }
            catch(Exception ex)
            {
                if (dopiScaffold.RunType == RunTypes.Console || dopiScaffold.RunType == RunTypes.Powershell)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}

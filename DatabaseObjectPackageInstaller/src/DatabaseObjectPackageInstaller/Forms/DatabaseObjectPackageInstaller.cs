using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using log4net;
using Ookii.Dialogs;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.ExtensionMethods;
using DatabaseObjectPackageInstaller.Helpers;
using DatabaseObjectPackageInstaller.Models.Interfaces;
using DatabaseObjectPackageInstaller.Workers;

namespace DatabaseObjectPackageInstaller.Forms
{
    public partial class frmDatabaseObjectPackageInstaller : Form, IDatabaseSettings, IPackageSettings, ICommonSettings
    {
#region PrivateVars
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly FrmDatabaseObjectPackageInstallerProgress taskDopiForm = new FrmDatabaseObjectPackageInstallerProgress();
#endregion PrivateVars
        public frmDatabaseObjectPackageInstaller()
        {
            InitializeComponent();
            AuthenticationType = UiStrings.IntegratedSecurityText;
            Custom = true;
            taskDopiForm.Owner = this;
            Verbose = true;
        }

#region MajorVars
        public CancellationTokenSource CancelSource { get; set; }
        public string Server
        {
            get
            {
                return txtServerName.Text;
            }
            set
            {
                txtServerName.Text = value;
            }
        }
        public string Database
        {
            get
            {
                return txtDatabaseName.Text;
            }
            set
            {
                txtDatabaseName.Text = value;
            }
        }
        public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }
        public string PackagePath
        {
            get
            {
                return txtPackagePath.Text;
            }
            set
            {
                txtPackagePath.Text = value;
            }
        }
        public string AuthenticationType
        {
            get { return cmbAuthentication.Text; }
            set
            {
                cmbAuthentication.SelectedIndex = value == UiStrings.IntegratedSecurityText ? 0 : 1;
            }
        }
        public bool Custom { get; set; }

        public bool Verbose { get; set; }

        public static Dictionary<string, string> Errors;
        #endregion MajorVars

#region Methods
        public string ComposeConnectionString()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = Server,
                InitialCatalog = Database,
                IntegratedSecurity = (AuthenticationType == UiStrings.IntegratedSecurityText),
                UserID = UserName,
                Password = Password
            }.ToString();
        }

        public void DecomposeConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);

            Server = builder.DataSource;
            Database = builder.InitialCatalog;

            if (builder.IntegratedSecurity)
            {
                cmbAuthentication.SelectedIndex = 0;
            }
            else
            {
                cmbAuthentication.SelectedIndex = 1;
                UserName = builder.UserID;
                Password = builder.Password;
            }
        }

        public void CancelCurrentTask()
        {
            CancelSource.Cancel();
        }

        public bool ValidateForm()
        {
            Errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(Database) || string.IsNullOrEmpty(Server) || (AuthenticationType.Equals(UiStrings.DatabaseSecurityText) && string.IsNullOrEmpty(UserName)) || (AuthenticationType.Equals(UiStrings.DatabaseSecurityText) && string.IsNullOrEmpty(Password)))
            {
                if (string.IsNullOrWhiteSpace(Database))
                {
                    Errors.AddOrAppend(txtDatabaseName.Name, string.Format(ErrorStrings.RequiredFieldFormat, lblDatabaseName.Text.Replace(":", string.Empty)));
                }
                if (string.IsNullOrWhiteSpace(Server))
                {
                    Errors.AddOrAppend(txtServerName.Name, string.Format(ErrorStrings.RequiredFieldFormat, lblServerName.Text.Replace(":", string.Empty)));
                }
                if (AuthenticationType.Equals(UiStrings.DatabaseSecurityText) && string.IsNullOrWhiteSpace(UserName))
                {
                    Errors.AddOrAppend(txtUserName.Name, string.Format(ErrorStrings.RequiredFieldFormatWithSpecial, lblUserName.Text.Replace(":", string.Empty), AuthenticationType));
                }
                if (AuthenticationType.Equals(UiStrings.DatabaseSecurityText) && string.IsNullOrWhiteSpace(Password))
                {
                    Errors.AddOrAppend(txtPassword.Name, string.Format(ErrorStrings.RequiredFieldFormatWithSpecial, lblPassword.Text.Replace(":", string.Empty), AuthenticationType));
                }
            }
            else
            {
                var errorList = new List<string>();
                new SqlServerConnection().ValidateDatabaseConnection(this, ref errorList);
                if(errorList.Count > 0)
                {
                    Errors.Add(grpDatabaseConnection.Name, string.Join(ResourceStrings.NewLineHandler, errorList));
                }
            }
            if (string.IsNullOrWhiteSpace(PackagePath))
            {
                Errors.AddOrAppend(txtPackagePath.Name, string.Format(ErrorStrings.RequiredFieldFormat, lblPackagePath.Text.Replace(":", string.Empty)));
            }
            else
            {
                if (!FileHelper.ValidatePackagePath(this))
                {
                    Errors.AddOrAppend(txtPackagePath.Name, string.Format(ErrorStrings.UnableToLocatePath, PackagePath));
                }
                else
                {
                    var packageTypeError = string.Empty;
                    if (CompressedFileHelper.IsFileCompressed(PackagePath))
                    {
                        if (!PackageHelper.ValidateCompressedPackage(this, out packageTypeError))
                        {
                            Errors.AddOrAppend(txtPackagePath.Name, string.Format(packageTypeError, PackagePath));
                        }
                    }
                    else
                    {
                        if (!PackageHelper.ValidateUncompressedPackage(this, out packageTypeError))
                        {
                            Errors.AddOrAppend(txtPackagePath.Name, string.Format(packageTypeError, PackagePath));
                        }
                    }
                }
            }
            return (Errors.Count == 0);
        }

        public async Task GuiExecute()
        {
            var progressDictionary = new Progress<Dictionary<ProgressType, string>>(value =>
            {
                if(value.ContainsKey(ProgressType.Name) && !string.IsNullOrEmpty(value[ProgressType.Name]))
                {
                    taskDopiForm.ProgressLabel = value[ProgressType.Name];
                }
                if(value.ContainsKey(ProgressType.Output))
                {
                    Log.Info(value[ProgressType.Output]);
                }
                if(value.ContainsKey(ProgressType.Warning))
                {
                    Log.Warn(value[ProgressType.Warning]);
                }
                if(value.ContainsKey(ProgressType.Error))
                {
                    Log.Error(value[ProgressType.Error]);
                }
                if(value.ContainsKey(ProgressType.BarStatus))
                {
                    taskDopiForm.ProgressColor((ProgressBarStatusType)Enum.Parse(typeof(ProgressBarStatusType), value[ProgressType.BarStatus]));
                }
                if(value.ContainsKey(ProgressType.Size))
                {
                    taskDopiForm.SetProgressTotal(int.Parse(value[ProgressType.Size]));
                }
                if(value.ContainsKey(ProgressType.StepCount))
                {
                    taskDopiForm.AddProgressSteps(int.Parse(value[ProgressType.StepCount]));
                }
            });
            CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;
            var packageExecution = new PackageExecutor(this, this, this);
            await packageExecution.Install(progressDictionary, token);
            taskDopiForm.EnableBack = true;
            taskDopiForm.EnableExit = true;
            taskDopiForm.EnableCancel = false;
        }
#endregion Methods

#region Events
        private void RdbFile_CheckedChanged(object sender, EventArgs e)
        {
            rdbFile.Checked = !rdbFolder.Checked;
        }

        private void RdbFolder_CheckedChanged(object sender, EventArgs e)
        {
            rdbFolder.Checked = !rdbFile.Checked;
        }

        private void BtnPackagePath_Click(object sender, EventArgs e)
        {
            if(rdbFile.Checked)
            {
                var openFileDialog = new OpenFileDialog()
                {
                    Title = "Select Database Object Package...",
                    AddExtension = true,
                    CheckPathExists = true,
                    DefaultExt = ".zip",
                    Filter = "Zip File|*.zip|Sequence Manifest|sequence.txt"

                };
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PackagePath = openFileDialog.FileName;
                }
            }
            else
            {
                var openFolderDialog = new VistaFolderBrowserDialog()
                {
                    Description = "Select Database Object Package...",
                    UseDescriptionForTitle = true,
                };
                if(openFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    PackagePath = openFolderDialog.SelectedPath;
                }

            }
        }

        private void BtnServerBrowser_Click(object sender, EventArgs e)
        {
            var sqlDataSource = new DataSource("MicrosoftSqlServer", "Microsoft SQL Server");
            DataConnectionDialog dialog = new DataConnectionDialog();
           
            var sqlConnectionString = ComposeConnectionString();

            sqlDataSource.Providers.Add(DataProvider.SqlDataProvider);

            dialog.DataSources.Add(sqlDataSource);
            dialog.SelectedDataProvider = DataProvider.SqlDataProvider;
            dialog.SelectedDataSource = sqlDataSource;
            dialog.ConnectionString = sqlConnectionString;

            DialogResult result = DataConnectionDialog.Show(dialog);

            dialog.BringToFront();

            if (result == DialogResult.OK)
            {
                DecomposeConnectionString(dialog.ConnectionString);
            }
        }

        private void CmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthenticationType == UiStrings.IntegratedSecurityText)
            {
                lblUserName.Enabled = false;
                txtUserName.Enabled = false;
                txtUserName.Text = string.Empty;
                lblPassword.Enabled = false;
                txtPassword.Enabled = false;
                txtPassword.Text = string.Empty;
            }
            else
            {
                lblUserName.Enabled = true;
                txtUserName.Enabled = true;
                lblPassword.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void BtnInstall_Click(object sender, EventArgs e)
        {
            erpValidation.ClearAll(this);
            if(!ValidateForm())
            {
                erpValidation.SetErrors(Controls, Errors);
            }
            else
            {
                taskDopiForm.Cleanup();
                taskDopiForm.ProgressLabel = MessageStrings.StartingInstaler;
                Hide();
                taskDopiForm.StartPosition = FormStartPosition.Manual;
                taskDopiForm.Location = this.Location;
                taskDopiForm.Show();
                taskDopiForm.Focus();
                taskDopiForm.BringToFront();
                GuiExecute();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
#endregion Events
    }
}

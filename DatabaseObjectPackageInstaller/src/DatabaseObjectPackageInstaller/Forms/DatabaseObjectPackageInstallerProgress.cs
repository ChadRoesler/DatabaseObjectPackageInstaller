using System;
using System.Windows.Forms;
using log4net.Appender;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.ExtensionMethods;

namespace DatabaseObjectPackageInstaller.Forms
{
    public partial class FrmDatabaseObjectPackageInstallerProgress : Form
    {
        public FrmDatabaseObjectPackageInstallerProgress()
        {
            InitializeComponent();
            RichTextBoxAppender.SetRichTextBox(rtbLogging, "RichTextBoxAppender");
        }

        public void ProgressColor(ProgressBarStatusType status)
        {
            progressInstaller.SetState(status);
        }

        public void AddProgressSteps(int count)
        {
            if (count > 0)
            {
                var previousState = progressInstaller.GetState();

                if (progressInstaller.Value < progressInstaller.Maximum)
                {
                    progressInstaller.SetState(ProgressBarStatusType.Normal);
                    progressInstaller.Value = count;
                    progressInstaller.SetState(previousState);
                }
            };
        }

        public void SetProgressToMax()
        {
            progressInstaller.Value = progressInstaller.Maximum;
        }

        public string ProgressLabel
        {
            get
            {
                return lblProgress.Text;
            }
            set
            {
                lblProgress.Text = value;
            }
        }

        public void SetProgressTotal(int total)
        {
            progressInstaller.Maximum = total;
        }


        public bool EnableBack
        {
            get
            {
                return btnBack.Enabled;
            }
            set
            {
                btnBack.Enabled = value;
            }
        }

        public bool EnableCancel
        {
            get
            {
                return btnCancel.Enabled;
            }
            set
            {
                btnCancel.Enabled = value;
            }
        }

        public bool EnableExit
        {
            get
            {
                return btnExit.Enabled;
            }
            set
            {
                btnExit.Enabled = value;
            }
        }


        public void Cleanup()
        {
            ProgressColor(ProgressBarStatusType.Normal);
            progressInstaller.Maximum = 0;
            progressInstaller.Value = 0;
            rtbLogging.Text = string.Empty;
            EnableCancel = true;
            EnableBack = false;
            EnableExit = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SetProgressToMax();
            ProgressColor(ProgressBarStatusType.Warning);
            EnableCancel = false;
            ((frmDatabaseObjectPackageInstaller)Owner).CancelCurrentTask();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ((frmDatabaseObjectPackageInstaller)Owner).StartPosition = FormStartPosition.Manual;
            ((frmDatabaseObjectPackageInstaller)Owner).Location = this.Location;
            Hide();
            ((frmDatabaseObjectPackageInstaller)Owner).Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmDatabaseObjectPackageInstallerProgress_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

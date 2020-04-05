namespace DatabaseObjectPackageInstaller.Forms
{
    partial class frmDatabaseObjectPackageInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseObjectPackageInstaller));
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdbFile = new System.Windows.Forms.RadioButton();
            this.rdbFolder = new System.Windows.Forms.RadioButton();
            this.lblInfoText = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblPackagePath = new System.Windows.Forms.Label();
            this.txtPackagePath = new System.Windows.Forms.TextBox();
            this.btnPackagePath = new System.Windows.Forms.Button();
            this.grpDatabaseConnection = new System.Windows.Forms.GroupBox();
            this.btnServerBrowser = new System.Windows.Forms.Button();
            this.cmbAuthentication = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblPackageType = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.pctBanner = new System.Windows.Forms.PictureBox();
            this.erpValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpDatabaseConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(33, 36);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(490, 17);
            this.lblSubtitle.TabIndex = 10;
            this.lblSubtitle.Text = "This installer will apply a database object package to the specified database.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 18);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Database Object Package Installer";
            // 
            // rdbFile
            // 
            this.rdbFile.AutoSize = true;
            this.rdbFile.Checked = true;
            this.rdbFile.Location = new System.Drawing.Point(145, 203);
            this.rdbFile.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFile.Name = "rdbFile";
            this.rdbFile.Size = new System.Drawing.Size(51, 21);
            this.rdbFile.TabIndex = 11;
            this.rdbFile.TabStop = true;
            this.rdbFile.Text = "File";
            this.rdbFile.UseVisualStyleBackColor = true;
            this.rdbFile.CheckedChanged += new System.EventHandler(this.RdbFile_CheckedChanged);
            // 
            // rdbFolder
            // 
            this.rdbFolder.AutoSize = true;
            this.rdbFolder.Location = new System.Drawing.Point(208, 203);
            this.rdbFolder.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFolder.Name = "rdbFolder";
            this.rdbFolder.Size = new System.Drawing.Size(69, 21);
            this.rdbFolder.TabIndex = 12;
            this.rdbFolder.Text = "Folder";
            this.rdbFolder.UseVisualStyleBackColor = true;
            this.rdbFolder.CheckedChanged += new System.EventHandler(this.RdbFolder_CheckedChanged);
            // 
            // lblInfoText
            // 
            this.lblInfoText.Location = new System.Drawing.Point(16, 92);
            this.lblInfoText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Size = new System.Drawing.Size(627, 95);
            this.lblInfoText.TabIndex = 13;
            this.lblInfoText.Text = resources.GetString("lblInfoText.Text");
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(657, 575);
            this.shapeContainer1.TabIndex = 28;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -1;
            this.lineShape2.X2 = 496;
            this.lineShape2.Y1 = 55;
            this.lineShape2.Y2 = 55;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -6;
            this.lineShape1.X2 = 497;
            this.lineShape1.Y1 = 429;
            this.lineShape1.Y2 = 429;
            // 
            // lblPackagePath
            // 
            this.lblPackagePath.AutoSize = true;
            this.lblPackagePath.Location = new System.Drawing.Point(33, 235);
            this.lblPackagePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPackagePath.Name = "lblPackagePath";
            this.lblPackagePath.Size = new System.Drawing.Size(100, 17);
            this.lblPackagePath.TabIndex = 14;
            this.lblPackagePath.Text = "Package Path:";
            // 
            // txtPackagePath
            // 
            this.txtPackagePath.Location = new System.Drawing.Point(145, 231);
            this.txtPackagePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackagePath.Name = "txtPackagePath";
            this.txtPackagePath.Size = new System.Drawing.Size(392, 22);
            this.txtPackagePath.TabIndex = 15;
            // 
            // btnPackagePath
            // 
            this.btnPackagePath.Location = new System.Drawing.Point(547, 229);
            this.btnPackagePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnPackagePath.Name = "btnPackagePath";
            this.btnPackagePath.Size = new System.Drawing.Size(43, 28);
            this.btnPackagePath.TabIndex = 16;
            this.btnPackagePath.Text = "...";
            this.btnPackagePath.UseVisualStyleBackColor = true;
            this.btnPackagePath.Click += new System.EventHandler(this.BtnPackagePath_Click);
            // 
            // grpDatabaseConnection
            // 
            this.grpDatabaseConnection.Controls.Add(this.btnServerBrowser);
            this.grpDatabaseConnection.Controls.Add(this.cmbAuthentication);
            this.grpDatabaseConnection.Controls.Add(this.txtPassword);
            this.grpDatabaseConnection.Controls.Add(this.txtUserName);
            this.grpDatabaseConnection.Controls.Add(this.txtDatabaseName);
            this.grpDatabaseConnection.Controls.Add(this.txtServerName);
            this.grpDatabaseConnection.Controls.Add(this.lblPassword);
            this.grpDatabaseConnection.Controls.Add(this.lblUserName);
            this.grpDatabaseConnection.Controls.Add(this.lblAuthentication);
            this.grpDatabaseConnection.Controls.Add(this.lblDatabaseName);
            this.grpDatabaseConnection.Controls.Add(this.lblServerName);
            this.grpDatabaseConnection.Location = new System.Drawing.Point(56, 265);
            this.grpDatabaseConnection.Margin = new System.Windows.Forms.Padding(4);
            this.grpDatabaseConnection.Name = "grpDatabaseConnection";
            this.grpDatabaseConnection.Padding = new System.Windows.Forms.Padding(4);
            this.grpDatabaseConnection.Size = new System.Drawing.Size(548, 208);
            this.grpDatabaseConnection.TabIndex = 17;
            this.grpDatabaseConnection.TabStop = false;
            this.grpDatabaseConnection.Text = "Database Connection";
            // 
            // btnServerBrowser
            // 
            this.btnServerBrowser.Location = new System.Drawing.Point(433, 31);
            this.btnServerBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.btnServerBrowser.Name = "btnServerBrowser";
            this.btnServerBrowser.Size = new System.Drawing.Size(100, 28);
            this.btnServerBrowser.TabIndex = 10;
            this.btnServerBrowser.Text = "Browse...";
            this.btnServerBrowser.UseVisualStyleBackColor = true;
            this.btnServerBrowser.Click += new System.EventHandler(this.BtnServerBrowser_Click);
            // 
            // cmbAuthentication
            // 
            this.cmbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthentication.FormattingEnabled = true;
            this.cmbAuthentication.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cmbAuthentication.Location = new System.Drawing.Point(147, 97);
            this.cmbAuthentication.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAuthentication.Name = "cmbAuthentication";
            this.cmbAuthentication.Size = new System.Drawing.Size(277, 24);
            this.cmbAuthentication.TabIndex = 9;
            this.cmbAuthentication.SelectedIndexChanged += new System.EventHandler(this.CmbAuthentication_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(169, 162);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(277, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(169, 130);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(277, 22);
            this.txtUserName.TabIndex = 7;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(147, 65);
            this.txtDatabaseName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(277, 22);
            this.txtDatabaseName.TabIndex = 6;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(147, 33);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(277, 22);
            this.txtServerName.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(64, 166);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(55, 134);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name:";
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.AutoSize = true;
            this.lblAuthentication.Location = new System.Drawing.Point(35, 101);
            this.lblAuthentication.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(102, 17);
            this.lblAuthentication.TabIndex = 2;
            this.lblAuthentication.Text = "Authentication:";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(23, 69);
            this.lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(114, 17);
            this.lblDatabaseName.TabIndex = 1;
            this.lblDatabaseName.Text = "Database Name:";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(43, 37);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(95, 17);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name:";
            // 
            // lblPackageType
            // 
            this.lblPackageType.AutoSize = true;
            this.lblPackageType.Location = new System.Drawing.Point(31, 206);
            this.lblPackageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPackageType.Name = "lblPackageType";
            this.lblPackageType.Size = new System.Drawing.Size(103, 17);
            this.lblPackageType.TabIndex = 18;
            this.lblPackageType.Text = "Package Type:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(564, 543);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 30);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(477, 543);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(79, 30);
            this.btnInstall.TabIndex = 20;
            this.btnInstall.Text = "&Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            // 
            // pctBanner
            // 
            this.pctBanner.Image = global::DatabaseObjectPackageInstaller.Properties.Resources.banner;
            this.pctBanner.ImageLocation = "";
            this.pctBanner.InitialImage = global::DatabaseObjectPackageInstaller.Properties.Resources.banner;
            this.pctBanner.Location = new System.Drawing.Point(0, 0);
            this.pctBanner.Margin = new System.Windows.Forms.Padding(4);
            this.pctBanner.Name = "pctBanner";
            this.pctBanner.Size = new System.Drawing.Size(659, 68);
            this.pctBanner.TabIndex = 6;
            this.pctBanner.TabStop = false;
            // 
            // erpValidation
            // 
            this.erpValidation.ContainerControl = this;
            this.erpValidation.Icon = ((System.Drawing.Icon)(resources.GetObject("erpValidation.Icon")));
            // 
            // frmDatabaseObjectPackageInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 575);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblPackageType);
            this.Controls.Add(this.grpDatabaseConnection);
            this.Controls.Add(this.btnPackagePath);
            this.Controls.Add(this.txtPackagePath);
            this.Controls.Add(this.lblPackagePath);
            this.Controls.Add(this.rdbFolder);
            this.Controls.Add(this.rdbFile);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pctBanner);
            this.Controls.Add(this.lblInfoText);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 622);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(675, 622);
            this.Name = "frmDatabaseObjectPackageInstaller";
            this.Text = "Database Object Package Installer";
            this.grpDatabaseConnection.ResumeLayout(false);
            this.grpDatabaseConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpValidation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBanner;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdbFile;
        private System.Windows.Forms.RadioButton rdbFolder;
        private System.Windows.Forms.Label lblInfoText;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label lblPackagePath;
        private System.Windows.Forms.TextBox txtPackagePath;
        private System.Windows.Forms.Button btnPackagePath;
        private System.Windows.Forms.GroupBox grpDatabaseConnection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ComboBox cmbAuthentication;
        private System.Windows.Forms.Label lblPackageType;
        private System.Windows.Forms.Button btnServerBrowser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.ErrorProvider erpValidation;
    }
}


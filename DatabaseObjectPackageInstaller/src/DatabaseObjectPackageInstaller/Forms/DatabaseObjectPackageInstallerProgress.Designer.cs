namespace DatabaseObjectPackageInstaller.Forms

{
    partial class frmDatabaseObjectPackageInstallerProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseObjectPackageInstallerProgress));
            this.pctBanner = new System.Windows.Forms.PictureBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rtbLogging = new System.Windows.Forms.RichTextBox();
            this.progressInstaller = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblOutputConsole = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBanner
            // 
            this.pctBanner.Image = global::DatabaseObjectPackageInstaller.Properties.Resources.banner;
            this.pctBanner.ImageLocation = "";
            this.pctBanner.InitialImage = global::DatabaseObjectPackageInstaller.Properties.Resources.banner;
            this.pctBanner.Location = new System.Drawing.Point(0, 0);
            this.pctBanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pctBanner.Name = "pctBanner";
            this.pctBanner.Size = new System.Drawing.Size(659, 68);
            this.pctBanner.TabIndex = 6;
            this.pctBanner.TabStop = false;
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
            this.lblTitle.Size = new System.Drawing.Size(200, 18);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Database Object Installer";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(494, 474);
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
            // rtbLogging
            // 
            this.rtbLogging.Location = new System.Drawing.Point(20, 209);
            this.rtbLogging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbLogging.Name = "rtbLogging";
            this.rtbLogging.ReadOnly = true;
            this.rtbLogging.Size = new System.Drawing.Size(617, 276);
            this.rtbLogging.TabIndex = 21;
            this.rtbLogging.Text = "";
            // 
            // progressInstaller
            // 
            this.progressInstaller.Location = new System.Drawing.Point(20, 124);
            this.progressInstaller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressInstaller.Maximum = 0;
            this.progressInstaller.Name = "progressInstaller";
            this.progressInstaller.Size = new System.Drawing.Size(619, 28);
            this.progressInstaller.Step = 1;
            this.progressInstaller.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressInstaller.TabIndex = 29;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(16, 87);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(627, 18);
            this.lblProgress.TabIndex = 28;
            this.lblProgress.Text = "ExecutingTask: {0}";
            // 
            // lblOutputConsole
            // 
            this.lblOutputConsole.AutoSize = true;
            this.lblOutputConsole.Location = new System.Drawing.Point(16, 176);
            this.lblOutputConsole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputConsole.Name = "lblOutputConsole";
            this.lblOutputConsole.Size = new System.Drawing.Size(110, 17);
            this.lblOutputConsole.TabIndex = 30;
            this.lblOutputConsole.Text = "Output Console:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(477, 543);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(79, 30);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(20, 543);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(564, 543);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 30);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDatabaseObjectPackageInstallerProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 574);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblOutputConsole);
            this.Controls.Add(this.progressInstaller);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.rtbLogging);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pctBanner);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(674, 621);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(674, 621);
            this.Name = "frmDatabaseObjectPackageInstallerProgress";
            this.Text = "Database Object Package Installer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDatabaseObjectPackageInstallerProgress_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pctBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBanner;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.RichTextBox rtbLogging;
        private System.Windows.Forms.ProgressBar progressInstaller;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblOutputConsole;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
    }
}


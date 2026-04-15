namespace DVLD.Applications
{
    partial class frmListLocalDrivingLicenseApplications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.mischeduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mischeduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mischeduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.mishowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecordsCount.Location = new System.Drawing.Point(96, 449);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(73, 28);
            this.lblRecordsCount.TabIndex = 20;
            this.lblRecordsCount.Text = "???";
            this.lblRecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(354, 189);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(231, 25);
            this.txtFilterValue.TabIndex = 15;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Local Driving License Application ID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(117, 189);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(231, 25);
            this.cbFilterBy.TabIndex = 13;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1328, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 38);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl1
            // 
            this.lbl1.ForeColor = System.Drawing.Color.DimGray;
            this.lbl1.Location = new System.Drawing.Point(39, 454);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 28);
            this.lbl1.TabIndex = 18;
            this.lbl1.Text = "# Records: ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // cmsApplications
            // 
            this.cmsApplications.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowApplicationDetails,
            this.miEditApplication,
            this.toolStripSeparator1,
            this.miDeleteApplication,
            this.miCancelApplication,
            this.miScheduleTests,
            this.toolStripSeparator2,
            this.miIssueDrivingLicenseFirstTime,
            this.miShowLicense,
            this.mishowPersonLicenseHistory});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(281, 342);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // miShowApplicationDetails
            // 
            this.miShowApplicationDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.miShowApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowApplicationDetails.Name = "miShowApplicationDetails";
            this.miShowApplicationDetails.Size = new System.Drawing.Size(280, 38);
            this.miShowApplicationDetails.Text = "Show Application Details";
            this.miShowApplicationDetails.Click += new System.EventHandler(this.miShowApplicationDetails_Click);
            // 
            // miEditApplication
            // 
            this.miEditApplication.Image = global::DVLD.Properties.Resources.edit_32;
            this.miEditApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miEditApplication.Name = "miEditApplication";
            this.miEditApplication.Size = new System.Drawing.Size(280, 38);
            this.miEditApplication.Text = "Edit Application";
            this.miEditApplication.Click += new System.EventHandler(this.miEditApplication_Click);
            // 
            // miDeleteApplication
            // 
            this.miDeleteApplication.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.miDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miDeleteApplication.Name = "miDeleteApplication";
            this.miDeleteApplication.Size = new System.Drawing.Size(280, 38);
            this.miDeleteApplication.Text = "Delete Application";
            this.miDeleteApplication.Click += new System.EventHandler(this.miDeleteApplication_Click);
            // 
            // miCancelApplication
            // 
            this.miCancelApplication.Image = global::DVLD.Properties.Resources.Delete_321;
            this.miCancelApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miCancelApplication.Name = "miCancelApplication";
            this.miCancelApplication.Size = new System.Drawing.Size(280, 38);
            this.miCancelApplication.Text = "Cancel Application";
            this.miCancelApplication.Click += new System.EventHandler(this.miCancelApplication_Click);
            // 
            // miScheduleTests
            // 
            this.miScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mischeduleVisionTest,
            this.mischeduleWrittenTest,
            this.mischeduleStreetTest});
            this.miScheduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.miScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miScheduleTests.Name = "miScheduleTests";
            this.miScheduleTests.Size = new System.Drawing.Size(280, 38);
            this.miScheduleTests.Text = "Schedule Tests";
            // 
            // mischeduleVisionTest
            // 
            this.mischeduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.mischeduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mischeduleVisionTest.Name = "mischeduleVisionTest";
            this.mischeduleVisionTest.Size = new System.Drawing.Size(217, 38);
            this.mischeduleVisionTest.Text = "Schedule Vision Test";
            this.mischeduleVisionTest.Click += new System.EventHandler(this.mischeduleVisionTest_Click);
            // 
            // mischeduleWrittenTest
            // 
            this.mischeduleWrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.mischeduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mischeduleWrittenTest.Name = "mischeduleWrittenTest";
            this.mischeduleWrittenTest.Size = new System.Drawing.Size(217, 38);
            this.mischeduleWrittenTest.Text = "Schedule Written Test";
            this.mischeduleWrittenTest.Click += new System.EventHandler(this.mischeduleWrittenTest_Click);
            // 
            // mischeduleStreetTest
            // 
            this.mischeduleStreetTest.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.mischeduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mischeduleStreetTest.Name = "mischeduleStreetTest";
            this.mischeduleStreetTest.Size = new System.Drawing.Size(217, 38);
            this.mischeduleStreetTest.Text = "Schedule Street Test";
            this.mischeduleStreetTest.Click += new System.EventHandler(this.mischeduleStreetTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(277, 6);
            // 
            // miIssueDrivingLicenseFirstTime
            // 
            this.miIssueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.miIssueDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miIssueDrivingLicenseFirstTime.Name = "miIssueDrivingLicenseFirstTime";
            this.miIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(280, 38);
            this.miIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.miIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.miIssueDrivingLicenseFirstTime_Click);
            // 
            // miShowLicense
            // 
            this.miShowLicense.Image = global::DVLD.Properties.Resources.License_View_321;
            this.miShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowLicense.Name = "miShowLicense";
            this.miShowLicense.Size = new System.Drawing.Size(280, 38);
            this.miShowLicense.Text = "Show License";
            this.miShowLicense.Click += new System.EventHandler(this.miShowLicense_Click);
            // 
            // mishowPersonLicenseHistory
            // 
            this.mishowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.mishowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mishowPersonLicenseHistory.Name = "mishowPersonLicenseHistory";
            this.mishowPersonLicenseHistory.Size = new System.Drawing.Size(280, 38);
            this.mishowPersonLicenseHistory.Text = "Show Person License History";
            this.mishowPersonLicenseHistory.Click += new System.EventHandler(this.mishowPersonLicenseHistory_Click);
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseApplications.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicenseApplications.EnableHeadersVisualStyles = false;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(42, 220);
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 30;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1404, 228);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 11;
            this.dgvLocalDrivingLicenseApplications.DoubleClick += new System.EventHandler(this.dgvLocalDrivingLicenseApplications_DoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(467, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "Local Driving License Applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_322;
            this.pictureBox2.Location = new System.Drawing.Point(776, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(627, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddLocalDrivingLicenseApplication
            // 
            this.btnAddLocalDrivingLicenseApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLocalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1378, 149);
            this.btnAddLocalDrivingLicenseApplication.Name = "btnAddLocalDrivingLicenseApplication";
            this.btnAddLocalDrivingLicenseApplication.Size = new System.Drawing.Size(68, 65);
            this.btnAddLocalDrivingLicenseApplication.TabIndex = 16;
            this.btnAddLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddLocalDrivingLicenseApplication_Click);
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1483, 518);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddLocalDrivingLicenseApplication);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem miShowLicense;
        private System.Windows.Forms.Button btnAddLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem miIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripMenuItem miScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem miDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miEditApplication;
        private System.Windows.Forms.ToolStripMenuItem miShowApplicationDetails;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem mishowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem miCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem mischeduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem mischeduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem mischeduleStreetTest;
    }
}
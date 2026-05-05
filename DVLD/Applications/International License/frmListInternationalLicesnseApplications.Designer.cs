namespace DVLD
{
    partial class frmListInternationalLicesnseApplications
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mishowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.btnAddLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(899, 454);
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
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowPersonDetails,
            this.miShowLicenseDetails,
            this.mishowPersonLicenseHistory});
            this.cmsInternationalLicenses.Name = "contextMenuStrip1";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(259, 118);
            // 
            // miShowPersonDetails
            // 
            this.miShowPersonDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.miShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowPersonDetails.Name = "miShowPersonDetails";
            this.miShowPersonDetails.Size = new System.Drawing.Size(258, 38);
            this.miShowPersonDetails.Text = "Show Person Details";
            this.miShowPersonDetails.Click += new System.EventHandler(this.miShowPersonDetails_Click);
            // 
            // miShowLicenseDetails
            // 
            this.miShowLicenseDetails.Image = global::DVLD.Properties.Resources.License_View_326;
            this.miShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowLicenseDetails.Name = "miShowLicenseDetails";
            this.miShowLicenseDetails.Size = new System.Drawing.Size(258, 38);
            this.miShowLicenseDetails.Text = "Show License Details";
            this.miShowLicenseDetails.Click += new System.EventHandler(this.miShowLicenseDetails_Click);
            // 
            // mishowPersonLicenseHistory
            // 
            this.mishowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_322;
            this.mishowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mishowPersonLicenseHistory.Name = "mishowPersonLicenseHistory";
            this.mishowPersonLicenseHistory.Size = new System.Drawing.Size(258, 38);
            this.mishowPersonLicenseHistory.Text = "Show Person License History";
            this.mishowPersonLicenseHistory.Click += new System.EventHandler(this.mishowPersonLicenseHistory_Click);
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicenses;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicenses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicenses.EnableHeadersVisualStyles = false;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(42, 220);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowTemplate.Height = 30;
            this.dgvInternationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(975, 228);
            this.dgvInternationalLicenses.TabIndex = 11;
            this.dgvInternationalLicenses.DoubleClick += new System.EventHandler(this.dgvInternationalLicenses_DoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(278, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "International Licenses Applications";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "Local License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(109, 188);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(201, 25);
            this.cbFilterBy.TabIndex = 21;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // cbIsActive
            // 
            this.cbIsActive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(318, 189);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(138, 25);
            this.cbIsActive.TabIndex = 23;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(316, 188);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(188, 25);
            this.txtFilterValue.TabIndex = 22;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // btnAddLocalDrivingLicenseApplication
            // 
            this.btnAddLocalDrivingLicenseApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLocalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddLocalDrivingLicenseApplication.Location = new System.Drawing.Point(949, 148);
            this.btnAddLocalDrivingLicenseApplication.Name = "btnAddLocalDrivingLicenseApplication";
            this.btnAddLocalDrivingLicenseApplication.Size = new System.Drawing.Size(68, 65);
            this.btnAddLocalDrivingLicenseApplication.TabIndex = 113;
            this.btnAddLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddLocalDrivingLicenseApplication_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.International_327;
            this.pictureBox3.Location = new System.Drawing.Point(412, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 112;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Manage_Applications_641;
            this.pictureBox1.Location = new System.Drawing.Point(412, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // frmListInternationalLicesnseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 518);
            this.Controls.Add(this.btnAddLocalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvInternationalLicenses);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListInternationalLicesnseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List International Licesnse Applications";
            this.Load += new System.EventHandler(this.frmListInternationalLicesnseApplications_Load);
            this.cmsInternationalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem miShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem miShowPersonDetails;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnAddLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem mishowPersonLicenseHistory;
    }
}
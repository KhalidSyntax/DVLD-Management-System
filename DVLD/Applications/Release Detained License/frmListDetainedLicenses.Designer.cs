namespace DVLD.Licenses.List_Detain_Licenses
{
    partial class frmListDetainedLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cmsDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mishowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mireleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.cmsDetainedLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecordsCount.Location = new System.Drawing.Point(90, 449);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(73, 28);
            this.lblRecordsCount.TabIndex = 119;
            this.lblRecordsCount.Text = "???";
            this.lblRecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1174, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 38);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl1
            // 
            this.lbl1.ForeColor = System.Drawing.Color.DimGray;
            this.lbl1.Location = new System.Drawing.Point(33, 454);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 28);
            this.lbl1.TabIndex = 118;
            this.lbl1.Text = "# Records: ";
            // 
            // cmsDetainedLicenses
            // 
            this.cmsDetainedLicenses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowPersonDetails,
            this.miShowLicenseDetails,
            this.mishowPersonLicenseHistory,
            this.mireleaseDetainedLicense});
            this.cmsDetainedLicenses.Name = "contextMenuStrip1";
            this.cmsDetainedLicenses.Size = new System.Drawing.Size(259, 156);
            this.cmsDetainedLicenses.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDetainedLicenses_Opening);
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
            // mireleaseDetainedLicense
            // 
            this.mireleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_322;
            this.mireleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mireleaseDetainedLicense.Name = "mireleaseDetainedLicense";
            this.mireleaseDetainedLicense.Size = new System.Drawing.Size(258, 38);
            this.mireleaseDetainedLicense.Text = "Release Detained License";
            this.mireleaseDetainedLicense.Click += new System.EventHandler(this.mireleaseDetainedLicense_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 123;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(103, 188);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(201, 25);
            this.cbFilterBy.TabIndex = 120;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(310, 188);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(188, 25);
            this.txtFilterValue.TabIndex = 121;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmsDetainedLicenses;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainedLicenses.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetainedLicenses.EnableHeadersVisualStyles = false;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(36, 220);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.RowTemplate.Height = 30;
            this.dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1256, 228);
            this.dgvDetainedLicenses.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.Location = new System.Drawing.Point(408, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 44);
            this.label1.TabIndex = 115;
            this.label1.Text = "List Detained Licenses";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.btnRelease.Location = new System.Drawing.Point(1151, 148);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(68, 65);
            this.btnRelease.TabIndex = 126;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetain.Image = global::DVLD.Properties.Resources.Detain_642;
            this.btnDetain.Location = new System.Drawing.Point(1224, 148);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(68, 65);
            this.btnDetain.TabIndex = 125;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(543, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 116;
            this.pictureBox1.TabStop = false;
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(310, 189);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(138, 25);
            this.cbIsReleased.TabIndex = 127;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1317, 518);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            this.cmsDetainedLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ContextMenuStrip cmsDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem miShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem miShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem mishowPersonLicenseHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ToolStripMenuItem mireleaseDetainedLicense;
        private System.Windows.Forms.ComboBox cbIsReleased;
    }
}
namespace DVLD
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbLocalLicensesHistory = new System.Windows.Forms.GroupBox();
            this.tcLicenses = new System.Windows.Forms.TabControl();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowLocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.lblLocalLicensesRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tpInternationalLicenses = new System.Windows.Forms.TabPage();
            this.lblInternationalLicensesRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miShowInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.gbLocalLicensesHistory.SuspendLayout();
            this.tcLicenses.SuspendLayout();
            this.cmsLocalLicenses.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tpInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocalLicensesHistory
            // 
            this.gbLocalLicensesHistory.Controls.Add(this.tcLicenses);
            this.gbLocalLicensesHistory.Location = new System.Drawing.Point(3, 1);
            this.gbLocalLicensesHistory.Name = "gbLocalLicensesHistory";
            this.gbLocalLicensesHistory.Size = new System.Drawing.Size(885, 392);
            this.gbLocalLicensesHistory.TabIndex = 1;
            this.gbLocalLicensesHistory.TabStop = false;
            this.gbLocalLicensesHistory.Text = "Driver Licenses";
            // 
            // tcLicenses
            // 
            this.tcLicenses.ContextMenuStrip = this.cmsLocalLicenses;
            this.tcLicenses.Controls.Add(this.tpLocalLicenses);
            this.tcLicenses.Controls.Add(this.tpInternationalLicenses);
            this.tcLicenses.Location = new System.Drawing.Point(6, 24);
            this.tcLicenses.Name = "tcLicenses";
            this.tcLicenses.SelectedIndex = 0;
            this.tcLicenses.Size = new System.Drawing.Size(874, 360);
            this.tcLicenses.TabIndex = 0;
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowLocalLicense});
            this.cmsLocalLicenses.Name = "contextMenuStrip1";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(196, 42);
            // 
            // miShowLocalLicense
            // 
            this.miShowLocalLicense.Image = global::DVLD.Properties.Resources.License_View_324;
            this.miShowLocalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowLocalLicense.Name = "miShowLocalLicense";
            this.miShowLocalLicense.Size = new System.Drawing.Size(195, 38);
            this.miShowLocalLicense.Text = "Show License Info";
            this.miShowLocalLicense.Click += new System.EventHandler(this.mishowLicenseInfo_Click);
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.Controls.Add(this.lblLocalLicensesRecords);
            this.tpLocalLicenses.Controls.Add(this.label5);
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocalLicenses.Controls.Add(this.label6);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 26);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(866, 330);
            this.tpLocalLicenses.TabIndex = 0;
            this.tpLocalLicenses.Text = "Local Licenses";
            this.tpLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // lblLocalLicensesRecords
            // 
            this.lblLocalLicensesRecords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesRecords.ForeColor = System.Drawing.Color.DimGray;
            this.lblLocalLicensesRecords.Location = new System.Drawing.Point(85, 283);
            this.lblLocalLicensesRecords.Name = "lblLocalLicensesRecords";
            this.lblLocalLicensesRecords.Size = new System.Drawing.Size(28, 22);
            this.lblLocalLicensesRecords.TabIndex = 31;
            this.lblLocalLicensesRecords.Text = "???";
            this.lblLocalLicensesRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(15, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 30;
            this.label5.Text = "# Records: ";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalLicensesHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalLicensesHistory.EnableHeadersVisualStyles = false;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(15, 41);
            this.dgvLocalLicensesHistory.MultiSelect = false;
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.RowTemplate.Height = 30;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(838, 239);
            this.dgvLocalLicensesHistory.TabIndex = 29;
            this.dgvLocalLicensesHistory.DoubleClick += new System.EventHandler(this.dgvLocalLicensesHistory_DoubleClick);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 26);
            this.label6.TabIndex = 28;
            this.label6.Text = "Local Licenses History:";
            // 
            // tpInternationalLicenses
            // 
            this.tpInternationalLicenses.Controls.Add(this.lblInternationalLicensesRecords);
            this.tpInternationalLicenses.Controls.Add(this.label2);
            this.tpInternationalLicenses.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tpInternationalLicenses.Controls.Add(this.label3);
            this.tpInternationalLicenses.Location = new System.Drawing.Point(4, 26);
            this.tpInternationalLicenses.Name = "tpInternationalLicenses";
            this.tpInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicenses.Size = new System.Drawing.Size(866, 330);
            this.tpInternationalLicenses.TabIndex = 1;
            this.tpInternationalLicenses.Text = "International Licenses";
            this.tpInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // lblInternationalLicensesRecords
            // 
            this.lblInternationalLicensesRecords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicensesRecords.ForeColor = System.Drawing.Color.DimGray;
            this.lblInternationalLicensesRecords.Location = new System.Drawing.Point(83, 289);
            this.lblInternationalLicensesRecords.Name = "lblInternationalLicensesRecords";
            this.lblInternationalLicensesRecords.Size = new System.Drawing.Size(28, 22);
            this.lblInternationalLicensesRecords.TabIndex = 35;
            this.lblInternationalLicensesRecords.Text = "???";
            this.lblInternationalLicensesRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(13, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "# Records: ";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.cmsInternationalLicenses;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicensesHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalLicensesHistory.EnableHeadersVisualStyles = false;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(13, 47);
            this.dgvInternationalLicensesHistory.MultiSelect = false;
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            this.dgvInternationalLicensesHistory.RowTemplate.Height = 30;
            this.dgvInternationalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(833, 239);
            this.dgvInternationalLicensesHistory.TabIndex = 33;
            this.dgvInternationalLicensesHistory.DoubleClick += new System.EventHandler(this.dgvInternationalLicensesHistory_DoubleClick);
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowInternationalLicense});
            this.cmsInternationalLicenses.Name = "contextMenuStrip1";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(196, 42);
            // 
            // miShowInternationalLicense
            // 
            this.miShowInternationalLicense.Image = global::DVLD.Properties.Resources.License_View_325;
            this.miShowInternationalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miShowInternationalLicense.Name = "miShowInternationalLicense";
            this.miShowInternationalLicense.Size = new System.Drawing.Size(195, 38);
            this.miShowInternationalLicense.Text = "Show License Info";
            this.miShowInternationalLicense.Click += new System.EventHandler(this.miShowInternationalLicense_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 26);
            this.label3.TabIndex = 32;
            this.label3.Text = "International Licenses History:";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbLocalLicensesHistory);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(896, 398);
            this.gbLocalLicensesHistory.ResumeLayout(false);
            this.tcLicenses.ResumeLayout(false);
            this.cmsLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tpInternationalLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbLocalLicensesHistory;
        private System.Windows.Forms.TabControl tcLicenses;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.TabPage tpInternationalLicenses;
        private System.Windows.Forms.Label lblLocalLicensesRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInternationalLicensesRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem miShowLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem miShowInternationalLicense;
    }
}

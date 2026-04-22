namespace DVLD.DriverLicense
{
    partial class frmIssueDriverLicenseFirstTime
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLD.ctrlDrivingLicenseApplicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssueLicense = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 96;
            this.label2.Text = "Notes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(159, 471);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(614, 78);
            this.txtNotes.TabIndex = 94;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseApplicationInfo1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(2, 2);
            this.ctrlDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(788, 465);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(539, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 34);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.BackColor = System.Drawing.Color.White;
            this.btnIssueLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueLicense.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueLicense.Image = global::DVLD.Properties.Resources.License_Type_322;
            this.btnIssueLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueLicense.Location = new System.Drawing.Point(659, 559);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(114, 34);
            this.btnIssueLicense.TabIndex = 98;
            this.btnIssueLicense.Text = "Issue";
            this.btnIssueLicense.UseVisualStyleBackColor = false;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label3
            // 
            this.label3.Image = global::DVLD.Properties.Resources.Notes_32;
            this.label3.Location = new System.Drawing.Point(102, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 32);
            this.label3.TabIndex = 95;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmIssueDriverLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 605);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIssueDriverLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License The First Time";
            this.Load += new System.EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssueLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
    }
}
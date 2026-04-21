namespace DVLD.Tests
{
    partial class frmTakeTest
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.ctrlScheduledTest1 = new DVLD.ctrlScheduledTest();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.lblMessage.Location = new System.Drawing.Point(282, 481);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(220, 25);
            this.lblMessage.TabIndex = 81;
            this.lblMessage.Text = "You cannnot change the result.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlScheduledTest1
            // 
            this.ctrlScheduledTest1.BackColor = System.Drawing.Color.White;
            this.ctrlScheduledTest1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlScheduledTest1.Location = new System.Drawing.Point(2, 2);
            this.ctrlScheduledTest1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlScheduledTest1.Name = "ctrlScheduledTest1";
            this.ctrlScheduledTest1.Size = new System.Drawing.Size(500, 477);
            this.ctrlScheduledTest1.TabIndex = 82;
            //this.ctrlScheduledTest1.TestTypeID = DVLD_Business.clsTestType.enTestType.VisionTest;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 86;
            this.label1.Text = "Result:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Location = new System.Drawing.Point(143, 483);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(52, 21);
            this.rbPass.TabIndex = 87;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Location = new System.Drawing.Point(215, 483);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(45, 21);
            this.rbFail.TabIndex = 88;
            this.rbFail.TabStop = true;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(143, 509);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(354, 78);
            this.txtNotes.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 91;
            this.label2.Text = "Test ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(259, 597);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 34);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(383, 597);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 34);
            this.btnSave.TabIndex = 93;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Image = global::DVLD.Properties.Resources.Notes_32;
            this.label3.Location = new System.Drawing.Point(81, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 36);
            this.label3.TabIndex = 90;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Image = global::DVLD.Properties.Resources.Number_32;
            this.label6.Location = new System.Drawing.Point(81, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 36);
            this.label6.TabIndex = 84;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 643);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.rbFail);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ctrlScheduledTest1);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.frmTakeTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private ctrlScheduledTest ctrlScheduledTest1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}
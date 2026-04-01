using System;
using DVLD.Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            lblID.Text = _ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
                txtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                "Please correct the highlighted validation errors.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Do you want to save the changes?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {

                _ApplicationType.ApplicationTypeTitle = txtTitle.Text.Trim();
                _ApplicationType.ApplicationTypeFees = Convert.ToSingle(txtFees.Text.Trim());

                if (_ApplicationType.Save())
                {
                    MessageBox.Show(
                        "Application Type saved successfully.",
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Error: Could not save the Application Type.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                epError.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                // e.Cancel = false;
                epError.SetError(txtTitle, null);
            }
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                epError.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                // e.Cancel = false;
                epError.SetError(txtFees, null);
            }

            if(!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                epError.SetError(txtFees, "Invalid Number!");
            }
            else
            {
                epError.SetError(txtFees, null);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

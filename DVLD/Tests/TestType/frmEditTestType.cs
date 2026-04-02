using DVLD.Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static DVLD_Business.clsTestType;

namespace DVLD.Test
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            lblID.Text = ((int)_TestTypeID).ToString();
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                txtTitle.Text = _TestType.TestTypeTitle;
                txtDescription.Text = _TestType.TestTypeDescription;
                txtFees.Text = _TestType.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show(
                    "Could not find Test Type with id = " + _TestTypeID.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                epError.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                // e.Cancel = false;
                epError.SetError(txtDescription, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
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

            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                epError.SetError(txtFees, "Invalid Number!");
            }
            else
            {
                epError.SetError(txtFees, null);
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

            if (txtTitle.Text.Trim() == _TestType.TestTypeTitle.Trim() &&
                txtDescription.Text.Trim() == _TestType.TestTypeDescription.Trim() &&
                Convert.ToSingle(txtFees.Text.Trim()) == _TestType.TestTypeFees)
            {
                MessageBox.Show("No changes made.");
                this.Close();
                return;
            }

            if (MessageBox.Show(
                    "Do you want to save the changes?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {

                _TestType.TestTypeTitle = txtTitle.Text.Trim();
                _TestType.TestTypeDescription = txtDescription.Text.Trim();
                _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text.Trim());

                if (_TestType.Save())
                {
                    MessageBox.Show(
                        "Test Type saved successfully.",
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Error: Could not save the Test Type.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txtFees.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

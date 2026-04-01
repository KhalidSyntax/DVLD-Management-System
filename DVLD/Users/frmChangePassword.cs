using System;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        private bool _IsSaving = false;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _User = clsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show(
                    "Could not Find User with id = " + _UserID,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void txtCurrentPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_IsSaving) return;

            if (String.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                epPassword.SetError(txtCurrentPassword, "Current Password is required");
                return;
            }
            else
            {
                // e.Cancel = false;
                epPassword.SetError(txtCurrentPassword, null);
            }
            if (_User.Password != txtCurrentPassword.Text)
            {
                e.Cancel = true;
                epPassword.SetError(txtCurrentPassword, "Current Password is wrong");
                return;
            }
            else
            {
                // e.Cancel = false;
                epPassword.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_IsSaving) return;

            if (String.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                e.Cancel = true;
                epPassword.SetError(txtNewPassword, "New Password is required");
                return;
            }

            if (txtNewPassword.Text.Trim() == txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                epPassword.SetError(txtNewPassword,
                    "New password cannot be the same as current password.");
                return;
            }
            epPassword.SetError(txtNewPassword, null); 
        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_IsSaving) return;

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {

                e.Cancel = true;
                epPassword.SetError(txtConfirmPassword, "Passwords do not match");
            }
            else
            {
                // e.Cancel = false;
                epPassword.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _IsSaving = true;

            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text) &&
                string.IsNullOrWhiteSpace(txtNewPassword.Text) &&
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("No changes made.");
                _IsSaving = false;
                this.Close();
                return;
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fix validation errors");
                _IsSaving = false;
                return;
            }

            if (MessageBox.Show(
                    "Do You Want To Save Data?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_User.ChangePassword(txtNewPassword.Text))
                {
                    MessageBox.Show("Password changed successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetDefualtValues();
                    _IsSaving = false;
                }
                else
                {
                    MessageBox.Show("Error: Data Didn't Save Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _IsSaving = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

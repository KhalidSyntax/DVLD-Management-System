using System;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _UserID = -1;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private bool _HasChanges()
        {
            if (_Mode == enMode.AddNew) return true;
            if (_User == null) return true;

            string UI(string s) => (s ?? "").Trim();
            string DB(string s) => (s ?? "").Trim();

            if (UI(txtUserName.Text) != DB(_User.UserName)) return true;
            if (!String.IsNullOrWhiteSpace(txtPassword.Text) &&
                UI(txtPassword.Text) != DB(_User.Password))
                return true;
            if (chkIsActive.Checked != _User.IsActive) return true;
            
            return false;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show(
                    "No User with ID = " + _UserID,
                    "User Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.FilterEnabled = false;
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if(clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show(
                        "This person already has a user account.\nPlease choose another person.",
                        "Select Another Person",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please select a person first.", "Select a Person",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                epUser.SetError(txtUserName, "User Name is required");
                return;
            }
            else
            {
                // e.Cancel = false;
                epUser.SetError(txtUserName, null);
            }

            if(_Mode == enMode.AddNew)
            {
                if(clsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    epUser.SetError(txtUserName, "username is used by another user");
                }
                else
                    epUser.SetError(txtUserName, null);

            }
            else
            {
                if(_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        epUser.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                        epUser.SetError(txtUserName, null);
                }
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                epUser.SetError(txtPassword, "Password is required");
            }
            else
            {
                // e.Cancel = false;
                epUser.SetError(txtPassword, null);
            }
        }
        
        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                epUser.SetError(txtConfirmPassword, "Passwords do not match");
            }
            else
            {
                // e.Cancel = false;
                epUser.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                    "Some fields are not valid. Hover over the red icons to see the errors.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!_HasChanges())
            {
                MessageBox.Show("No changes to save.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please select a person first.");
                return;
            }

            if (MessageBox.Show(
                    "Do You Want To Save Data?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _User.UserName = txtUserName.Text.Trim();
                _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
                _User.Password = txtPassword.Text.Trim();
                _User.IsActive = chkIsActive.Checked;

                if (_User.Save())
                {
                    lblUserID.Text = _User.UserID.ToString();
                    _Mode = enMode.Update;
                    btnSave.Enabled = true;
                    lblMode.Text = "Update User";

                    MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Didn't Save Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}

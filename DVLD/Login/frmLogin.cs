using System;
using DVLD.Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";

            if (clsGlobal.GetStoredCredential(ref userName, ref password))
            {
                txtUserName.Text = userName;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string
                userName = txtUserName.Text.Trim(),
                password = txtPassword.Text.Trim();

            clsUser user = clsUser.FindByUsernameAndPassword(userName, password);

            if (user != null)
            {
                if (!user.IsActive)
                {
                    MessageBox.Show(
                        "Your account is not Active, Contact Admin.",
                        "In Active Account",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                if (chkRememberMe.Checked)
                    clsGlobal.RememberUsernameAndPassword(userName, password);
                else
                    clsGlobal.RememberUsernameAndPassword("", "");

                MessageBox.Show(
                    "Login successful!\n" +
                    "Welcome back.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                clsGlobal.currentUser = user;

                this.Hide();
                Form frm = new frmMain(this);
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                txtUserName.Focus();

                MessageBox.Show(
                    "Incorrect username or password.\n" +
                    "Please try again.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
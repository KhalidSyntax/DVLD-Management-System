using DVLD.Applications;
using DVLD.Classes;
using DVLD.Login;
using DVLD.People;
using DVLD.Test;
using DVLD.User;
using DVLD.Licenses;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _frmLogin = login;
        }

        private void SetMdiBackColor(Color col)
        {
            foreach(Control ctl in this.Controls)
                if(ctl is MdiClient)
                    ctl.BackColor = col;
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (this.MdiChildren.Length == 0)
                {
                    pbLogo.Visible = true;
                    SetMdiBackColor(SystemColors.Control);
                }
            });
        }

        private void OpenForm(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return;
                }
            }

            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += Frm_FormClosed;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetMdiBackColor(SystemColors.Control);
            pbLogo.Visible = true;
        }

        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                pbLogo.Visible = true;
                SetMdiBackColor(SystemColors.Control);
            }
            else
            {
                pbLogo.Visible = false;
                SetMdiBackColor(Color.Black);
            }
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListUsers());
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListPeople());
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmShowUserInfo(clsGlobal.currentUser.UserID));
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmChangePassword(clsGlobal.currentUser.UserID));
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            pbLogo.Left = (this.ClientSize.Width - pbLogo.Width) / 2;
            pbLogo.Top = (this.ClientSize.Height - pbLogo.Height) / 2;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.currentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListApplicationType());
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListTestTypes());
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAddUpdateLocalDrivingLicenseApplication());
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListLocalDrivingLicenseApplications());
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmListLocalDrivingLicenseApplications());
        }

        private void renewDrivingLiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmRenewLocalDrivingLicenseApplication());
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new frmReplaceLostOrDamagedLicenseApplication());
        }
    }
}

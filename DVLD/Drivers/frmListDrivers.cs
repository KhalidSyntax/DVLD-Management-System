using System;
using System.Data;
using DVLD.People;
using DVLD.Licenses;
using DVLD_Business;
using System.Drawing;
using DVLD.DriverLicense;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable _dtAllDrivers;

        private void _RefreshDriversList()
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();

            dgvDrivers.DataSource = _dtAllDrivers;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
        }

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
            cbFilterBy.SelectedIndex = 0;

            // Header
            dgvDrivers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvDrivers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvDrivers.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 140;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 140;

                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[2].Width = 160;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 300;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 240;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            //if (dgvDrivers.Rows.Count <= 0)
            //    return;

            if (_dtAllDrivers == null)
                return;

            string FilterColumn = "";

            if (cbFilterBy.SelectedItem == null)
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
                lblRecordsCount.Text = _dtAllDrivers.DefaultView.Count.ToString();
                return;
            }

            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "Driver ID": FilterColumn = "DriverID"; break;
                case "Person ID": FilterColumn = "PersonID"; break;
                case "National No": FilterColumn = "NationalNo"; break;
                case "Full Name": FilterColumn = "FullName"; break;
                default: FilterColumn = "None"; break;
            }

            //if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || FilterColumn == "None")
            //{
            //    _dtAllDrivers.DefaultView.RowFilter = "";
            //    lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            //    return;
            //}

            //if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
            //    _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);
            //else
            //    _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text);

            //lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();

            string filter = "";

            if (!string.IsNullOrWhiteSpace(txtFilterValue.Text) && FilterColumn != "None")
            {
                if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                    filter = $"[{FilterColumn}] = {txtFilterValue.Text}";
                else
                    filter = $"[{FilterColumn}] LIKE '{txtFilterValue.Text}%'";
            }

            _dtAllDrivers.DefaultView.RowFilter = filter;
            lblRecordsCount.Text = _dtAllDrivers.DefaultView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllDrivers.DefaultView.RowFilter = "";
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            // lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            lblRecordsCount.Text = _dtAllDrivers.DefaultView.Count.ToString();
        }

        private void miShowPersonInfo_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(
                (int)dgvDrivers.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void miShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory((int)dgvDrivers.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvDrivers_DoubleClick(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm =
                new frmShowLicenseInfo((int)dgvDrivers.CurrentRow.Cells[0].Value);


            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
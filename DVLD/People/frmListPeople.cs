using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private DataTable _dtPeople;
        private DataTable _dtAllPeople;

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();

            _dtPeople = _dtAllPeople.DefaultView.ToTable(false,
            "PersonID",
            "NationalNo",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "GenderCaption",
            "DateOfBirth",
            "CountryName",
            "Phone",
            "Email");

            dgvPeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cbFilterBy.SelectedIndex = 0;

            // Header
            dgvPeople.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvPeople.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 140;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[7].Width = 140;

                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[9].Width = 120;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 170;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtPeople.Rows.Count <= 0)
            {
                return;
            }

            string FilterColumn = "";

            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "Person ID": FilterColumn = "PersonID"; break;
                case "National No": FilterColumn = "NationalNo"; break;
                case "First Name": FilterColumn = "FirstName"; break;
                case "Second Name": FilterColumn = "SecondName"; break;
                case "Third Name": FilterColumn = "ThirdName"; break;
                case "Last Name": FilterColumn = "LastName"; break;
                case "Nationality": FilterColumn = "CountryName"; break;
                case "Gender": FilterColumn = "GenderCaption"; break;
                case "Phone": FilterColumn = "Phone"; break;
                case "Email": FilterColumn = "Email"; break;
                default: FilterColumn = "None"; break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text);

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();

            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void miShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = ((int)dgvPeople.CurrentRow.Cells[0].Value);

            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void miAddNew_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            int PersonID = ((int)dgvPeople.CurrentRow.Cells[0].Value);

            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            int PersonID = ((int)dgvPeople.CurrentRow.Cells[0].Value);
            string PersonImage = clsPerson.Find(PersonID).ImagePath;

            if (MessageBox.Show(
                    "Are you sure you want to delete person [" + PersonID + "]",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    if (PersonImage != "" && File.Exists(PersonImage))
                        File.Delete(PersonImage);

                    MessageBox.Show("Person Deleted Successfully.",
                        "Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show(
                        "Person was not deleted because it has data linked to it.",
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }

        private void miSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void miPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

using DVLD.Applications;
using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private DataTable _dtAllTestTypes;

        private void _RefreshTestTypesList()
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();

            dgvTestTypes.DataSource = _dtAllTestTypes;
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void frmListTestType_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();

            // Header
            dgvTestTypes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvTestTypes.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            dgvTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 110;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 180;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 380;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 140;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType(
                ((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshTestTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

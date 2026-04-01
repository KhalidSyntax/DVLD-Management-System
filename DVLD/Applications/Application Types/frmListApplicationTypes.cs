using System;
using System.Data;
using DVLD_Business;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmListApplicationType : Form
    {
        private DataTable _dtAllApplicationTypes;

        private void _RefreshApplicationTypesList()
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();

            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();
        }

        public frmListApplicationType()
        {
            InitializeComponent();
        }

        private void frmListApplicationType_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();

            // Header
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvApplicationTypes.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 110;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 280;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 140;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType(((int)dgvApplicationTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _RefreshApplicationTypesList();
            // frmListApplicationType_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

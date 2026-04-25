using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpcMock
{
    public partial class CreateProtocolDialog : Form
    {
        public OpcMockProtocol OpcMockProtocol { get; internal set; }

        public CreateProtocolDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblMissingProtocolName.Hide();
        }

        private void btnCreateProtocol_Click(object sender, EventArgs e)
        {
            OpcMockProtocol = new OpcMockProtocol(tbProtocolName.Text);

            this.DialogResult = DialogResult.OK;

            this.Hide();
        }

        private void tbProtocolName_Validating(object sender, CancelEventArgs e)
        {
            lblMissingProtocolName.Hide();

            if (string.IsNullOrWhiteSpace(tbProtocolName.Text))
            {
                lblMissingProtocolName.Show();
                e.Cancel = true;
            }
        }
    }
}

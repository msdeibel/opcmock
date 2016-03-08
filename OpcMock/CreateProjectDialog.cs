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
    public partial class CreateProjectDialog : Form
    {
        OpcMockProject opcMockProject;

        public CreateProjectDialog()
        {
            InitializeComponent();
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            opcMockProject = new OpcMockProject(tbProjectName.Text);

            this.DialogResult = DialogResult.OK;

            this.Hide();
        }

        public OpcMockProject Project {
            get
            {
                return opcMockProject;
            }
        }

        public string ProjectFolderPath
        {
            get
            {
                return tbProjectFilePath.Text;
            }
        }

        private void btnFdbDialog_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(fbdProjectPath.ShowDialog()))
            {
                tbProjectFilePath.Text = fbdProjectPath.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblMissingProjectName.Hide();
            lblMissingProjectPath.Hide();
        }

        private void tbProjectName_Validating(object sender, CancelEventArgs e)
        {
            lblMissingProjectName.Hide();

            if (string.IsNullOrWhiteSpace(tbProjectName.Text))
            {
                lblMissingProjectName.Show();
                e.Cancel = true;
            }
        }

        private void tbProjectFilePath_Validating(object sender, CancelEventArgs e)
        {
            lblMissingProjectPath.Hide();

            if (string.IsNullOrWhiteSpace(tbProjectFilePath.Text))
            {
                lblMissingProjectPath.Show();
                e.Cancel = true;
            }
        }
    }
}

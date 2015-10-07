using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace OpcMock
{
    public partial class DemoForm : Form
    {
        ///FIXME: Overview doesn't need to know about lockfiles

        private string FILE_EXT_DATA = ".csv";
        private string FILE_EXT_LOCK = ".lck";

        private string projectFilePath;
        private string lockFilePath;

        private OpcReader opcReader;
        private OpcWriter opcWriter;

        public DemoForm()
        {
            InitializeComponent();

            projectFilePath = string.Empty;
            lockFilePath = string.Empty;

            SetDgvPropertiesThatTheDesignerKeepsLosing();

            fdDataFile.Filter = "OPC Mock Data|*.csv";
        }

        private void SetDgvPropertiesThatTheDesignerKeepsLosing()
        {
            this.TagQualityText.DataSource = Enum.GetNames(typeof(OpcTag.OpcTagQuality));
            this.dgvOpcData.CurrentCellDirtyStateChanged += dgvOpcData_CurrentCellDirtyStateChanged;
        }

        private void btnProjectFileDialog_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(fdDataFile.ShowDialog(this)))
            {
                projectFilePath = fdDataFile.FileName;
                File.Create(projectFilePath).Close();

                lockFilePath = projectFilePath.Replace(FILE_EXT_DATA, FILE_EXT_LOCK);

                opcReader = new OpcReaderCsv(projectFilePath, lockFilePath);
            }
        }

        private void btnReadOpcData_Click(object sender, EventArgs e)
        {
            FillOpcDataGrid(opcReader.ReadAllTags());
        }

        private void FillOpcDataGrid(List<OpcTag> opcTags)
        {
            dgvOpcData.Rows.Clear();

            foreach (OpcTag o in opcTags)
            {
                int newRowIndex = dgvOpcData.Rows.Add();

                dgvOpcData.Rows[newRowIndex].Cells[0].Value = o.TagPath;
                dgvOpcData.Rows[newRowIndex].Cells[1].Value = o.Value;
                dgvOpcData.Rows[newRowIndex].Cells[2].Value = o.Quality.ToString();
                dgvOpcData.Rows[newRowIndex].Cells[3].Value = ((int)o.Quality).ToString();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(projectFilePath))
            {
                MessageBox.Show("Set target file tagPath!");
                
                return;
            }

            WriteDataToProjectFile();
        }

        private void WriteDataToProjectFile()
        {
            opcWriter = new OpcWriterCsv(projectFilePath, lockFilePath);
            OpcTag tempOpcTag;
            List<OpcTag> tagDataFromDgv = new List<OpcTag>();

            if (dgvOpcData.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvOpcData.Rows)
                {
                    if (dgvr.Index < dgvOpcData.Rows.Count - 1)
                    {
                        OpcTag.OpcTagQuality qualityFromInt = (OpcTag.OpcTagQuality)(Convert.ToInt32(dgvr.Cells[3].FormattedValue));

                        tempOpcTag = new OpcTag(dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString(), qualityFromInt);

                        tagDataFromDgv.Add(tempOpcTag);
                    }
                }

                opcWriter.WriteAllTags(tagDataFromDgv);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetFilePath"></param>
        /// <exception cref="MockOPC.NotProjectFileException"></exception>
        private void CheckProjectFilePathValue()
        {
            if (string.IsNullOrWhiteSpace(projectFilePath))
            {
                throw new NoProjectFileException();
            }
        }

        void dgvOpcData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewCell currentCell = dgvOpcData.CurrentCell;

            dgvOpcData.CommitEdit(new DataGridViewDataErrorContexts());

            if (currentCell.OwningColumn.Name.Equals("TagQualityText"))
            {
                string workingValue = (currentCell.Value != null) ? currentCell.Value.ToString() : "192";

                dgvOpcData.Rows[currentCell.RowIndex].Cells["TagQualityValue"].Value = ((int)(Enum.Parse(typeof(OpcTag.OpcTagQuality), workingValue))).ToString();
            }
        }

    }
}

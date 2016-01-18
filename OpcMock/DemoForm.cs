using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using OpcMock.Properties;

namespace OpcMock
{
    public partial class DemoForm : Form
    {
        ///FIXME: Overview doesn't need to know about lockfiles

        private string FILE_EXT_DATA = ".csv";
        private string FILE_EXT_LOCK = ".lck";

        private string dataFilePath;
        private string lockFilePath;

        private OpcReader opcReader;
        private OpcWriter opcWriter;

        private int currentProtocolLine;

        public DemoForm()
        {
            InitializeComponent();

            dataFilePath = string.Empty;
            lockFilePath = string.Empty;

            SetDgvPropertiesThatTheDesignerKeepsLosing();

            fdDataFile.Filter = @"OPC Mock Data|*.csv";

            currentProtocolLine = 0;
        }

        private void DemoForm_Load(object sender, EventArgs e)
        {

        }

        private void SetDgvPropertiesThatTheDesignerKeepsLosing()
        {
            TagQualityText.DataSource = Enum.GetNames(typeof(OpcTag.OpcTagQuality));
            dgvOpcData.CurrentCellDirtyStateChanged += dgvOpcData_CurrentCellDirtyStateChanged;
        }

        private void btnProjectFileDialog_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(fdDataFile.ShowDialog(this)))
            {
                dataFilePath = fdDataFile.FileName;
                if (!File.Exists(dataFilePath))
                {
                    File.Create(dataFilePath).Close();
                }

                lockFilePath = dataFilePath.Replace(FILE_EXT_DATA, FILE_EXT_LOCK);

                opcReader = new OpcReaderCsv(dataFilePath, lockFilePath);
                opcWriter = new OpcWriterCsv(dataFilePath, lockFilePath);
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

                dgvOpcData.Rows[newRowIndex].Cells[0].Value = o.Path;
                dgvOpcData.Rows[newRowIndex].Cells[1].Value = o.Value;
                dgvOpcData.Rows[newRowIndex].Cells[2].Value = o.Quality.ToString();
                dgvOpcData.Rows[newRowIndex].Cells[3].Value = ((int)o.Quality).ToString();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dataFilePath))
            {
                MessageBox.Show(Resources.DemoForm_btnSaveData_Click_Set_target_file_tagPath_);
                
                return;
            }

            WriteDataToFile();
        }

        private void WriteDataToFile()
        {
            if (dgvOpcData.Rows.Count <= 0) return;

            List<OpcTag> tagDataFromDgv = (from DataGridViewRow dgvr in dgvOpcData.Rows
                                           where (dgvr.Index < dgvOpcData.Rows.Count - 1 
                                                    && dgvr.Cells[0].Value != null
                                                    && dgvr.Cells[1].Value != null)
                                           let qualityFromInt = (OpcTag.OpcTagQuality) Convert.ToInt32(dgvr.Cells[3].FormattedValue)
                                           select new OpcTag(dgvr.Cells[0].Value.ToString(), dgvr.Cells[1].Value.ToString(), qualityFromInt)).ToList();

            opcWriter.WriteAllTags(tagDataFromDgv);
        }

        void dgvOpcData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewCell currentCell = dgvOpcData.CurrentCell;

            dgvOpcData.CommitEdit(new DataGridViewDataErrorContexts());

            if (currentCell.OwningColumn.Name.Equals("TagQualityText"))
            {
                string workingValue = currentCell.Value?.ToString() ?? OpcTag.OpcTagQuality.Good.ToString();

                dgvOpcData.Rows[currentCell.RowIndex].Cells["TagQualityValue"].Value = ((int)Enum.Parse(typeof(OpcTag.OpcTagQuality), workingValue)).ToString();
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            string lineToExecute = rtbProtocol.Lines[currentProtocolLine];

            ExecuteProtocolLine(lineToExecute);
        }

        ///FIXME: seperator should be a configuration
        private void ExecuteProtocolLine(string lineToExecute) 
        {
            string[] lineParts = lineToExecute.Split(';');

            //step or wait
            string action = lineParts[0];

            

            if (action.Equals("set"))
            {
                string tagName = lineParts[1];
                string tagValue = lineParts[2];
                string tagQuality = lineParts[3];

                OpcTag.OpcTagQuality qualityFromInt = (OpcTag.OpcTagQuality)Convert.ToInt32(tagQuality);

                opcWriter.WriteSingleTag(new OpcTag(tagName, tagValue, qualityFromInt));

                FillOpcDataGrid(opcReader.ReadAllTags());

                currentProtocolLine++;
            }
            else if (action.Equals("wait"))
            {
                string tagName = lineParts[1];
                string tagValue = lineParts[2];
                string tagQuality = lineParts[3];

                List<OpcTag> opcTagList = opcReader.ReadAllTags();

                OpcTag tagToCheck = new OpcTag(tagName, tagValue, OpcTag.OpcTagQuality.Good);

                if(opcTagList.Contains(tagToCheck))
                {
                    FillOpcDataGrid(opcTagList);

                    currentProtocolLine++;
                }
            }
            else if (action.Equals("dummy"))
            {
                currentProtocolLine++;
            }
            else
            {
                throw new Exception("Illegal protocol action");
            }
        }


    }
}

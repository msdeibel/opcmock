using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using OpcMock.Properties;

namespace OpcMock
{
    public partial class DemoForm : Form
    {
        

        private string dataFilePath;
        private string projectFilePath;
        private string protocolFilePath;
        private OpcMockProject opcMockProject;
        private ProjectFileWriter projectFileWriter;

        private OpcReader opcReader;
        private OpcWriter opcWriter;

        private int currentProtocolLine;

        public DemoForm()
        {
            InitializeComponent();

            SetDgvPropertiesThatTheDesignerKeepsLosing();

            InitializeMembers();
        }

        private void SetDgvPropertiesThatTheDesignerKeepsLosing()
        {
            TagQualityText.DataSource = Enum.GetNames(typeof(OpcTag.OpcTagQuality));
            dgvOpcData.CurrentCellDirtyStateChanged += dgvOpcData_CurrentCellDirtyStateChanged;
        }

        private void InitializeMembers()
        {
            dataFilePath = string.Empty;

            sfdProjectFile.Filter = @"OPC Mock Project|*" + FileExtensionContants.FileExtensionProject;

            currentProtocolLine = 0;
        }

        private void btnReadOpcData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dataFilePath)) return;

            FillOpcDataGrid(opcReader.ReadAllTags());
        }

        private void EnableButtonsAfterDataFileLoad()
        {
            btnSaveData.Enabled = true;
            btnReadOpcData.Enabled = true;
            btnStep.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(dataFilePath)) return;

            string lineToExecute = rtbProtocol.Lines[currentProtocolLine];

            ExecuteProtocolLine(lineToExecute);

            IncrementCurrentProtocolLine();

        }

        private static bool IsEndOfProtocol(string lineToExecute)
        {
            return string.IsNullOrWhiteSpace(lineToExecute);
        }

        private void ExecuteProtocolLine(string lineToExecute) 
        {
            try
            {
                ProtocolLine protocolLine = new ProtocolLine(lineToExecute);

                if (protocolLine.Action.Equals(ProtocolLine.Actions.Set))
                {
                    SetSingleTagFromProtocol(protocolLine);
                }
                else if (protocolLine.Action.Equals(ProtocolLine.Actions.Wait))
                {
                    CheckExpectedTagFromProtocol(protocolLine);
                }
                else if (protocolLine.Action.Equals(ProtocolLine.Actions.Dummy))
                {
                    //Do nothing
                }
            }
            catch (ProtocolActionException)
            {
                MessageBox.Show("Invalid protocol action for line: " + lineToExecute);
            }
        }

        private void SetSingleTagFromProtocol(ProtocolLine protocolLine)
        {
            OpcTag.OpcTagQuality qualityFromInt =
                (OpcTag.OpcTagQuality)Convert.ToInt32(protocolLine.TagQualityInt);
            opcWriter.WriteSingleTag(new OpcTag(protocolLine.TagPath, protocolLine.TagValue, qualityFromInt));

            FillOpcDataGrid(opcReader.ReadAllTags());
        }

        private void CheckExpectedTagFromProtocol(ProtocolLine protocolLine)
        {
            List<OpcTag> opcTagList = opcReader.ReadAllTags();

            OpcTag.OpcTagQuality qualityFromInt =
                (OpcTag.OpcTagQuality)Convert.ToInt32(protocolLine.TagQualityInt);
            OpcTag tagToCheck = new OpcTag(protocolLine.TagPath, protocolLine.TagValue, qualityFromInt);

            if (opcTagList.Contains(tagToCheck))
            {
                FillOpcDataGrid(opcTagList);
            }
        }

        private void IncrementCurrentProtocolLine()
        {
            currentProtocolLine++;

            if (IsEndOfProtocol(rtbProtocol.Lines[currentProtocolLine]))
            {
                btnStep.Text = "Done";
                btnStep.Enabled = false;
                btnResetProtocol.Enabled = true;
            }
            else
            {
                btnStep.Text = "Execute step " + (currentProtocolLine + 1);
            }
        }

        private void btnSaveProjectFile_Click(object sender, EventArgs e)
        {
            projectFileWriter.SaveProjectFileContent();
        }

        private void btnFdbDialog_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = fbdProjectPath.ShowDialog();

            if (dialogResult.Equals(DialogResult.OK))
            {
                tbProjectFilePath.Text = fbdProjectPath.SelectedPath;
            }
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbProjectName.Text)) { return; }

            opcMockProject = new OpcMockProject(tbProjectName.Text);

            projectFileWriter = new ProjectFileWriter(tbProjectFilePath.Text, opcMockProject.Name);
            projectFileWriter.SaveProjectFileContent();

            dataFilePath = projectFileWriter.FolderPath + Path.DirectorySeparatorChar + opcMockProject.Name + FileExtensionContants.FileExtensionData;

            if (!File.Exists(dataFilePath))
            {
                File.Create(dataFilePath).Close();
            }

            opcReader = new OpcReaderCsv(dataFilePath);
            opcWriter = new OpcWriterCsv(dataFilePath);

            EnableButtonsAfterDataFileLoad();
        }

        private void btnResetProtocol_Click(object sender, EventArgs e)
        {
            currentProtocolLine = -1;
            btnResetProtocol.Enabled = false;

            IncrementCurrentProtocolLine();
            btnStep.Enabled = true;
        }
    }
}

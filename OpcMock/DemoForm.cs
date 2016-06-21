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
        

        //private string dataFilePath;
        private string projectFilePath;
        private string projectFolderPath;
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
            sfdProjectFile.Filter = @"OPC Mock Project|*" + FileExtensionContants.FileExtensionProject;

            currentProtocolLine = 0;
        }

        private void btnReadOpcData_Click(object sender, EventArgs e)
        {
            if (!isDataFilePathSet())
            {
                HandleEmptyDataFilePathOnSaveData();
            }
            else
            {
                FillOpcDataGrid(opcReader.ReadAllTags());
            }
        }

        private void FillOpcDataGrid(List<OpcTag> opcTags)
        {
            dgvOpcData.Rows.Clear();

            foreach (OpcTag opcTag in opcTags)
            {
                AddRowToDataGridView(opcTag);
            }

            //Avoid first data cell starting as "Edit" and therefore being cleared
            dgvOpcData.CurrentCell = dgvOpcData.Rows[dgvOpcData.RowCount - 1].Cells[0];
        }

        private void AddRowToDataGridView(OpcTag opcTag)
        {
            int newRowIndex = dgvOpcData.Rows.Add();

            dgvOpcData.Rows[newRowIndex].Cells[0].Value = opcTag.Path;
            dgvOpcData.Rows[newRowIndex].Cells[1].Value = opcTag.Value;
            dgvOpcData.Rows[newRowIndex].Cells[2].Value = opcTag.Quality.ToString();
            dgvOpcData.Rows[newRowIndex].Cells[3].Value = ((int)opcTag.Quality).ToString();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (!isDataFilePathSet())
            {
                HandleEmptyDataFilePathOnSaveData();
            }
            else
            {
                WriteData();
            }
        }

        private bool isDataFilePathSet()
        {
            return !string.IsNullOrEmpty(DataFilePath());
        }

        private static void HandleEmptyDataFilePathOnSaveData()
        {
            MessageBox.Show(Resources.DemoForm_btnSaveData_Click_Set_target_file_tagPath_);
        }

        private void WriteData()
        {
            if (dgvOpcData.Rows.Count <= 0) return;
            List<OpcTag> tagDataFromDgv = GenerateTagListFromDataGridView();

            opcWriter.WriteAllTags(tagDataFromDgv);
        }

        private List<OpcTag> GenerateTagListFromDataGridView()
        {
            return (from DataGridViewRow dgvr in dgvOpcData.Rows
                    where (dgvr.Index < dgvOpcData.Rows.Count - 1
                             && dgvr.Cells["TagName"].Value != null
                             && dgvr.Cells["TagValue"].Value != null)
                    let qualityFromInt = (OpcTag.OpcTagQuality)Convert.ToInt32(dgvr.Cells["TagQualityValue"].FormattedValue)
                    select new OpcTag(dgvr.Cells["TagName"].Value.ToString(), dgvr.Cells["TagValue"].Value.ToString(), qualityFromInt)).ToList();
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
            if (!isDataFilePathSet()) return;

            ExecuteProtocolLine();
        }

        private static bool IsEndOfProtocol(string lineToExecute)
        {
            return string.IsNullOrWhiteSpace(lineToExecute);
        }

        private void ExecuteProtocolLine() 
        {
            string lineToExecute = tbProtocol.Lines[currentProtocolLine];

            try
            {
                ProtocolLine protocolLine = new ProtocolLine(lineToExecute);

                switch (protocolLine.Action)
                {
                    case ProtocolLine.Actions.Set:
                        {
                            SetSingleTagFromProtocol(protocolLine);
                            break;
                        }
                    case ProtocolLine.Actions.Wait:
                        {
                            CheckExpectedTagFromProtocol(protocolLine);
                            break;
                        }
                    case ProtocolLine.Actions.Dummy:
                        {
                            IncrementCurrentProtocolLine();
                            break;
                        }
                    default: break;
                }
            }
            catch (ProtocolActionException)
            {
                MessageBox.Show("Invalid protocol action for line: " + lineToExecute);
            }
        }

        private void SetSingleTagFromProtocol(ProtocolLine protocolLine)
        {
            opcWriter.WriteSingleTag(new OpcTag(protocolLine.TagPath, protocolLine.TagValue, OpcTagQualityFromInteger(protocolLine.TagQualityInt)));

            IncrementCurrentProtocolLine();

            FillOpcDataGrid(opcReader.ReadAllTags());
        }

        private OpcTag.OpcTagQuality OpcTagQualityFromInteger(string qualityAsString)
        {
            return (OpcTag.OpcTagQuality)Convert.ToInt32(qualityAsString);
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
                IncrementCurrentProtocolLine();
            }
        }

        private void IncrementCurrentProtocolLine()
        {
            currentProtocolLine++;

            if (IsEndOfProtocol(tbProtocol.Lines[currentProtocolLine]))
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

        private void btnResetProtocol_Click(object sender, EventArgs e)
        {
            currentProtocolLine = -1;
            btnResetProtocol.Enabled = false;

            IncrementCurrentProtocolLine();
            btnStep.Enabled = true;
        }

        #region File menu handlers

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateProjectDialog cpd = new CreateProjectDialog();
            cpd.StartPosition = FormStartPosition.CenterParent;

            if (DialogResult.OK.Equals(cpd.ShowDialog(this)))
            {
                opcMockProject = cpd.Project;

                opcMockProject.OnProtocolAdded += new OpcMockProject.ProtocolHandler(opcMockProject_OnProtocolAdded);

                projectFolderPath = cpd.ProjectFolderPath;

                projectFileWriter = new ProjectFileWriter(opcMockProject, projectFolderPath);

                projectFileWriter.Save();

                if (!File.Exists(DataFilePath()))
                {
                    File.Create(DataFilePath()).Close();
                }

                opcReader = new OpcReaderCsv(DataFilePath());
                opcWriter = new OpcWriterCsv(DataFilePath());

                Text = "OPC Mock - " + opcMockProject.Name;
                EnableButtonsAfterDataFileLoad();
            }

            cpd.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(ofdProjectFile.ShowDialog(this)))
            {
                projectFilePath = ofdProjectFile.FileName;
                projectFolderPath = Path.GetDirectoryName(projectFilePath);

                ProjectFileReader pfr = new ProjectFileReader(projectFilePath);

                opcMockProject = pfr.OpcMockProject;

                opcMockProject.OnProtocolAdded += new OpcMockProject.ProtocolHandler(opcMockProject_OnProtocolAdded);

                projectFileWriter = new ProjectFileWriter(opcMockProject, projectFolderPath);

                if (!File.Exists(DataFilePath()))
                {
                    File.Create(DataFilePath()).Close();
                }

                opcReader = new OpcReaderCsv(DataFilePath());
                opcWriter = new OpcWriterCsv(DataFilePath());

                FillOpcDataGrid(opcReader.ReadAllTags());

                Text = "OPC Mock - " + opcMockProject.Name;
                EnableButtonsAfterDataFileLoad();
            }
        }

        private void EnableButtonsAfterDataFileLoad()
        {
            btnSaveTags.Enabled = true;
            btnReadTags.Enabled = true;
            btnStep.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectFileWriter.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private string DataFilePath()
        {
            return projectFolderPath + Path.DirectorySeparatorChar + opcMockProject.Name + FileExtensionContants.FileExtensionData;
        }

        private string GetProjectFolderPath()
        {
            return Path.GetDirectoryName(projectFilePath);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateProtocolDialog cpd = new CreateProtocolDialog();
            cpd.StartPosition = FormStartPosition.CenterParent;

            if (DialogResult.OK.Equals(cpd.ShowDialog(this)))
            {
                try
                {
                    opcMockProject.AddProtocol(cpd.OpcMockProtocol);
                }
                catch (DuplicateProtocolNameException exProtocolName)
                {
                    MessageBox.Show(this, exProtocolName.Message + "\n" + exProtocolName.ProtocolName, "Protocol exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            cpd.Dispose();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (cbProtocols.SelectedIndex > 0)
            {
                ProtocolWriter protocolWriter = new ProtocolWriter(GetProjectFolderPath(), opcMockProject.Name);

                OpcMockProtocol currentProtocol = new OpcMockProtocol(cbProtocols.SelectedText);

                foreach (string line in tbProtocol.Lines)
                {
                    try
                    {
                        currentProtocol.Append(new ProtocolLine(line));
                    }
                    catch (ArgumentException)
                    {
                        //End of protocol reached
                    }
                }

                protocolWriter.Save(currentProtocol);
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProtocolWriter protocolWriter = new ProtocolWriter(GetProjectFolderPath(), opcMockProject.Name);

            foreach (OpcMockProtocol omp in opcMockProject.Protocols)
            {
                protocolWriter.Save(omp);
            }
        }

        private void opcMockProject_OnProtocolAdded(object sender, ProtocolAddedArgs protocolAddedArgs)
        {
            UpdateProtocolComboBox();
        }

        private void UpdateProtocolComboBox()
        {
            cbProtocols.Items.Clear();

            opcMockProject.Protocols.Sort(new ProtocolComparer());

            cbProtocols.Items.Add(string.Empty);

            foreach (OpcMockProtocol omp in opcMockProject.Protocols)
            {
                cbProtocols.Items.Add(omp.ToString());
            }

            cbProtocols.SelectedIndex = 0;
        }

        private void cbProtocols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProtocols.SelectedIndex > 0)
            {
                foreach (OpcMockProtocol omp in opcMockProject.Protocols)
                {
                    if (omp.Name.Equals(cbProtocols.SelectedText))
                    {
                        tbProtocol.Clear();

                        foreach (ProtocolLine pl in omp.Lines)
                        { 
                            tbProtocol.AppendText(pl.ToString());
                        }
                    }
                }
            }
        }
    }
}

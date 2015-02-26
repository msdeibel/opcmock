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
    public partial class Overview : Form
    {
        private int LOCK_ACQUISITION_RETRY_INTERVALL_IN_MS = 500;
        
        private string FILE_EXT_DATA = ".omd";
        private string FILE_EXT_LOCK = ".lck";

        private string projectFilePath;
        private string lockFilePath;

        private OpcReader opcReader;

        public Overview()
        {
            InitializeComponent();

            projectFilePath = string.Empty;
            lockFilePath = string.Empty;

            SetDgvPropertiesThatTheDesignerKeepsLosing();
        }

        private void SetDgvPropertiesThatTheDesignerKeepsLosing()
        {
            this.TagQualityText.DataSource = Enum.GetNames(typeof(OpcTag.OpcTagQuality));
            this.dgvOpcData.CurrentCellDirtyStateChanged += dgvOpcData_CurrentCellDirtyStateChanged;
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

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(projectFilePath))
            {
                MessageBox.Show("Set target file tagPath!");
                
                return;
            }

            WriteDataToProjectFile();
        }

        private void WaitForAndAcquireFileLock()
        {
            bool lockAcquired = false;

            while (!lockAcquired)
            {
                try
                {
                    File.Create(lockFilePath).Close();

                    lockAcquired = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(LOCK_ACQUISITION_RETRY_INTERVALL_IN_MS);
                }
            }
        }

        private void WriteDataToProjectFile()
        {
            WaitForAndAcquireFileLock();

            FileStream dataFileStream = File.Open(projectFilePath, FileMode.Create);

            StreamWriter streamWriter = new StreamWriter(dataFileStream);

            try
            {
                if (dgvOpcData.RowCount > 0)
                {
                    foreach (DataGridViewRow dgvr in dgvOpcData.Rows)
                    {

                        if (dgvr.Index < dgvOpcData.RowCount - 1)
                        {
                            streamWriter.WriteLine(dgvr.Cells[0].FormattedValue.ToString() + ';'
                                                    + dgvr.Cells[1].FormattedValue.ToString() + ';'
                                                    + dgvr.Cells[2].FormattedValue.ToString() + ';'
                                                    + dgvr.Cells[3].FormattedValue.ToString()
                                                    );
                        }
                    }
                }

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception)
            {
                //void
            }
            finally
            {
                dataFileStream.Close();
                ReleaseFileLock();
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

        private void ReleaseFileLock()
        {
            File.Delete(lockFilePath);
        }

        private void btnProjectFileDialog_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK.Equals(projectFileDialog.ShowDialog(this)))
            {
                projectFilePath = projectFileDialog.FileName;
                File.Create(projectFilePath).Close();

                lockFilePath = projectFilePath.Replace(FILE_EXT_DATA, FILE_EXT_LOCK);

                opcReader = new OpcReaderCsv(projectFilePath, lockFilePath);
            }
        }
    }
}

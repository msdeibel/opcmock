using System;
namespace OpcMock
{
    partial class DemoForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOpcData = new System.Windows.Forms.DataGridView();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagQualityText = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TagQualityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnReadOpcData = new System.Windows.Forms.Button();
            this.sfdDataFile = new System.Windows.Forms.SaveFileDialog();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.rtbProtocol = new System.Windows.Forms.RichTextBox();
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.tbProjectFilePath = new System.Windows.Forms.TextBox();
            this.sfdProjectFile = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveProjectFile = new System.Windows.Forms.Button();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.fbdProjectPath = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFdbDialog = new System.Windows.Forms.Button();
            this.gbProjectInformation = new System.Windows.Forms.GroupBox();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnResetProtocol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).BeginInit();
            this.gbProjectInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOpcData
            // 
            this.dgvOpcData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpcData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagName,
            this.TagValue,
            this.TagQualityText,
            this.TagQualityValue});
            this.dgvOpcData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOpcData.Location = new System.Drawing.Point(12, 209);
            this.dgvOpcData.Name = "dgvOpcData";
            this.dgvOpcData.Size = new System.Drawing.Size(560, 210);
            this.dgvOpcData.TabIndex = 0;
            // 
            // TagName
            // 
            this.TagName.HeaderText = "TagName";
            this.TagName.Name = "TagName";
            // 
            // TagValue
            // 
            this.TagValue.HeaderText = "TagValue";
            this.TagValue.Name = "TagValue";
            // 
            // TagQualityText
            // 
            dataGridViewCellStyle3.NullValue = "Good";
            this.TagQualityText.DefaultCellStyle = dataGridViewCellStyle3;
            this.TagQualityText.HeaderText = "TagQualityText";
            this.TagQualityText.Name = "TagQualityText";
            this.TagQualityText.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TagQualityText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TagQualityValue
            // 
            dataGridViewCellStyle4.NullValue = "192";
            this.TagQualityValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.TagQualityValue.HeaderText = "TagQualityValue";
            this.TagQualityValue.Name = "TagQualityValue";
            this.TagQualityValue.ReadOnly = true;
            // 
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Location = new System.Drawing.Point(12, 429);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 31);
            this.btnSaveData.TabIndex = 4;
            this.btnSaveData.Text = "Save data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnReadOpcData
            // 
            this.btnReadOpcData.Enabled = false;
            this.btnReadOpcData.Location = new System.Drawing.Point(93, 429);
            this.btnReadOpcData.Name = "btnReadOpcData";
            this.btnReadOpcData.Size = new System.Drawing.Size(75, 31);
            this.btnReadOpcData.TabIndex = 5;
            this.btnReadOpcData.Text = "Read data";
            this.btnReadOpcData.UseVisualStyleBackColor = true;
            this.btnReadOpcData.Click += new System.EventHandler(this.btnReadOpcData_Click);
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(600, 193);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(46, 13);
            this.lblProtocol.TabIndex = 8;
            this.lblProtocol.Text = "Protocol";
            // 
            // btnStep
            // 
            this.btnStep.Enabled = false;
            this.btnStep.Location = new System.Drawing.Point(603, 429);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(127, 31);
            this.btnStep.TabIndex = 12;
            this.btnStep.Text = "Execute step 1";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // rtbProtocol
            // 
            this.rtbProtocol.Location = new System.Drawing.Point(603, 209);
            this.rtbProtocol.Name = "rtbProtocol";
            this.rtbProtocol.Size = new System.Drawing.Size(287, 210);
            this.rtbProtocol.TabIndex = 13;
            this.rtbProtocol.Text = "Set;tagToSet;newValue;192\nDummy\nWait;tagToWaitFor;expectedValue;192\n";
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Location = new System.Drawing.Point(7, 66);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(64, 13);
            this.lblProjectPath.TabIndex = 14;
            this.lblProjectPath.Text = "Project path";
            // 
            // tbProjectFilePath
            // 
            this.tbProjectFilePath.Location = new System.Drawing.Point(10, 82);
            this.tbProjectFilePath.Name = "tbProjectFilePath";
            this.tbProjectFilePath.Size = new System.Drawing.Size(528, 20);
            this.tbProjectFilePath.TabIndex = 15;
            this.tbProjectFilePath.Text = "d:\\temp\\opcmock";
            // 
            // btnSaveProjectFile
            // 
            this.btnSaveProjectFile.Location = new System.Drawing.Point(727, 76);
            this.btnSaveProjectFile.Name = "btnSaveProjectFile";
            this.btnSaveProjectFile.Size = new System.Drawing.Size(151, 31);
            this.btnSaveProjectFile.TabIndex = 17;
            this.btnSaveProjectFile.Text = "Save project";
            this.btnSaveProjectFile.UseVisualStyleBackColor = true;
            this.btnSaveProjectFile.Click += new System.EventHandler(this.btnSaveProjectFile_Click);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(6, 16);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(69, 13);
            this.lblProjectName.TabIndex = 18;
            this.lblProjectName.Text = "Project name";
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(10, 32);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(194, 20);
            this.tbProjectName.TabIndex = 19;
            this.tbProjectName.Text = "testProject001";
            // 
            // btnFdbDialog
            // 
            this.btnFdbDialog.Location = new System.Drawing.Point(544, 79);
            this.btnFdbDialog.Name = "btnFdbDialog";
            this.btnFdbDialog.Size = new System.Drawing.Size(45, 23);
            this.btnFdbDialog.TabIndex = 20;
            this.btnFdbDialog.Text = "Path";
            this.btnFdbDialog.UseVisualStyleBackColor = true;
            this.btnFdbDialog.Click += new System.EventHandler(this.btnFdbDialog_Click);
            // 
            // gbProjectInformation
            // 
            this.gbProjectInformation.Controls.Add(this.btnCreateProject);
            this.gbProjectInformation.Controls.Add(this.btnSaveProjectFile);
            this.gbProjectInformation.Controls.Add(this.tbProjectName);
            this.gbProjectInformation.Controls.Add(this.btnFdbDialog);
            this.gbProjectInformation.Controls.Add(this.lblProjectName);
            this.gbProjectInformation.Controls.Add(this.tbProjectFilePath);
            this.gbProjectInformation.Controls.Add(this.lblProjectPath);
            this.gbProjectInformation.Location = new System.Drawing.Point(12, 12);
            this.gbProjectInformation.Name = "gbProjectInformation";
            this.gbProjectInformation.Size = new System.Drawing.Size(884, 122);
            this.gbProjectInformation.TabIndex = 21;
            this.gbProjectInformation.TabStop = false;
            this.gbProjectInformation.Text = "Project information";
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(727, 16);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(151, 31);
            this.btnCreateProject.TabIndex = 21;
            this.btnCreateProject.Text = "Create project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnResetProtocol
            // 
            this.btnResetProtocol.Enabled = false;
            this.btnResetProtocol.Location = new System.Drawing.Point(763, 429);
            this.btnResetProtocol.Name = "btnResetProtocol";
            this.btnResetProtocol.Size = new System.Drawing.Size(127, 31);
            this.btnResetProtocol.TabIndex = 22;
            this.btnResetProtocol.Text = "Reset protocol";
            this.btnResetProtocol.UseVisualStyleBackColor = true;
            this.btnResetProtocol.Click += new System.EventHandler(this.btnResetProtocol_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 505);
            this.Controls.Add(this.btnResetProtocol);
            this.Controls.Add(this.gbProjectInformation);
            this.Controls.Add(this.rtbProtocol);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lblProtocol);
            this.Controls.Add(this.btnReadOpcData);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.dgvOpcData);
            this.Name = "DemoForm";
            this.Text = "OPC Mock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).EndInit();
            this.gbProjectInformation.ResumeLayout(false);
            this.gbProjectInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        


        #endregion

        private System.Windows.Forms.DataGridView dgvOpcData;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnReadOpcData;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn TagQualityText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagQualityValue;
        private System.Windows.Forms.SaveFileDialog sfdDataFile;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.RichTextBox rtbProtocol;
        private System.Windows.Forms.Label lblProjectPath;
        private System.Windows.Forms.TextBox tbProjectFilePath;
        private System.Windows.Forms.SaveFileDialog sfdProjectFile;
        private System.Windows.Forms.Button btnSaveProjectFile;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.FolderBrowserDialog fbdProjectPath;
        private System.Windows.Forms.Button btnFdbDialog;
        private System.Windows.Forms.GroupBox gbProjectInformation;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.Button btnResetProtocol;
    }
}


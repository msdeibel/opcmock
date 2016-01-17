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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOpcData = new System.Windows.Forms.DataGridView();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagQualityText = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TagQualityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbProjectFileName = new System.Windows.Forms.TextBox();
            this.lblDataFileName = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnReadOpcData = new System.Windows.Forms.Button();
            this.fdDataFile = new System.Windows.Forms.SaveFileDialog();
            this.btnDataFileDialog = new System.Windows.Forms.Button();
            this.tbProtocol = new System.Windows.Forms.TextBox();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.lblProjectFilePath = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnProjectFileDialog = new System.Windows.Forms.Button();
            this.btnStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).BeginInit();
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
            this.dgvOpcData.Location = new System.Drawing.Point(2, 110);
            this.dgvOpcData.Name = "dgvOpcData";
            this.dgvOpcData.Size = new System.Drawing.Size(560, 202);
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
            dataGridViewCellStyle1.NullValue = "Good";
            this.TagQualityText.DefaultCellStyle = dataGridViewCellStyle1;
            this.TagQualityText.HeaderText = "TagQualityText";
            this.TagQualityText.Name = "TagQualityText";
            this.TagQualityText.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TagQualityText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TagQualityValue
            // 
            dataGridViewCellStyle2.NullValue = "192";
            this.TagQualityValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.TagQualityValue.HeaderText = "TagQualityValue";
            this.TagQualityValue.Name = "TagQualityValue";
            this.TagQualityValue.ReadOnly = true;
            // 
            // tbProjectFileName
            // 
            this.tbProjectFileName.Location = new System.Drawing.Point(2, 84);
            this.tbProjectFileName.Name = "tbProjectFileName";
            this.tbProjectFileName.Size = new System.Drawing.Size(528, 20);
            this.tbProjectFileName.TabIndex = 1;
            this.tbProjectFileName.Text = "d:\\temp\\opctest";
            // 
            // lblDataFileName
            // 
            this.lblDataFileName.AutoSize = true;
            this.lblDataFileName.Location = new System.Drawing.Point(-1, 68);
            this.lblDataFileName.Name = "lblDataFileName";
            this.lblDataFileName.Size = new System.Drawing.Size(67, 13);
            this.lblDataFileName.TabIndex = 2;
            this.lblDataFileName.Text = "Datafile path";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(2, 318);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 23);
            this.btnSaveData.TabIndex = 4;
            this.btnSaveData.Text = "Save data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnReadOpcData
            // 
            this.btnReadOpcData.Location = new System.Drawing.Point(83, 318);
            this.btnReadOpcData.Name = "btnReadOpcData";
            this.btnReadOpcData.Size = new System.Drawing.Size(75, 23);
            this.btnReadOpcData.TabIndex = 5;
            this.btnReadOpcData.Text = "Read data";
            this.btnReadOpcData.UseVisualStyleBackColor = true;
            this.btnReadOpcData.Click += new System.EventHandler(this.btnReadOpcData_Click);
            // 
            // btnDataFileDialog
            // 
            this.btnDataFileDialog.AutoSize = true;
            this.btnDataFileDialog.Location = new System.Drawing.Point(536, 82);
            this.btnDataFileDialog.Name = "btnDataFileDialog";
            this.btnDataFileDialog.Size = new System.Drawing.Size(26, 23);
            this.btnDataFileDialog.TabIndex = 6;
            this.btnDataFileDialog.Text = "...";
            this.btnDataFileDialog.UseVisualStyleBackColor = true;
            this.btnDataFileDialog.Click += new System.EventHandler(this.btnProjectFileDialog_Click);
            // 
            // tbProtocol
            // 
            this.tbProtocol.Location = new System.Drawing.Point(590, 110);
            this.tbProtocol.Multiline = true;
            this.tbProtocol.Name = "tbProtocol";
            this.tbProtocol.Size = new System.Drawing.Size(290, 202);
            this.tbProtocol.TabIndex = 7;
            this.tbProtocol.Text = "set;tagToSet;newValue;Good\r\nwait:tagToWaitFor;expectedValue;Good\r\ndummy";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(590, 91);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(46, 13);
            this.lblProtocol.TabIndex = 8;
            this.lblProtocol.Text = "Protocol";
            // 
            // lblProjectFilePath
            // 
            this.lblProjectFilePath.AutoSize = true;
            this.lblProjectFilePath.Location = new System.Drawing.Point(0, 28);
            this.lblProjectFilePath.Name = "lblProjectFilePath";
            this.lblProjectFilePath.Size = new System.Drawing.Size(77, 13);
            this.lblProjectFilePath.TabIndex = 9;
            this.lblProjectFilePath.Text = "Projectfile path";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(527, 20);
            this.textBox1.TabIndex = 10;
            // 
            // btnProjectFileDialog
            // 
            this.btnProjectFileDialog.Location = new System.Drawing.Point(536, 40);
            this.btnProjectFileDialog.Name = "btnProjectFileDialog";
            this.btnProjectFileDialog.Size = new System.Drawing.Size(26, 23);
            this.btnProjectFileDialog.TabIndex = 11;
            this.btnProjectFileDialog.Text = "...";
            this.btnProjectFileDialog.UseVisualStyleBackColor = true;
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(593, 327);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(127, 27);
            this.btnStep.TabIndex = 12;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 445);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.btnProjectFileDialog);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblProjectFilePath);
            this.Controls.Add(this.lblProtocol);
            this.Controls.Add(this.tbProtocol);
            this.Controls.Add(this.btnDataFileDialog);
            this.Controls.Add(this.btnReadOpcData);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.lblDataFileName);
            this.Controls.Add(this.tbProjectFileName);
            this.Controls.Add(this.dgvOpcData);
            this.Name = "DemoForm";
            this.Text = "OPC Mock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        


        #endregion

        private System.Windows.Forms.DataGridView dgvOpcData;
        private System.Windows.Forms.TextBox tbProjectFileName;
        private System.Windows.Forms.Label lblDataFileName;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnReadOpcData;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn TagQualityText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagQualityValue;
        private System.Windows.Forms.SaveFileDialog fdDataFile;
        private System.Windows.Forms.Button btnDataFileDialog;
        private System.Windows.Forms.TextBox tbProtocol;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Label lblProjectFilePath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnProjectFileDialog;
        private System.Windows.Forms.Button btnStep;
    }
}


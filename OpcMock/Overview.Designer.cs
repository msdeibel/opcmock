using System;
namespace OpcMock
{
    partial class Overview
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
            this.tbProjectFileName = new System.Windows.Forms.TextBox();
            this.lblProjectFileName = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnReadOpcData = new System.Windows.Forms.Button();
            this.projectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnProjectFileDialog = new System.Windows.Forms.Button();
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
            this.dgvOpcData.Location = new System.Drawing.Point(2, 53);
            this.dgvOpcData.Name = "dgvOpcData";
            this.dgvOpcData.Size = new System.Drawing.Size(789, 202);
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
            // tbProjectFileName
            // 
            this.tbProjectFileName.Location = new System.Drawing.Point(2, 27);
            this.tbProjectFileName.Name = "tbProjectFileName";
            this.tbProjectFileName.Size = new System.Drawing.Size(528, 20);
            this.tbProjectFileName.TabIndex = 1;
            this.tbProjectFileName.Text = "d:\\temp\\opctest";
            // 
            // lblProjectFileName
            // 
            this.lblProjectFileName.AutoSize = true;
            this.lblProjectFileName.Location = new System.Drawing.Point(-1, 11);
            this.lblProjectFileName.Name = "lblProjectFileName";
            this.lblProjectFileName.Size = new System.Drawing.Size(96, 13);
            this.lblProjectFileName.TabIndex = 2;
            this.lblProjectFileName.Text = "Project file tagPath";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(2, 261);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 23);
            this.btnSaveData.TabIndex = 4;
            this.btnSaveData.Text = "Save data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnReadOpcData
            // 
            this.btnReadOpcData.Location = new System.Drawing.Point(360, 261);
            this.btnReadOpcData.Name = "btnReadOpcData";
            this.btnReadOpcData.Size = new System.Drawing.Size(75, 23);
            this.btnReadOpcData.TabIndex = 5;
            this.btnReadOpcData.Text = "Read data";
            this.btnReadOpcData.UseVisualStyleBackColor = true;
            this.btnReadOpcData.Click += new System.EventHandler(this.btnReadOpcData_Click);
            // 
            // btnProjectFileDialog
            // 
            this.btnProjectFileDialog.AutoSize = true;
            this.btnProjectFileDialog.Location = new System.Drawing.Point(536, 25);
            this.btnProjectFileDialog.Name = "btnProjectFileDialog";
            this.btnProjectFileDialog.Size = new System.Drawing.Size(26, 23);
            this.btnProjectFileDialog.TabIndex = 6;
            this.btnProjectFileDialog.Text = "...";
            this.btnProjectFileDialog.UseVisualStyleBackColor = true;
            this.btnProjectFileDialog.Click += new System.EventHandler(this.btnProjectFileDialog_Click);
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 445);
            this.Controls.Add(this.btnProjectFileDialog);
            this.Controls.Add(this.btnReadOpcData);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.lblProjectFileName);
            this.Controls.Add(this.tbProjectFileName);
            this.Controls.Add(this.dgvOpcData);
            this.Name = "Overview";
            this.Text = "OPC Mock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        


        #endregion

        private System.Windows.Forms.DataGridView dgvOpcData;
        private System.Windows.Forms.TextBox tbProjectFileName;
        private System.Windows.Forms.Label lblProjectFileName;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnReadOpcData;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn TagQualityText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagQualityValue;
        private System.Windows.Forms.SaveFileDialog projectFileDialog;
        private System.Windows.Forms.Button btnProjectFileDialog;
    }
}


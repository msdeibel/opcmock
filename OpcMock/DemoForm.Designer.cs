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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            this.dgvOpcData = new System.Windows.Forms.DataGridView();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagQualityText = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TagQualityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveTags = new System.Windows.Forms.Button();
            this.btnReadTags = new System.Windows.Forms.Button();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.btnStep = new System.Windows.Forms.Button();
            this.rtbProtocol = new System.Windows.Forms.RichTextBox();
            this.sfdProjectFile = new System.Windows.Forms.SaveFileDialog();
            this.btnResetProtocol = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdProjectFile = new System.Windows.Forms.OpenFileDialog();
            this.lblTags = new System.Windows.Forms.Label();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbProtocols = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.dgvOpcData.Location = new System.Drawing.Point(12, 89);
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
            dataGridViewCellStyle1.NullValue = "Good";
            this.TagQualityText.DefaultCellStyle = dataGridViewCellStyle1;
            this.TagQualityText.HeaderText = "TagQualityText";
            this.TagQualityText.Name = "TagQualityText";
            this.TagQualityText.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TagQualityText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TagQualityValue
            // 
            this.TagQualityValue.HeaderText = "TagQualityValue";
            this.TagQualityValue.Name = "TagQualityValue";
            // 
            // btnSaveTags
            // 
            this.btnSaveTags.Enabled = false;
            this.btnSaveTags.Location = new System.Drawing.Point(12, 309);
            this.btnSaveTags.Name = "btnSaveTags";
            this.btnSaveTags.Size = new System.Drawing.Size(75, 31);
            this.btnSaveTags.TabIndex = 1;
            this.btnSaveTags.Text = "Save tags";
            this.btnSaveTags.UseVisualStyleBackColor = true;
            this.btnSaveTags.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnReadTags
            // 
            this.btnReadTags.Enabled = false;
            this.btnReadTags.Location = new System.Drawing.Point(93, 309);
            this.btnReadTags.Name = "btnReadTags";
            this.btnReadTags.Size = new System.Drawing.Size(75, 31);
            this.btnReadTags.TabIndex = 2;
            this.btnReadTags.Text = "Read tags";
            this.btnReadTags.UseVisualStyleBackColor = true;
            this.btnReadTags.Click += new System.EventHandler(this.btnReadOpcData_Click);
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(600, 73);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(46, 13);
            this.lblProtocol.TabIndex = 8;
            this.lblProtocol.Text = "Protocol";
            // 
            // btnStep
            // 
            this.btnStep.Enabled = false;
            this.btnStep.Location = new System.Drawing.Point(603, 361);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(127, 31);
            this.btnStep.TabIndex = 4;
            this.btnStep.Text = "Execute step 1";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // rtbProtocol
            // 
            this.rtbProtocol.Location = new System.Drawing.Point(603, 145);
            this.rtbProtocol.Name = "rtbProtocol";
            this.rtbProtocol.Size = new System.Drawing.Size(287, 210);
            this.rtbProtocol.TabIndex = 3;
            this.rtbProtocol.Text = "Set;tagToSet;newValue;192\nDummy\nWait;tagToWaitFor;expectedValue;192\n";
            // 
            // btnResetProtocol
            // 
            this.btnResetProtocol.Enabled = false;
            this.btnResetProtocol.Location = new System.Drawing.Point(763, 361);
            this.btnResetProtocol.Name = "btnResetProtocol";
            this.btnResetProtocol.Size = new System.Drawing.Size(127, 31);
            this.btnResetProtocol.TabIndex = 5;
            this.btnResetProtocol.Text = "Reset protocol";
            this.btnResetProtocol.UseVisualStyleBackColor = true;
            this.btnResetProtocol.Click += new System.EventHandler(this.btnResetProtocol_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.protocolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // protocolToolStripMenuItem
            // 
            this.protocolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.saveAllToolStripMenuItem});
            this.protocolToolStripMenuItem.Name = "protocolToolStripMenuItem";
            this.protocolToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.protocolToolStripMenuItem.Text = "Protocol";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // ofdProjectFile
            // 
            this.ofdProjectFile.Filter = "OpcMock Project|*.project";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(12, 73);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(31, 13);
            this.lblTags.TabIndex = 24;
            this.lblTags.Text = "Tags";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAllToolStripMenuItem.Text = "Save all";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // cbProtocols
            // 
            this.cbProtocols.FormattingEnabled = true;
            this.cbProtocols.Location = new System.Drawing.Point(603, 89);
            this.cbProtocols.Name = "cbProtocols";
            this.cbProtocols.Size = new System.Drawing.Size(287, 21);
            this.cbProtocols.TabIndex = 25;
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 445);
            this.Controls.Add(this.cbProtocols);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.btnResetProtocol);
            this.Controls.Add(this.rtbProtocol);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.lblProtocol);
            this.Controls.Add(this.btnReadTags);
            this.Controls.Add(this.btnSaveTags);
            this.Controls.Add(this.dgvOpcData);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DemoForm";
            this.Text = "OPC Mock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        


        #endregion

        private System.Windows.Forms.DataGridView dgvOpcData;
        private System.Windows.Forms.Button btnSaveTags;
        private System.Windows.Forms.Button btnReadTags;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.RichTextBox rtbProtocol;
        private System.Windows.Forms.SaveFileDialog sfdProjectFile;
        private System.Windows.Forms.Button btnResetProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn TagQualityText;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagQualityValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdProjectFile;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.ToolStripMenuItem protocolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbProtocols;
    }
}


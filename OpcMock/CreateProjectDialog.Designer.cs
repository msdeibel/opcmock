namespace OpcMock
{
    partial class CreateProjectDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProjectDialog));
            this.tbProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.tbProjectFilePath = new System.Windows.Forms.TextBox();
            this.lblProjectPath = new System.Windows.Forms.Label();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFdbDialog = new System.Windows.Forms.Button();
            this.fbdProjectPath = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMissingProjectName = new System.Windows.Forms.Label();
            this.lblMissingProjectPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbProjectName
            // 
            this.tbProjectName.Location = new System.Drawing.Point(12, 35);
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.Size = new System.Drawing.Size(159, 20);
            this.tbProjectName.TabIndex = 0;
            this.tbProjectName.Text = "testProject001";
            this.tbProjectName.Validating += new System.ComponentModel.CancelEventHandler(this.tbProjectName_Validating);
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(8, 19);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(69, 13);
            this.lblProjectName.TabIndex = 22;
            this.lblProjectName.Text = "Project name";
            // 
            // tbProjectFilePath
            // 
            this.tbProjectFilePath.Location = new System.Drawing.Point(12, 96);
            this.tbProjectFilePath.Name = "tbProjectFilePath";
            this.tbProjectFilePath.Size = new System.Drawing.Size(322, 20);
            this.tbProjectFilePath.TabIndex = 21;
            this.tbProjectFilePath.TabStop = false;
            this.tbProjectFilePath.Text = "d:\\temp\\opcmock";
            this.tbProjectFilePath.Validating += new System.ComponentModel.CancelEventHandler(this.tbProjectFilePath_Validating);
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Location = new System.Drawing.Point(9, 80);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(64, 13);
            this.lblProjectPath.TabIndex = 20;
            this.lblProjectPath.Text = "Project path";
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(11, 154);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(151, 31);
            this.btnCreateProject.TabIndex = 2;
            this.btnCreateProject.Text = "Create project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFdbDialog
            // 
            this.btnFdbDialog.CausesValidation = false;
            this.btnFdbDialog.Location = new System.Drawing.Point(330, 95);
            this.btnFdbDialog.Name = "btnFdbDialog";
            this.btnFdbDialog.Size = new System.Drawing.Size(25, 21);
            this.btnFdbDialog.TabIndex = 1;
            this.btnFdbDialog.Text = "...";
            this.btnFdbDialog.UseVisualStyleBackColor = true;
            this.btnFdbDialog.Click += new System.EventHandler(this.btnFdbDialog_Click);
            // 
            // lblMissingProjectName
            // 
            this.lblMissingProjectName.AutoSize = true;
            this.lblMissingProjectName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMissingProjectName.Location = new System.Drawing.Point(12, 58);
            this.lblMissingProjectName.Name = "lblMissingProjectName";
            this.lblMissingProjectName.Size = new System.Drawing.Size(126, 13);
            this.lblMissingProjectName.TabIndex = 23;
            this.lblMissingProjectName.Text = "Project name must be set";
            this.lblMissingProjectName.Visible = false;
            // 
            // lblMissingProjectPath
            // 
            this.lblMissingProjectPath.AutoSize = true;
            this.lblMissingProjectPath.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMissingProjectPath.Location = new System.Drawing.Point(12, 119);
            this.lblMissingProjectPath.Name = "lblMissingProjectPath";
            this.lblMissingProjectPath.Size = new System.Drawing.Size(121, 13);
            this.lblMissingProjectPath.TabIndex = 24;
            this.lblMissingProjectPath.Text = "Project path must be set";
            this.lblMissingProjectPath.Visible = false;
            // 
            // CreateProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(375, 201);
            this.Controls.Add(this.lblMissingProjectPath);
            this.Controls.Add(this.lblMissingProjectName);
            this.Controls.Add(this.btnFdbDialog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.tbProjectName);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.tbProjectFilePath);
            this.Controls.Add(this.lblProjectPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateProjectDialog";
            this.RightToLeftLayout = true;
            this.Text = "New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox tbProjectFilePath;
        private System.Windows.Forms.Label lblProjectPath;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFdbDialog;
        private System.Windows.Forms.FolderBrowserDialog fbdProjectPath;
        private System.Windows.Forms.Label lblMissingProjectName;
        private System.Windows.Forms.Label lblMissingProjectPath;
    }
}
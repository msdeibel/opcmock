namespace OpcMock
{
    partial class CreateProtocolDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProtocolDialog));
            this.lblMissingProtocolName = new System.Windows.Forms.Label();
            this.tbProtocolName = new System.Windows.Forms.TextBox();
            this.lblProtocolName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateProtocol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMissingProtocolName
            // 
            this.lblMissingProtocolName.AutoSize = true;
            this.lblMissingProtocolName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMissingProtocolName.Location = new System.Drawing.Point(12, 58);
            this.lblMissingProtocolName.Name = "lblMissingProtocolName";
            this.lblMissingProtocolName.Size = new System.Drawing.Size(132, 13);
            this.lblMissingProtocolName.TabIndex = 26;
            this.lblMissingProtocolName.Text = "Protocol name must be set";
            this.lblMissingProtocolName.Visible = false;
            // 
            // tbProtocolName
            // 
            this.tbProtocolName.Location = new System.Drawing.Point(11, 35);
            this.tbProtocolName.Name = "tbProtocolName";
            this.tbProtocolName.Size = new System.Drawing.Size(159, 20);
            this.tbProtocolName.TabIndex = 24;
            this.tbProtocolName.Validating += new System.ComponentModel.CancelEventHandler(this.tbProtocolName_Validating);
            // 
            // lblProtocolName
            // 
            this.lblProtocolName.AutoSize = true;
            this.lblProtocolName.Location = new System.Drawing.Point(8, 19);
            this.lblProtocolName.Name = "lblProtocolName";
            this.lblProtocolName.Size = new System.Drawing.Size(75, 13);
            this.lblProtocolName.TabIndex = 25;
            this.lblProtocolName.Text = "Protocol name";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 31);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateProtocol
            // 
            this.btnCreateProtocol.Location = new System.Drawing.Point(11, 154);
            this.btnCreateProtocol.Name = "btnCreateProtocol";
            this.btnCreateProtocol.Size = new System.Drawing.Size(151, 31);
            this.btnCreateProtocol.TabIndex = 27;
            this.btnCreateProtocol.Text = "Create protocol";
            this.btnCreateProtocol.UseVisualStyleBackColor = true;
            this.btnCreateProtocol.Click += new System.EventHandler(this.btnCreateProtocol_Click);
            // 
            // CreateProtocolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(375, 201);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateProtocol);
            this.Controls.Add(this.lblMissingProtocolName);
            this.Controls.Add(this.tbProtocolName);
            this.Controls.Add(this.lblProtocolName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateProtocolDialog";
            this.Text = "New Protocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMissingProtocolName;
        private System.Windows.Forms.TextBox tbProtocolName;
        private System.Windows.Forms.Label lblProtocolName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreateProtocol;
    }
}
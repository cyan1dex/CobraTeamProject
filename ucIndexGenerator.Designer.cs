namespace Cobra
{
    partial class ucIndexGenerator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.label2 = new System.Windows.Forms.Label();
            this.grpIndexSource = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoText = new System.Windows.Forms.RadioButton();
            this.rdoFile = new System.Windows.Forms.RadioButton();
            this.grpIndexType = new System.Windows.Forms.GroupBox();
            this.panFileUpload = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.panText = new System.Windows.Forms.Panel();
            this.txtIndexText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnGenIndex = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.grpIndexSource.SuspendLayout();
            this.grpIndexType.SuspendLayout();
            this.panFileUpload.SuspendLayout();
            this.panText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 0;
            label1.Text = "Select File";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 65);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 13);
            label3.TabIndex = 5;
            label3.Text = "Files To Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Index Generator";
            // 
            // grpIndexSource
            // 
            this.grpIndexSource.BackColor = System.Drawing.Color.Transparent;
            this.grpIndexSource.Controls.Add(this.radioButton1);
            this.grpIndexSource.Controls.Add(this.rdoText);
            this.grpIndexSource.Controls.Add(this.rdoFile);
            this.grpIndexSource.Location = new System.Drawing.Point(50, 54);
            this.grpIndexSource.Name = "grpIndexSource";
            this.grpIndexSource.Size = new System.Drawing.Size(704, 69);
            this.grpIndexSource.TabIndex = 6;
            this.grpIndexSource.TabStop = false;
            this.grpIndexSource.Text = "Index Source";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(276, 33);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single File";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoText
            // 
            this.rdoText.AutoSize = true;
            this.rdoText.Location = new System.Drawing.Point(161, 33);
            this.rdoText.Name = "rdoText";
            this.rdoText.Size = new System.Drawing.Size(76, 17);
            this.rdoText.TabIndex = 1;
            this.rdoText.TabStop = true;
            this.rdoText.Text = "Paste Text";
            this.rdoText.UseVisualStyleBackColor = true;
            this.rdoText.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoFile
            // 
            this.rdoFile.AutoSize = true;
            this.rdoFile.Location = new System.Drawing.Point(32, 33);
            this.rdoFile.Name = "rdoFile";
            this.rdoFile.Size = new System.Drawing.Size(83, 17);
            this.rdoFile.TabIndex = 0;
            this.rdoFile.TabStop = true;
            this.rdoFile.Text = "Upload Files";
            this.rdoFile.UseVisualStyleBackColor = true;
            this.rdoFile.CheckedChanged += new System.EventHandler(this.rdoFile_CheckedChanged);
            // 
            // grpIndexType
            // 
            this.grpIndexType.BackColor = System.Drawing.Color.Transparent;
            this.grpIndexType.Controls.Add(this.panFileUpload);
            this.grpIndexType.Controls.Add(this.panText);
            this.grpIndexType.Location = new System.Drawing.Point(50, 130);
            this.grpIndexType.Name = "grpIndexType";
            this.grpIndexType.Size = new System.Drawing.Size(704, 350);
            this.grpIndexType.TabIndex = 7;
            this.grpIndexType.TabStop = false;
            // 
            // panFileUpload
            // 
            this.panFileUpload.BackColor = System.Drawing.Color.Transparent;
            this.panFileUpload.Controls.Add(this.button2);
            this.panFileUpload.Controls.Add(this.button1);
            this.panFileUpload.Controls.Add(label3);
            this.panFileUpload.Controls.Add(this.lstFiles);
            this.panFileUpload.Controls.Add(this.btnBrowse);
            this.panFileUpload.Controls.Add(this.txtFileName);
            this.panFileUpload.Controls.Add(label1);
            this.panFileUpload.Location = new System.Drawing.Point(32, 30);
            this.panFileUpload.Name = "panFileUpload";
            this.panFileUpload.Size = new System.Drawing.Size(648, 405);
            this.panFileUpload.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(401, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(92, 65);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(384, 199);
            this.lstFiles.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(401, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(92, 15);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(303, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // panText
            // 
            this.panText.Controls.Add(this.txtIndexText);
            this.panText.Location = new System.Drawing.Point(32, 30);
            this.panText.Name = "panText";
            this.panText.Size = new System.Drawing.Size(648, 299);
            this.panText.TabIndex = 0;
            // 
            // txtIndexText
            // 
            this.txtIndexText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIndexText.Location = new System.Drawing.Point(0, 0);
            this.txtIndexText.Multiline = true;
            this.txtIndexText.Name = "txtIndexText";
            this.txtIndexText.Size = new System.Drawing.Size(648, 299);
            this.txtIndexText.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnGenIndex
            // 
            this.btnGenIndex.Location = new System.Drawing.Point(174, 486);
            this.btnGenIndex.Name = "btnGenIndex";
            this.btnGenIndex.Size = new System.Drawing.Size(142, 23);
            this.btnGenIndex.TabIndex = 8;
            this.btnGenIndex.Text = "Generate Indexes";
            this.btnGenIndex.UseVisualStyleBackColor = true;
            this.btnGenIndex.Click += new System.EventHandler(this.btnGenIndex_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(416, 486);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Reset Indexes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(85, 542);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 10;
            // 
            // ucIndexGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGenIndex);
            this.Controls.Add(this.grpIndexType);
            this.Controls.Add(this.grpIndexSource);
            this.Controls.Add(this.label2);
            this.Name = "ucIndexGenerator";
            this.Size = new System.Drawing.Size(802, 589);
            this.grpIndexSource.ResumeLayout(false);
            this.grpIndexSource.PerformLayout();
            this.grpIndexType.ResumeLayout(false);
            this.panFileUpload.ResumeLayout(false);
            this.panFileUpload.PerformLayout();
            this.panText.ResumeLayout(false);
            this.panText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpIndexSource;
        private System.Windows.Forms.RadioButton rdoText;
        private System.Windows.Forms.RadioButton rdoFile;
        private System.Windows.Forms.GroupBox grpIndexType;
        private System.Windows.Forms.Panel panText;
        private System.Windows.Forms.TextBox txtIndexText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panFileUpload;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnGenIndex;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblMessage;
    }
}

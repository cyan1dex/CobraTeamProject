namespace Cobra
{
	partial class frmShowFile
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
            this.rtxtFileContent = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtFileContent
            // 
            this.rtxtFileContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxtFileContent.Location = new System.Drawing.Point(0, 0);
            this.rtxtFileContent.Name = "rtxtFileContent";
            this.rtxtFileContent.Size = new System.Drawing.Size(730, 305);
            this.rtxtFileContent.TabIndex = 0;
            this.rtxtFileContent.Text = "";
            this.rtxtFileContent.TextChanged += new System.EventHandler(this.rtxtFileContent_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(318, 311);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 343);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtxtFileContent);
            this.Name = "frmShowFile";
            this.Text = "File Viewer";
            this.Load += new System.EventHandler(this.frmShowFile_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtxtFileContent;
		private System.Windows.Forms.Button btnClose;
	}
}
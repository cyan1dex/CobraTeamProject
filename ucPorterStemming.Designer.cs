namespace Cobra
{
    partial class ucPorterStemming
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtWord = new System.Windows.Forms.TextBox();
			this.btnApplyStemming = new System.Windows.Forms.Button();
			this.lblSuggestedWord = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtSuggestion = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.panSummary = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblWordCount = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.panSummary.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type Word";
			// 
			// txtWord
			// 
			this.txtWord.Location = new System.Drawing.Point(93, 53);
			this.txtWord.Name = "txtWord";
			this.txtWord.Size = new System.Drawing.Size(232, 20);
			this.txtWord.TabIndex = 1;
			// 
			// btnApplyStemming
			// 
			this.btnApplyStemming.Location = new System.Drawing.Point(154, 140);
			this.btnApplyStemming.Name = "btnApplyStemming";
			this.btnApplyStemming.Size = new System.Drawing.Size(117, 26);
			this.btnApplyStemming.TabIndex = 2;
			this.btnApplyStemming.Text = "Apply Stemming";
			this.btnApplyStemming.UseVisualStyleBackColor = true;
			this.btnApplyStemming.Click += new System.EventHandler(this.btnApplyStemming_Click);
			// 
			// lblSuggestedWord
			// 
			this.lblSuggestedWord.AutoSize = true;
			this.lblSuggestedWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSuggestedWord.Location = new System.Drawing.Point(90, 160);
			this.lblSuggestedWord.Name = "lblSuggestedWord";
			this.lblSuggestedWord.Size = new System.Drawing.Size(0, 18);
			this.lblSuggestedWord.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Porter Stemming";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Upload File";
			// 
			// txtFile
			// 
			this.txtFile.Location = new System.Drawing.Point(93, 114);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(232, 20);
			this.txtFile.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(331, 112);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(62, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Browse...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtSuggestion
			// 
			this.txtSuggestion.Location = new System.Drawing.Point(96, 181);
			this.txtSuggestion.Multiline = true;
			this.txtSuggestion.Name = "txtSuggestion";
			this.txtSuggestion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtSuggestion.Size = new System.Drawing.Size(229, 171);
			this.txtSuggestion.TabIndex = 8;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(90, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "OR";
			// 
			// panSummary
			// 
			this.panSummary.Controls.Add(this.lblTime);
			this.panSummary.Controls.Add(this.lblWordCount);
			this.panSummary.Controls.Add(this.label6);
			this.panSummary.Controls.Add(this.label5);
			this.panSummary.Location = new System.Drawing.Point(331, 181);
			this.panSummary.Name = "panSummary";
			this.panSummary.Size = new System.Drawing.Size(173, 83);
			this.panSummary.TabIndex = 10;
			this.panSummary.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Word Stemmed";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(3, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Time Took";
			// 
			// lblWordCount
			// 
			this.lblWordCount.AutoSize = true;
			this.lblWordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWordCount.Location = new System.Drawing.Point(98, 14);
			this.lblWordCount.Name = "lblWordCount";
			this.lblWordCount.Size = new System.Drawing.Size(0, 13);
			this.lblWordCount.TabIndex = 2;
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(98, 41);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(0, 13);
			this.lblTime.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(404, 112);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 34);
			this.label7.TabIndex = 11;
			this.label7.Text = "each word on separate line";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// ucPorterStemming
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label7);
			this.Controls.Add(this.panSummary);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSuggestion);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblSuggestedWord);
			this.Controls.Add(this.btnApplyStemming);
			this.Controls.Add(this.txtWord);
			this.Controls.Add(this.label1);
			this.Name = "ucPorterStemming";
			this.Size = new System.Drawing.Size(507, 378);
			this.panSummary.ResumeLayout(false);
			this.panSummary.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnApplyStemming;
        private System.Windows.Forms.Label lblSuggestedWord;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtSuggestion;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panSummary;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblWordCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
    }
}

namespace Cobra
{
    partial class frmPorterStemmingTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPorterStemmingTest));
            this.lblPorterStemmingTest = new System.Windows.Forms.Label();
            this.lblTypeWord = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPorterStemmingTest
            // 
            this.lblPorterStemmingTest.AutoSize = true;
            this.lblPorterStemmingTest.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorterStemmingTest.ForeColor = System.Drawing.Color.Orange;
            this.lblPorterStemmingTest.Location = new System.Drawing.Point(136, 33);
            this.lblPorterStemmingTest.Name = "lblPorterStemmingTest";
            this.lblPorterStemmingTest.Size = new System.Drawing.Size(170, 21);
            this.lblPorterStemmingTest.TabIndex = 0;
            this.lblPorterStemmingTest.Text = "Porter Stemming Test";
            // 
            // lblTypeWord
            // 
            this.lblTypeWord.AutoSize = true;
            this.lblTypeWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeWord.ForeColor = System.Drawing.Color.Cyan;
            this.lblTypeWord.Location = new System.Drawing.Point(64, 88);
            this.lblTypeWord.Name = "lblTypeWord";
            this.lblTypeWord.Size = new System.Drawing.Size(63, 15);
            this.lblTypeWord.TabIndex = 1;
            this.lblTypeWord.Text = "Type word";
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(140, 85);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(156, 20);
            this.txtWord.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Blue;
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(175, 120);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmPorterStemmingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(386, 190);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lblTypeWord);
            this.Controls.Add(this.lblPorterStemmingTest);
            this.Name = "frmPorterStemmingTest";
            this.Text = "PorterStemmingTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPorterStemmingTest;
        private System.Windows.Forms.Label lblTypeWord;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnApply;
    }
}
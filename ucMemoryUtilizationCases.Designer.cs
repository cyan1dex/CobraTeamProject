namespace Cobra
{
    partial class ucMemoryUtilizationCases
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
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostings = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostingsEncoded = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHuffmanEncoding = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVBEncoding = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGaps = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTerms
            // 
            this.txtTerms.Location = new System.Drawing.Point(161, 42);
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.Size = new System.Drawing.Size(100, 20);
            this.txtTerms.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total # of terms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total # of postings";
            // 
            // txtPostings
            // 
            this.txtPostings.Location = new System.Drawing.Point(161, 84);
            this.txtPostings.Name = "txtPostings";
            this.txtPostings.Size = new System.Drawing.Size(100, 20);
            this.txtPostings.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Postings encoded";
            // 
            // txtPostingsEncoded
            // 
            this.txtPostingsEncoded.Location = new System.Drawing.Point(181, 36);
            this.txtPostingsEncoded.Name = "txtPostingsEncoded";
            this.txtPostingsEncoded.Size = new System.Drawing.Size(100, 20);
            this.txtPostingsEncoded.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVBEncoding);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHuffmanEncoding);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPostingsEncoded);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(116, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory Utilization";
            // 
            // txtHuffmanEncoding
            // 
            this.txtHuffmanEncoding.Location = new System.Drawing.Point(181, 74);
            this.txtHuffmanEncoding.Name = "txtHuffmanEncoding";
            this.txtHuffmanEncoding.Size = new System.Drawing.Size(100, 20);
            this.txtHuffmanEncoding.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Huffman gap encoding";
            // 
            // txtVBEncoding
            // 
            this.txtVBEncoding.Location = new System.Drawing.Point(181, 111);
            this.txtVBEncoding.Name = "txtVBEncoding";
            this.txtVBEncoding.Size = new System.Drawing.Size(100, 20);
            this.txtVBEncoding.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "VB gap encoding";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Total # of gaps";
            // 
            // txtGaps
            // 
            this.txtGaps.Location = new System.Drawing.Point(161, 125);
            this.txtGaps.Name = "txtGaps";
            this.txtGaps.Size = new System.Drawing.Size(100, 20);
            this.txtGaps.TabIndex = 7;
            // 
            // ucMemoryUtilizationCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGaps);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPostings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTerms);
            this.Name = "ucMemoryUtilizationCases";
            this.Size = new System.Drawing.Size(550, 489);
            this.Load += new System.EventHandler(this.ucMemoryUtilizationCases_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPostings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPostingsEncoded;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVBEncoding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHuffmanEncoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGaps;
    }
}

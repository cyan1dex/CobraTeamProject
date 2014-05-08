namespace Cobra
{
    partial class ucEditDistance
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckEdit = new System.Windows.Forms.Button();
            this.dgwEditMap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEditMap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(83, 19);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(100, 20);
            this.txtSource.TabIndex = 1;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(321, 19);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(100, 20);
            this.txtDestination.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination";
            // 
            // btnCheckEdit
            // 
            this.btnCheckEdit.Location = new System.Drawing.Point(442, 17);
            this.btnCheckEdit.Name = "btnCheckEdit";
            this.btnCheckEdit.Size = new System.Drawing.Size(119, 23);
            this.btnCheckEdit.TabIndex = 4;
            this.btnCheckEdit.Text = "Check Edit Distance";
            this.btnCheckEdit.UseVisualStyleBackColor = true;
            this.btnCheckEdit.Click += new System.EventHandler(this.btnCheckEdit_Click);
            // 
            // dgwEditMap
            // 
            this.dgwEditMap.AllowUserToAddRows = false;
            this.dgwEditMap.AllowUserToDeleteRows = false;
            this.dgwEditMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEditMap.Location = new System.Drawing.Point(39, 65);
            this.dgwEditMap.Name = "dgwEditMap";
            this.dgwEditMap.ReadOnly = true;
            this.dgwEditMap.Size = new System.Drawing.Size(522, 172);
            this.dgwEditMap.TabIndex = 5;
            // 
            // ucEditDistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgwEditMap);
            this.Controls.Add(this.btnCheckEdit);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Name = "ucEditDistance";
            this.Size = new System.Drawing.Size(617, 297);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEditMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckEdit;
        private System.Windows.Forms.DataGridView dgwEditMap;
    }
}

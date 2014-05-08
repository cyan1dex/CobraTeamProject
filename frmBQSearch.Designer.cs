namespace Cobra
{
    partial class frmBQSearch
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
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lswResult = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCommandView = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSummary = new System.Windows.Forms.CheckBox();
            this.lstWildcardResults = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearchString
            // 
            this.txtSearchString.AcceptsReturn = true;
            this.txtSearchString.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearchString.Location = new System.Drawing.Point(110, 76);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(503, 20);
            this.txtSearchString.TabIndex = 3;
            this.txtSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchString_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Mistral", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CadetBlue;
            this.label1.Location = new System.Drawing.Point(196, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 65);
            this.label1.TabIndex = 5;
            this.label1.Text = "COBRA SEARCH";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(238, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(249, 34);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lswResult
            // 
            this.lswResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lswResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lswResult.Location = new System.Drawing.Point(210, 203);
            this.lswResult.MultiSelect = false;
            this.lswResult.Name = "lswResult";
            this.lswResult.Size = new System.Drawing.Size(515, 513);
            this.lswResult.TabIndex = 8;
            this.lswResult.UseCompatibleStateImageBehavior = false;
            this.lswResult.View = System.Windows.Forms.View.Details;
            this.lswResult.Visible = false;
            this.lswResult.DoubleClick += new System.EventHandler(this.lswResult_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "#SRNO";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Document ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Postion";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Name";
            this.columnHeader3.Width = 247;
            // 
            // txtCommandView
            // 
            this.txtCommandView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCommandView.Location = new System.Drawing.Point(12, 203);
            this.txtCommandView.Multiline = true;
            this.txtCommandView.Name = "txtCommandView";
            this.txtCommandView.ReadOnly = true;
            this.txtCommandView.Size = new System.Drawing.Size(183, 235);
            this.txtCommandView.TabIndex = 30;
            this.txtCommandView.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Command View";
            this.label2.Visible = false;
            // 
            // chkSummary
            // 
            this.chkSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSummary.AutoSize = true;
            this.chkSummary.Location = new System.Drawing.Point(626, 126);
            this.chkSummary.Name = "chkSummary";
            this.chkSummary.Size = new System.Drawing.Size(99, 17);
            this.chkSummary.TabIndex = 31;
            this.chkSummary.Text = "Summary Mode";
            this.chkSummary.UseVisualStyleBackColor = true;
            // 
            // lstWildcardResults
            // 
            this.lstWildcardResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWildcardResults.FormattingEnabled = true;
            this.lstWildcardResults.Location = new System.Drawing.Point(12, 452);
            this.lstWildcardResults.Name = "lstWildcardResults";
            this.lstWildcardResults.Size = new System.Drawing.Size(183, 264);
            this.lstWildcardResults.TabIndex = 32;
            this.lstWildcardResults.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Wildcard Results";
            this.label3.Visible = false;
            // 
            // frmBQSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(737, 730);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstWildcardResults);
            this.Controls.Add(this.chkSummary);
            this.Controls.Add(this.txtCommandView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lswResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchString);
            this.Name = "frmBQSearch";
            this.Text = "Boolean Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lswResult;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtCommandView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSummary;
        private System.Windows.Forms.ListBox lstWildcardResults;
        private System.Windows.Forms.Label label3;

    }
}
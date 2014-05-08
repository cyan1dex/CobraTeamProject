namespace Cobra
{
    partial class frmSearch
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.sETUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spellCheckEditDistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spellCheckingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porterStemLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zifianDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heapsDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryUtilizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cosineSimilarityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Size = new System.Drawing.Size(847, 662);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 6;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Black;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sETUPToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(847, 24);
            this.menuStrip2.TabIndex = 7;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // sETUPToolStripMenuItem
            // 
            this.sETUPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildIndexToolStripMenuItem});
            this.sETUPToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sETUPToolStripMenuItem.Name = "sETUPToolStripMenuItem";
            this.sETUPToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.sETUPToolStripMenuItem.Text = "Cobra Setup";
            // 
            // buildIndexToolStripMenuItem
            // 
            this.buildIndexToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.buildIndexToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.buildIndexToolStripMenuItem.Name = "buildIndexToolStripMenuItem";
            this.buildIndexToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.buildIndexToolStripMenuItem.Text = "Build Index";
            this.buildIndexToolStripMenuItem.Click += new System.EventHandler(this.buildIndexToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.searchToolStripMenuItem.Text = "&Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spellCheckEditDistanceToolStripMenuItem,
            this.spellCheckingToolStripMenuItem,
            this.porterStemLookupToolStripMenuItem,
            this.zifianDistributionToolStripMenuItem,
            this.heapsDistributionToolStripMenuItem,
            this.memoryUtilizationToolStripMenuItem,
            this.cosineSimilarityToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "&Utilites";
            // 
            // spellCheckEditDistanceToolStripMenuItem
            // 
            this.spellCheckEditDistanceToolStripMenuItem.Name = "spellCheckEditDistanceToolStripMenuItem";
            this.spellCheckEditDistanceToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.spellCheckEditDistanceToolStripMenuItem.Text = "Spell Check Edit Distance";
            this.spellCheckEditDistanceToolStripMenuItem.Click += new System.EventHandler(this.spellCheckEditDistanceToolStripMenuItem_Click);
            // 
            // spellCheckingToolStripMenuItem
            // 
            this.spellCheckingToolStripMenuItem.Name = "spellCheckingToolStripMenuItem";
            this.spellCheckingToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.spellCheckingToolStripMenuItem.Text = "Spell Checking";
            this.spellCheckingToolStripMenuItem.Click += new System.EventHandler(this.spellCheckingToolStripMenuItem_Click);
            // 
            // porterStemLookupToolStripMenuItem
            // 
            this.porterStemLookupToolStripMenuItem.Name = "porterStemLookupToolStripMenuItem";
            this.porterStemLookupToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.porterStemLookupToolStripMenuItem.Text = "Porter Stem Lookup";
            this.porterStemLookupToolStripMenuItem.Click += new System.EventHandler(this.porterStemLookupToolStripMenuItem_Click);
            // 
            // zifianDistributionToolStripMenuItem
            // 
            this.zifianDistributionToolStripMenuItem.Name = "zifianDistributionToolStripMenuItem";
            this.zifianDistributionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.zifianDistributionToolStripMenuItem.Text = "Zipfian Distribution";
            this.zifianDistributionToolStripMenuItem.Click += new System.EventHandler(this.zifianDistributionToolStripMenuItem_Click);
            // 
            // heapsDistributionToolStripMenuItem
            // 
            this.heapsDistributionToolStripMenuItem.Name = "heapsDistributionToolStripMenuItem";
            this.heapsDistributionToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.heapsDistributionToolStripMenuItem.Text = "Heaps Distribution";
            this.heapsDistributionToolStripMenuItem.Click += new System.EventHandler(this.heapsDistributionToolStripMenuItem_Click);
            // 
            // memoryUtilizationToolStripMenuItem
            // 
            this.memoryUtilizationToolStripMenuItem.Name = "memoryUtilizationToolStripMenuItem";
            this.memoryUtilizationToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.memoryUtilizationToolStripMenuItem.Text = "Memory Utilization";
            this.memoryUtilizationToolStripMenuItem.Click += new System.EventHandler(this.memoryUtilizationToolStripMenuItem_Click);
            // 
            // cosineSimilarityToolStripMenuItem
            // 
            this.cosineSimilarityToolStripMenuItem.Name = "cosineSimilarityToolStripMenuItem";
            this.cosineSimilarityToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.cosineSimilarityToolStripMenuItem.Text = "Cosine Similarity";
            this.cosineSimilarityToolStripMenuItem.Click += new System.EventHandler(this.cosineSimilarityToolStripMenuItem_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(847, 662);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSearch";
            this.Text = "Team Cobra Search";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem sETUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spellCheckEditDistanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spellCheckingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porterStemLookupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zifianDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heapsDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryUtilizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cosineSimilarityToolStripMenuItem;
    }
}
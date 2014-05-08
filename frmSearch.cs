using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cobra
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

   

        private void UnloadAllControls()
        {
            foreach( Control ctr in splitContainer1.Panel2.Controls)
            {
                splitContainer1.Panel2.Controls.Remove(ctr);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            frmBQSearch frmBQS = new frmBQSearch();
            frmBQS.Visible = true;
            //ucBooleanQuery ucBQ = new ucBooleanQuery();
            //ucBQ.Dock = DockStyle.Fill;
            //splitContainer1.Panel2.Controls.Add(ucBQ);

        }

        private void buildIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            ucIndexGenerator ucIndex = new ucIndexGenerator();
            ucIndex.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ucIndex);
        }

  
        private void spellCheckEditDistanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            ucEditDistance ucED = new ucEditDistance();
            ucED.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ucED);
        }

        private void spellCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            ucSpellChecker ucSC = new ucSpellChecker();
            ucSC.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(ucSC);
        }

        private void porterStemLookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            splitContainer1.Panel2.Controls.Add(new ucPorterStemming());
            splitContainer1.ResumeLayout(false);
        }

		private void zifianDistributionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UnloadAllControls();
			splitContainer1.Panel2.Controls.Add(new ucZifian());
			splitContainer1.ResumeLayout(false);
		}

        private void heapsDistributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            splitContainer1.Panel2.Controls.Add(new ucHeap());
            splitContainer1.ResumeLayout(false);
        }

        private void memoryUtilizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            splitContainer1.Panel2.Controls.Add(new ucMemoryUtilizationCases());
            splitContainer1.ResumeLayout(false);
        }

        private void cosineSimilarityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadAllControls();
            splitContainer1.Panel2.Controls.Add(new ucCosineSimilarity());
            splitContainer1.ResumeLayout(false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cobra.PorterStemming;
using System.IO;

namespace Cobra
{
    public partial class ucPorterStemming : UserControl
    {
        public ucPorterStemming()
        {
            InitializeComponent();
        }

        private void btnApplyStemming_Click(object sender, EventArgs e)
        {
            PorterStemming.PorterStemming ps = new PorterStemming.PorterStemming();
			string line;
			DateTime StartTime, EndTime;
			

			int WordCount = 0;
			if (txtFile.Text == string.Empty)
			{
				ps.PorterStemmingProcessing(txtWord.Text);
				txtSuggestion.Text = "Result = " + ps.ProcessingString;
			}
			else
			{
				StreamReader sr = new StreamReader(txtFile.Text);
				StringBuilder sb = new StringBuilder();


				StartTime = DateTime.Now;
				while ((line = sr.ReadLine()) != null)
				{
					ps.PorterStemmingProcessing(line);
					sb.Append(ps.ProcessingString + Environment.NewLine );
					WordCount++;
				}
				EndTime = DateTime.Now;

				sr.Close();

				txtSuggestion.Text = sb.ToString();

				lblWordCount.Text = WordCount.ToString();
				lblTime.Text = EndTime.Subtract(StartTime).Milliseconds.ToString() + " ms";
				panSummary.Visible = true;

			}

            
        }

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			txtFile.Text = openFileDialog1.FileName;
		}

		private void label7_Click(object sender, EventArgs e)
		{

		}
    }
}

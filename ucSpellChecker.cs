using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cobra.SpellCheck;

namespace Cobra
{
    public partial class ucSpellChecker : UserControl
    {
        public ucSpellChecker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgwSuggestions.DataSource = null;

            if (txtSpellWord.Text.Replace(" ", "") == "")
            {
                lblMessage.Text = "Please Enter Text...";
            }
            else if (IndexData.twoGramIndex.Count <= 0)
            {
                lblMessage.Text = "Please Index the file first...";
            }
            else
            {
                lblMessage.Text = "";
                
                SpellCheckHandler scHandler = new SpellCheckHandler(txtSpellWord.Text, ref IndexData.twoGramIndex);
                List<SpellItem> Items = scHandler.GenerateSuggestions();

                var s = from t in Items
                        orderby t.EditDistance
                        select t;

                dgwSuggestions.DataSource = s.ToList();

                InitGrid();
            }
        
        }

        private void InitGrid()
        {   dgwSuggestions.Columns[0].Width = 175;
            dgwSuggestions.Columns[1].Width = 100;
            dgwSuggestions.Columns[2].Width = 100;

        }
    }
}

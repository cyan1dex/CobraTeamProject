using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cobra.QTokenizer;
using Cobra.InterpreterNIndexer;
using Cobra.Tree;
using Cobra.BooleanQuery;
using Cobra.CustomErrors;
using System.Collections;

namespace Cobra
{
    public partial class ucBooleanQuery : UserControl
    {

        public ucBooleanQuery()
        {
            InitializeComponent();
        }

		private void btnSearch_Click(object sender, EventArgs e)
		{
			
            try
            {
                if (IndexData.hstTable != null)
                    Search(txtSearchString.Text);
                else
                    throw new DictionaryEmptyException();
            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message.ToString(),"Query String Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
     
		}

		private void Search(string QueryString)
		{

            // Tokenize query string
            SyntaxAnalyzer sa = new SyntaxAnalyzer(QueryString);

            if (sa.ValidateEnclosureMatching())
            {
                QLexer lexer = new QLexer(QueryString);
                IndexData.qparser = new QParser(lexer);
                Object obj = IndexData.qparser.Evaluate();

			    // Convert tokens found in hashtable/dictionary to custom tree structured class
			    QueryPrepper cmdPrep = new QueryPrepper(IndexData.qparser.wordList);
			    IndexData.bqTree = cmdPrep.BooleanSearchTree();

				if (sa.ValidateDNFClause(IndexData.bqTree))
				{
					ExecuteSearch();
				}
				else
					throw new NonDNFException();
			}
			else
				throw new UnMatchedEnclosureException();
		}

        private void ExecuteSearch()
        {
            //List<Task> Operands;
            SearchExecutor cmdExecutor = new SearchExecutor(IndexData.hstTable, IndexData.termDictionary, IndexData.oneGramIndex, IndexData.twoGramIndex);
            IEnumerable<Index> FinalResults = cmdExecutor.ProcessBooleanQuery(IndexData.bqTree, false);
            if (FinalResults == null)
                MessageBox.Show("No matching documents found!","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            else    
                DisplayResult(FinalResults);
        }

		private void DisplayResult(IEnumerable<Index> FinalResults)
		{
            int iSeq = 1;

            lswResult.FullRowSelect = true;

            if (lswResult.Items.Count > 0)
                lswResult.Items.Clear();

            foreach (Index Posting in FinalResults)
            {
                ListViewItem lvItem = lswResult.Items.Add(iSeq.ToString());
                lvItem.SubItems.Add(Posting.getDocId.ToString());
                lvItem.SubItems.Add(Posting.getPosting.ToString());
                if (IndexData.FileListInfo.Count - 1 >= Posting.getDocId)
                    lvItem.SubItems.Add(IndexData.FileListInfo[Posting.getDocId]);
                else
                    lvItem.SubItems.Add(IndexData.FileListInfo[0]);
                lvItem.SubItems.Add(Posting.relativePosition.ToString());
                iSeq++;
            }

            lswResult.Visible = true;
		}

		private void lswResult_DoubleClick(object sender, EventArgs e)
		{

            if (lswResult.FocusedItem.SubItems.Count <= 3 || lswResult.FocusedItem.SubItems[3].Text == string.Empty)
                return;

            frmShowFile obj = new frmShowFile();
            obj.FilePath = lswResult.FocusedItem.SubItems[3].Text;
            obj.Position = System.Convert.ToInt32(lswResult.FocusedItem.SubItems[4].Text);
            obj.DocId = Convert.ToInt32(lswResult.FocusedItem.SubItems[1].Text);
            // obj.RelativePosition = System.Convert.ToInt32(lswResult.FocusedItem.SubItems[2].Text);
            obj.ShowDialog();
        }
    }
}

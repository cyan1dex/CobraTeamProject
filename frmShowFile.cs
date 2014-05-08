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
	public partial class frmShowFile : Form
	{
		public string FilePath { get; set; }

		public int Position { get; set; }

        public bool SelectionType { get; set; }
        public int RelativePosition { get; set; }

        public int DocId { get; set; }
		
		public frmShowFile()
		{
			InitializeComponent();
		}

		private void frmShowFile_Load(object sender, EventArgs e)
		{
            if (FilePath == string.Empty)
                return;

            String selection = "";
            int wordPosition = 0;

            if (IndexData.FileListInfo.Count <= 1)
            {
                int startOfDoc = IndexData.parser.newDocPositions[DocId];
                int endOfDoc = IndexData.parser.newDocPositions[DocId+1];

                for (int i = startOfDoc; i < endOfDoc; i++)
                {
                    selection += IndexData.parser.currentFile[i];
                }

                for (int i = 0; i < Position - startOfDoc; i++)
                {
                    wordPosition += IndexData.parser.currentFile[startOfDoc + i].Length;
                }

                rtxtFileContent.Text = selection;
                rtxtFileContent.Select(wordPosition, IndexData.parser.currentFile[Position].Length);
                rtxtFileContent.SelectionColor = Color.Red;
                rtxtFileContent.SelectionBackColor = Color.Yellow;	
            }
            else
            {
               int x = -150; 
               int z = 150;

               if (Position < 150)
                   x = 0;
               //if (IndexData.DocStrings[DocId].ElementAt(Position).Length + Position < 300)
               //    z = 1;

                for (int i = x; i < z; i++)
                {
                    selection += IndexData.DocStrings[DocId].ElementAt(Position + i);
                    if (i < 0)
                        wordPosition += IndexData.DocStrings[DocId].ElementAt(Position + i).Length;
                }

                rtxtFileContent.Text = selection;
                rtxtFileContent.Select(wordPosition, IndexData.DocStrings[DocId].ElementAt(Position).Length);
                rtxtFileContent.SelectionColor = Color.Red;
                rtxtFileContent.SelectionBackColor = Color.Yellow;	
            }    	
			
		}

        private void rtxtFileContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
	}
}

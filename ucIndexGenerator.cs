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

namespace Cobra {
    public partial class ucIndexGenerator : UserControl {
        private bool splitByParagraph;

        public ucIndexGenerator()
        {
            InitializeComponent();
           
        }

        private void rdoFile_CheckedChanged(object sender, EventArgs e) 
        {
            panText.Visible = false;
            panFileUpload.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panFileUpload.Visible = false;
            panText.Visible = true;
        }

        private void btnBrowse_Click_1(object sender, EventArgs e) //TODO: just add all files from current directory
        {
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select a text File(s)";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            foreach (string file in openFileDialog1.FileNames)
            {
                txtFileName.Text = file;
                lstFiles.Items.Add(txtFileName.Text);
            }
        }


        private void btnGenIndex_Click(object sender, EventArgs e)
        {
            Lexer lexer = null;
            lblMessage.Text = "";

            if (radioButton1.Checked == true)
            {
                    panText.Visible = false;
                    panFileUpload.Visible = true;
                    splitByParagraph = true;
                
            }

              
            try
            {
                if (rdoText.Checked)
                {

                    System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.ExecutablePath + "\\UserEnterText.txt");
                    sw.Write(txtIndexText.Text);
                    IndexData.FileListInfo.Add(Application.ExecutablePath + "\\UserEnterText.txt");


                    lexer = new Lexer(txtIndexText.Text);
                    IndexData.parser = new Parser(lexer, IndexData.invertedIndex, IndexData.wordList, IndexData.docID, splitByParagraph);

                    IndexData.parser.Evaluate();
                    
                }
                else
                {              
                    foreach (string file in lstFiles.Items)
                    {
                        System.IO.StreamReader sr = new  System.IO.StreamReader(file);

                        lexer = new Lexer(sr.ReadToEnd());

                        IndexData.parser = new Parser(lexer, IndexData.invertedIndex, IndexData.wordList, IndexData.docID, splitByParagraph);
                        IndexData.parser.Evaluate();

                        if (!splitByParagraph)
                        {
                            IndexData.DocStrings.Add(IndexData.parser.currentFile);
                            IndexData.docID++;
                        }

                        IndexData.FileListInfo.Add(file);

                        sr.Close(); // closing streamreader
                    }
                }

                IndexData.termDictionary = IndexData.parser.invertedIndex; //Key, <DocId & Posting>
                IndexData.hstTable = IndexData.parser.wordList;
                // assign k-gram indexes to shared variable class??? 
                IndexData.oneGramIndex = IndexData.parser.oneGramIndex;
                IndexData.twoGramIndex = IndexData.parser.twoGramIndex;

                lblMessage.Text= "Indexes generated successfully";
            }
            catch (Exception ex)
            {
                lblMessage.Text="Error occured while generating Indexes... Error Message: " + ex.Message;
            }

        }


        //private void radioButton1_CheckedChanged_2(object sender, EventArgs e)
        //{
        //    panText.Visible = false;
        //    panFileUpload.Visible = true;
        //    splitByParagraph = true;
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            IndexData.parser.reset();
            lblMessage.Text = "";
        }

    }
}

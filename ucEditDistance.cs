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
    public partial class ucEditDistance : UserControl
    {
        public ucEditDistance()
        {
            InitializeComponent();
        }

        private void btnCheckEdit_Click(object sender, EventArgs e)
        {

            int[][] Matrix;
            InitGrid();

            EditDistance ed = new EditDistance();
            ed.CalculateEditDistance(txtSource.Text, txtDestination.Text);

            Matrix = ed.GetResultingMatrix();

            int Rows = Matrix.Length;
            int Col = Matrix.Max(subArray => subArray.Length);
            int RowIndex;
            for (int i = 0; i < Rows; i++)
            {
                RowIndex=dgwEditMap.Rows.Add();

                if(i>0)
                    dgwEditMap.Rows[i].HeaderCell.Value = txtSource.Text[i-1].ToString();

                for (int j = 0; j < Col+1; j++)
                {
                    if (i == 0 && j == 0)
                        dgwEditMap[j, i].Value = "";
                    else if (j == 0)
                        dgwEditMap[j, i].Value = txtSource.Text[i-1];
                    else
                        dgwEditMap[j, i].Value = Matrix[i][j-1];
                }
            }
        }

        private void InitGrid()
        {


            dgwEditMap.Columns.Add("blank", "");
            dgwEditMap.Columns.Add("lamda", "");

            for (int i = 0; i < txtDestination.Text.Length; i++)
            {
                dgwEditMap.Columns.Add(i.ToString(), txtDestination.Text[i].ToString());
            }

           

        }
    }
}

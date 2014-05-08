using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cobra {
    public partial class ucCosineSimilarity : UserControl {

        public ucCosineSimilarity()
        {          
            InitializeComponent();
            int docCount = IndexData.FileListInfo.Count;
            double [,] matrix = calculateMatrix(docCount);
            String array = "";

            for (int i = 0; i < docCount; i++)
                array += "\t" + i;
            array += "\n";

            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                array += i + "\t";
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    if (matrix[i, j] != 0.0)
                        array += String.Format("{0:0.00}", matrix[i, j]);
                    else
                        array += "-";
                    array += "\t";
                }
                array += "\n";
            }
            richTextBox1.Text += array;

            String docCollection = "";
            int doc = 0;
            foreach (String x in IndexData.FileListInfo)
            {
                docCollection += String.Format("Document {0}: {1}\n", doc, formatPath(x));
                doc++;
            }

            richTextBox2.Text = docCollection;
        }

        public String formatPath(String path)
        {
            int z = path.Length-1;

            while (!path.ElementAt(z).Equals('\\'))
                z--;

            return path.Substring(z);
        }

        public double[,] calculateMatrix(int listLength)
        {
            double[,] matrix = new double[listLength, listLength];
            for(int i = 0; i < listLength; i++)
                for (int j = i + 1; j < listLength; j++)
                    matrix[i, j] = similarity(i, j);

            return matrix;
        }

        public double similarity(int x, int y)
        {
            double[][] termFrequencyVectors = buildTermFrequencyVectors(x, y);
            double[] termFrequencyForX = termFrequencyVectors[0];
            double[] termFrequencyForY = termFrequencyVectors[1];

            return sim(termFrequencyForX, termFrequencyForY);
        }

        public double sim(double[] v1, double[] v2)
        {
            double a = getDotProduct(v1, v2);
            double b = getNorm(v1) * getNorm(v2);
            return a / b;
        }


        private double getDotProduct(double[] v1, double[] v2)
        {
            double sum = 0.0;
            for (int i = 0, n = v1.Count(); i < n; i++)
                sum += v1[i] * v2[i];

            return sum;
        }

        private double getNorm(double[] v)
        {
            double sum = 0.0;
            for (int i = 0, n = v.Count(); i < n; i++)
                sum += v[i] * v[i];

            return Math.Sqrt(sum);
        }

        public double[][] buildTermFrequencyVectors(int docID1, int docID2)
        {
            // create a set of terms with flags
            Dictionary<String, int> allAttributes = new Dictionary<String, int>();

            foreach(KeyValuePair<int, List<InterpreterNIndexer.Index>> x in IndexData.parser.invertedIndex)
            {
                foreach (InterpreterNIndexer.Index z in x.Value)
                {
                    if (z.docId == docID1 && !allAttributes.ContainsKey(x.Key.ToString()))
                        allAttributes.Add(x.Key.ToString(), 0x01);
                    if(z.docId == docID2)
                        if(!allAttributes.ContainsKey(x.Key.ToString()))
                             allAttributes.Add(x.Key.ToString(), 0x02);
                        else
                            allAttributes[x.Key.ToString()] = 0x03;
                }

            }

            // create term frequency vectors
            int n = allAttributes.Count();
            double[] termFrequencyForX = new double[n];
            double[] termFrequencyForY = new double[n];
            int i = 0;

            foreach (KeyValuePair<String, int> e in allAttributes)
            {
                int flags = e.Value;
                termFrequencyForX[i] = flags & 0x01;
                termFrequencyForY[i] = flags >> 1;
                i++;
            }

            return new double[][] { termFrequencyForX, termFrequencyForY };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    
    }
}

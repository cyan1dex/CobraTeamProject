using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cobra.InterpreterNIndexer;

namespace Cobra
{
    public partial class ucMemoryUtilizationCases : UserControl
    {
        public int[] gapBarGraph = Frequency.getGapBarGraph();

        private struct MemoryUtilizationStats
        {
            public long ByteDocIDEncoding;
            public long HuffmanGapEncoding;
            public long VBGapEncoding;
        };

        public ucMemoryUtilizationCases()
        {
            InitializeComponent();
        }

        private void ucMemoryUtilizationCases_Load(object sender, EventArgs e)
        {
            long totalpostings = TotalPostings();
            long totalgaps = TotalGaps();
            txtTerms.Text = IndexData.termDictionary.Count.ToString();
            txtPostings.Text = totalpostings.ToString();
            txtGaps.Text = totalgaps.ToString();
            MemoryUtilizationStats mus = GetMemoryUtilizationStats(totalpostings, totalgaps);
            txtPostingsEncoded.Text = mus.ByteDocIDEncoding.ToString();
            txtHuffmanEncoding.Text = mus.HuffmanGapEncoding.ToString();
            txtVBEncoding.Text = mus.VBGapEncoding.ToString();
        }

        private long TotalPostings()
        {
            long totalPosting = 0;
            foreach (KeyValuePair<int, List<Index>> li in IndexData.termDictionary)
            {
                totalPosting += li.Value.Count;
            }
            return totalPosting;
        }

        private long TotalGaps()
        {
            long totalgaps = 0;
            int tindex = gapBarGraph.Length;
            for (int i = 0; i < tindex; i++ )
            {
                totalgaps += gapBarGraph[i];
            }
            return totalgaps;
        }

        private MemoryUtilizationStats GetMemoryUtilizationStats(long totalpostings, long totalgaps)
        {
            MemoryUtilizationStats mus;
            double Pi;
            double HuffmanMemUsed=0,VBMemUsed=0;
            mus.ByteDocIDEncoding = 4 * totalpostings;
            double gapFrequency;

            int tindex = gapBarGraph.Length;
            for (int i = 0; i < tindex; i++)
            {
                gapFrequency = gapBarGraph[i];
                if (gapFrequency > 0)
                {
                    Pi = gapFrequency / totalgaps;
                    HuffmanMemUsed += gapFrequency * Math.Ceiling(Math.Log(1 / Pi, 2));
                    VBMemUsed += gapFrequency * 8 * Math.Ceiling(Math.Ceiling(Math.Log(i + 1, 2)) / 7);
                }
            }

            mus.HuffmanGapEncoding = Convert.ToInt64(HuffmanMemUsed / 8);
            mus.VBGapEncoding = Convert.ToInt64(VBMemUsed / 8);
            return mus;
        }
    }
}

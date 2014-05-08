using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cobra
{
    public partial class ucHeap : UserControl
    {
        Series series1;
        public ucHeap()
        {
            InitializeComponent();
			DisplayGraph();
        }

		private void DisplayGraph()
		{		
            this.chart1.Titles.Add("Heaps");

            series1 = this.chart1.Series.Add("token-to-term");
            chart1.Series["token-to-term"].ChartType = SeriesChartType.Line;

            foreach (int val in IndexData.parser.heaps)
                chart1.Series["token-to-term"].Points.AddY(val);
	
		}
    }

}

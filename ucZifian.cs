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
    public partial class ucZifian : UserControl
    {
        public ucZifian()
        {
            InitializeComponent();
			DisplayGraph();
        }

		private void DisplayGraph()
		{
            List<int> frqDist = Frequency.calcFrqDist();
            int length = frqDist.Count;
			
			// Assign data to graph
            for (int pointIndex = 0; pointIndex < length; pointIndex += 50)
			{
                chart1.Series["Distribution"].Points.AddY(frqDist[pointIndex]);
			}

			// Setting up the units for x and y axis
			chart1.ChartAreas[0].AxisY.Interval = 500;
			chart1.ChartAreas[0].AxisX.Interval = 15;
		

			chart1.Series["Distribution"].ChartType = SeriesChartType.FastLine;		
			chart1.Series["Distribution"].IsValueShownAsLabel = true;
	

		}
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace fifi.WinUI
{
    class ScatterPlot
    {
        private Chart _chart1;

        public ScatterPlot(double[][][] input, int numberOfClusters)
        {
            _chart1.Series.Clear();

            for (int i = 0; i < numberOfClusters; i++)
            {
                AddSeries(string.Format("Cluster {0}",i+1));

                for (int j = 0; j < input[i][0].Length; j++)
                {
                    DataPoint node = new DataPoint();
                    node.SetValueXY(input[0][j], input[1][j]);

                    AddDatapointToSeries(i, node);
                }
            }
            
            
        }

        private void AddSeries(string seriesName)
        {
            _chart1.Series.Add(seriesName);
            _chart1.Series[seriesName].ChartType = SeriesChartType.Point;
        }

        private void AddDatapointToSeries(int seriesNumber, DataPoint node)
        {
            _chart1.Series[seriesNumber].Points.Add(node);
        }

        public Chart Draw()
        {
            return _chart1;
        }


        public void ChangeColors(Color backgroundColor)
        {
            _chart1.BackColor = backgroundColor;
        }
    }
}

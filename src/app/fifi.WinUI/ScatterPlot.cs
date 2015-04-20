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
using fifi.Core;

namespace fifi.WinUI
{
    class ScatterPlot
    {
        private Chart _chart1;

        public ScatterPlot(List<MDSCluster> input)
        {
            _chart1.Series.Clear();
            ClusterNumber = 1;

            foreach (var listitem in input)
            {
                AddSeries(string.Format("Cluster {0}", ClusterNumber));


                foreach (var Datanode in listitem.MDSDataPoints)
                {
                    // Not complete call AddDatapointToSeries(ClusterNumber, Datanode)
                }

                ClusterNumber++;
            }
            
            
        }

        private int ClusterNumber;

        private void AddSeries(string seriesName)
        {
            _chart1.Series.Add(seriesName);
            _chart1.Series[seriesName].ChartType = SeriesChartType.Point;
        }

        // Explicit namespace used since fifi already contains a DataPoint class
        private void AddDatapointToSeries(int seriesNumber, System.Windows.Forms.DataVisualization.Charting.DataPoint node)
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

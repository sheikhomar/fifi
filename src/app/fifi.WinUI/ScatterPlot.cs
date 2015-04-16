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

            foreach (MDSCluster.MDSDataPoints listitem in input)
            {
                AddSeries(string.Format("Cluster {0}", ClusterNumber));
                ClusterNumber++;

                foreach (DataPoint Datanode in listitem)
                {
                    
                }
            }
            
            
        }

        private int ClusterNumber;

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

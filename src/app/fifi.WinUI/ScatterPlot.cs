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
using CDataPoint = System.Windows.Forms.DataVisualization.Charting.DataPoint;
using fifi.Core;

namespace fifi.WinUI
{
    class ScatterPlot
    {
        private Chart _chart1;

        public ScatterPlot(List<MDSCluster> input, Chart winFormChart)
        {
            _chart1 = winFormChart;
            _chart1.Series.Clear();
            ClusterNumber = 1;

            foreach (var listitem in input)
            {
                AddSeries(string.Format("Cluster {0}", ClusterNumber));

                foreach (var Datanode in listitem.MDSDataPoints)
                {
                    AddDatapointToSeries(ClusterNumber, Datanode);
                }

                ClusterNumber++;
            }

            SetAxisScales(ClusterNumber);

        }

        private int ClusterNumber;

        public Chart Draw()
        {
            return _chart1;
        }


        // Private methods called by constructor to construct and style chart
        private void AddSeries(string seriesName)
        {
            _chart1.Series.Add(seriesName);
            _chart1.Series[seriesName].ChartType = SeriesChartType.Point;
        }


        private void AddDatapointToSeries(int seriesNumber, CDataPoint node)
        {
            _chart1.Series[seriesNumber - 1].Points.Add(node);
        }

        private void SetAxisScales(int NumberOfSeries)
        {

            #region Declaration of local variables
            double XMax = double.MinValue;
            double XMin = double.MaxValue;
            double YMax = double.MinValue;
            double YMin = double.MaxValue;
            #endregion

            #region Loop which finds the Min/Max X- and Y-values
            for (int i = 0; i < NumberOfSeries - 1; i++)
            {
                if (_chart1.Series[i].Points.FindMaxByValue("X").XValue > XMax)
                {
                    XMax = _chart1.Series[i].Points.FindMaxByValue("X").XValue;
                }

                if (_chart1.Series[i].Points.FindMinByValue("X").XValue < XMin)
                {
                    XMin = _chart1.Series[i].Points.FindMinByValue("X").XValue;
                }

                if (_chart1.Series[i].Points.FindMaxByValue("Y").YValues[0] > YMax)
                {
                    YMax = _chart1.Series[i].Points.FindMaxByValue("Y").YValues[0];
                }

                if (_chart1.Series[i].Points.FindMinByValue("Y").YValues[0] < YMin)
                {
                    YMin = _chart1.Series[i].Points.FindMinByValue("Y").YValues[0];
                }
            }
            #endregion

            #region Assign axis boundaries based on 
            _chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(XMax);
            _chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(XMin);
            _chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(YMax);
            _chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(YMin);
            #endregion

        }

        private void SetAxisScales2(int NumberOfSeries)
        {
            double XMax = double.MinValue;
            double XMin = double.MaxValue;
            double YMax = double.MinValue;
            double YMin = double.MaxValue;

            for (int i = 0; i < NumberOfSeries - 1; i++)
            {
                foreach (var node in _chart1.Series[i].Points)
                {
                    if (node.XValue > XMax)
                    {
                        XMax = node.XValue;
                    }

                    if (node.XValue < XMin)
                    {
                        XMin = node.XValue;
                    }

                    // Y-values are checked after X-values. MDS datapoints only contain 1 Y-value
                    if (node.YValues[0] > YMax)
                    {
                        YMax = node.YValues[0];
                    }

                    if (node.YValues[0] < YMin)
                    {
                        YMin = node.YValues[0];
                    }
                }
            }

            _chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(XMax);
            _chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(XMin);
            _chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(YMax);
            _chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(YMin);

        }


    }
}

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
    public class ScatterPlot
    {
        private ScatterPlotUtility _utility = new ScatterPlotUtility();

        private Chart _chart1;

        public ScatterPlot(IList<DrawableDataPoint> input, Chart winFormChart)
        {
            _chart1 = winFormChart;
            _chart1.Series.Clear();
            ClusterNumber = 1;

            foreach (var grouping in input.GroupBy(e => e.Group))
            {
                AddSeries(grouping.Key ?? "Empty");

                foreach (var dataPoint in grouping)
                {
                    CDataPoint Datanode = new CDataPoint(dataPoint.X, dataPoint.Y);
                    
                    AddDatapointToSeries(ClusterNumber, Datanode, dataPoint);
                }

                ClusterNumber++;
            }

            SetAxisScales(ClusterNumber);
            StyleChart();

        }

        private int ClusterNumber;

        public Chart Draw()
        {
            return _chart1;
        }

        #region Private methods called by constructor to construct and style chart

        private void AddSeries(string seriesName)
        {
            _chart1.Series.Add(seriesName);
            _chart1.Series[seriesName].ChartType = SeriesChartType.Point;
        }


        private void AddDatapointToSeries(int seriesNumber, CDataPoint node, DrawableDataPoint originalObject)
        {
            node.ToolTip = string.Format("Cluster {0}\n" + "ID: {1}\n",
                seriesNumber, originalObject.Origin.Id);
            node.Tag = originalObject;

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

            _chart1.ChartAreas[0].AxisX.Interval = 
                _utility.ComputeAxisInterval(_chart1.ChartAreas[0].AxisX.Maximum, _chart1.ChartAreas[0].AxisX.Minimum);
            _chart1.ChartAreas[0].AxisY.Interval = 
                _utility.ComputeAxisInterval(_chart1.ChartAreas[0].AxisY.Maximum, _chart1.ChartAreas[0].AxisY.Minimum);

            #region Assign axis boundaries based on results
            _chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(XMax);
            _chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(XMin);
            _chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(YMax);
            _chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(YMin);
            #endregion

        }

        private void StyleChart()
        {
            _chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            _chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        }

        #endregion

        private void PointClicked()
        {
            // Her skal laves eventhandling
        }

        #region Point Highlighting
        private Stack<Color> _colorStack = new Stack<Color>();
        private Stack<CDataPoint> _pointStack = new Stack<CDataPoint>();

        private void HighlightPoint(CDataPoint inputPoint)
        {
            // If a previous point was highlighted and stored, restore its original color and size
            if (_pointStack.Count > 0)
            {
                CDataPoint localPoint = _pointStack.Pop();
                localPoint.MarkerBorderColor = _colorStack.Pop();
                localPoint.MarkerBorderWidth /= 2;
                localPoint.MarkerSize /= 2;
            }

            // Save point-to-be-highlighted's information on stacks
            _colorStack.Push(inputPoint.Color);
            _pointStack.Push(inputPoint);

            // Highlight inputPoint
            inputPoint.MarkerBorderColor = Color.Black;
            inputPoint.MarkerBorderWidth *= 2;
            inputPoint.MarkerSize *= 2;
        }
        #endregion

    }
}

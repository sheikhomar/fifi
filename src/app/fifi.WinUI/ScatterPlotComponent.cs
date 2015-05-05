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
    public partial class ScatterPlotComponent : UserControl
    {
        public ScatterPlotComponent()
        {
            InitializeComponent();
        }

        public event EventHandler<DrawableDataPoint> DataPointClick;

        private ScatterPlotUtility _utility = new ScatterPlotUtility();
        private int ClusterNumber;


        public void BuildScatterPlot(IList<DrawableDataPoint> input)
        {
            chart1.Series.Clear();
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

        #region Private methods called by BuildScatterPlot to construct and style chart

        private void AddSeries(string seriesName)
        {
            Series s = chart1.Series.Add(seriesName);
            s.ChartType = SeriesChartType.Point;
        }


        private void AddDatapointToSeries(int seriesNumber, CDataPoint node, DrawableDataPoint originalObject)
        {
            node.Tag = originalObject;

            chart1.Series[seriesNumber - 1].Points.Add(node);
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
                if (chart1.Series[i].Points.FindMaxByValue("X").XValue > XMax)
                {
                    XMax = chart1.Series[i].Points.FindMaxByValue("X").XValue;
                }

                if (chart1.Series[i].Points.FindMinByValue("X").XValue < XMin)
                {
                    XMin = chart1.Series[i].Points.FindMinByValue("X").XValue;
                }

                if (chart1.Series[i].Points.FindMaxByValue("Y").YValues[0] > YMax)
                {
                    YMax = chart1.Series[i].Points.FindMaxByValue("Y").YValues[0];
                }

                if (chart1.Series[i].Points.FindMinByValue("Y").YValues[0] < YMin)
                {
                    YMin = chart1.Series[i].Points.FindMinByValue("Y").YValues[0];
                }
            }
            #endregion

            chart1.ChartAreas[0].AxisX.Interval = 
                _utility.ComputeAxisInterval(chart1.ChartAreas[0].AxisX.Maximum, chart1.ChartAreas[0].AxisX.Minimum);
            chart1.ChartAreas[0].AxisY.Interval = 
                _utility.ComputeAxisInterval(chart1.ChartAreas[0].AxisY.Maximum, chart1.ChartAreas[0].AxisY.Minimum);

            #region Assign axis boundaries based on results
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(XMax);
            chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(XMin);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(YMax);
            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(YMin);
            #endregion

        }

        private void StyleChart()
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
        }

        #endregion

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

        public void HighlightPoint(IdentifiableDataPoint inputPoint)
        {
            foreach (var Series in chart1.Series)
            {
                foreach (var Point in Series.Points)
                {
                    DrawableDataPoint drawDataPoint = (DrawableDataPoint)Point.Tag;
                    if (inputPoint == drawDataPoint.Origin)
                    {
                        HighlightPoint(Point);
                        return;
                    }
                }
            }
        }

        public void HighlightPoint(DrawableDataPoint inputPoint)
        {
            IdentifiableDataPoint drawPoint = inputPoint.Origin;
            HighlightPoint(drawPoint);
        }


        #region Mouseover Highlighting
        private CDataPoint _mouseOverHighligt = null;

        private void MouseOverOn(CDataPoint inputPoint)
        {
            MouseOverOf();

            if (_pointStack.Count == 0)
            {
                MouseOverOnHelper(inputPoint);
            }

            if (_pointStack.Count != 0 && inputPoint != _pointStack.Peek())
            {
                MouseOverOnHelper(inputPoint);
            }
        }

        private void MouseOverOf()
        {
            if (_mouseOverHighligt != null)
            {
                _mouseOverHighligt.MarkerSize /= 2;
                _mouseOverHighligt = null;
            }
        }

        private void MouseOverOnHelper(CDataPoint inputPoint)
        {
            _mouseOverHighligt = inputPoint;
            inputPoint.MarkerSize *= 2;
        }


        #endregion


        #endregion

        #region Eventhandlers
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                CDataPoint dataPoint = (CDataPoint)result.Object;
                HighlightPoint(dataPoint);
                if (DataPointClick != null)
                {
                    DrawableDataPoint drawdataPoint = (DrawableDataPoint)dataPoint.Tag;
                    DataPointClick(this, drawdataPoint);
                }
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                CDataPoint dataPoint = (CDataPoint)result.Object;
                MouseOverOn(dataPoint);
            }
            else
            {
                MouseOverOf();
            }

        }
        #endregion

    }
}

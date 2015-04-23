using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NUnit.Framework;
using fifi.Core;
using fifi.WinUI;

namespace fifi.Tests.WinUI
{
    [TestFixture]
    class ScatterPlotTests
    {
        
        [TestCase(10.1, 0, 8.1, 0, 11, 0, 9, 0)]
        [TestCase(5.85, 0.65, 16.2, -0.62, 6, 0, 17, -1)]
        public void ScatterPlot_AxisMinMaxTester_MinMaxProperlyRoundedTest(double XMax, double XMin, double YMax, 
            double YMin, double ExpectedXMax, double ExpectedXMin, double ExpectedYMax, double ExpectedYMin)
        {
            // Arrange
            List<DrawableDataPoint> list = new List<DrawableDataPoint>();
            DrawableDataPoint data1 = new DrawableDataPoint(new fifi.Core.Algorithms.Cluster(new fifi.Core.Algorithms.Centroid(4)), XMax, YMax);
            DrawableDataPoint data2 = new DrawableDataPoint(new fifi.Core.Algorithms.Cluster(new fifi.Core.Algorithms.Centroid(4)), XMin, YMin);
            list.Add(data1);
            list.Add(data2);
            Chart chart1 = new Chart();

            #region Region containing standard chart magic
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new System.Drawing.Point(0, 0);
            chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new System.Drawing.Size(660, 470);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            #endregion


            // Act
            ScatterPlot Plot = new ScatterPlot(list, chart1);

            // Assert
            Assert.AreEqual(ExpectedXMax, chart1.ChartAreas[0].AxisX.Maximum);
            Assert.AreEqual(ExpectedXMin, chart1.ChartAreas[0].AxisX.Minimum);
            Assert.AreEqual(ExpectedYMax, chart1.ChartAreas[0].AxisY.Maximum);
            Assert.AreEqual(ExpectedYMin, chart1.ChartAreas[0].AxisY.Minimum);
        
        }
    }
}

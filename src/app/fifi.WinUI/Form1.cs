using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fifi.Data;
using fifi.Data.Configuration.Import;
using fifi.Core.Algorithms;
using fifi.Core;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace fifi.WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        private void Test()
        {
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDataImporter(reader);
            var dataCollection = importer.Run();
            var k = 4;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataCollection, k, distanceMetric);
            var result = kmeans.Generate();

            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            double[,] matrix = distanceMatrix.GenerateMatrix();

            var mds = new MultiDimensionalScaling2(matrix);
            double[,] resultMatrix = mds.Calculate(); //a shitty name

            List<DrawableDataPoint> drawableDataPoints = new List<DrawableDataPoint>();

            for (int row = 0; row < resultMatrix.GetLength(1); row++)
            {
                double x = resultMatrix[0, row];
                double y = resultMatrix[1, row];
                var dataPoint = dataCollection[row];
                var cluster = result.FindCluster(dataPoint);
                drawableDataPoints.Add(new DrawableDataPoint(cluster, x, y));
            }

            drawableDataPoints = drawableDataPoints.OrderBy(d => d.Group).ToList();
            
            var scatterPlot = new ScatterPlot(drawableDataPoints, chart1);
            scatterPlot.Draw();

            ChartArea area = chart1.ChartAreas[0];

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;
        }
    }
}

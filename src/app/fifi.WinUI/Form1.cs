using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fifi.Data;
using fifi.Data.Configuration.Import;
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
            IConfiguration configuration =
                (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDynamicDataImporter(reader, configuration);
            var dataCollection = importer.Run();
            var k = 4;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataCollection, k, distanceMetric);
            var result = kmeans.Calculate();

            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);

            MultiDimensionalScaling mds = new MultiDimensionalScaling(distanceMatrix);
            Matrix coordinateMatrix = mds.Calculate();

            List<DrawableDataPoint> drawableDataPoints = MakeClusterAndCoordinatesDrawable(coordinateMatrix, result, dataCollection);

            var scatterPlot = new ScatterPlot(drawableDataPoints, chart1);
            scatterPlot.Draw();

            ChartArea area = chart1.ChartAreas[0];

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;
        }

        private List<DrawableDataPoint> MakeClusterAndCoordinatesDrawable(Matrix coordinateMatrix, ClusteringResult clusters, IdentifiableDataPointCollection dataCollection)
        {
            List<DrawableDataPoint> drawableDataPoints = new List<DrawableDataPoint>();

            for (int col = 0; col < coordinateMatrix.Column; col++)
            {
                double x = coordinateMatrix[0, col];
                double y = coordinateMatrix[1, col];
                IdentifiableDataPoint dataPoint = dataCollection[col];
                DrawableDataPoint drawableDataPoint = new DrawableDataPoint(dataPoint, x, y);
                Cluster cluster = clusters.FindCluster(dataPoint);
                if (cluster != null)
                    drawableDataPoint.Group = string.Format("Cluster {0}", cluster.Id);
                drawableDataPoints.Add(drawableDataPoint);
            }
            return drawableDataPoints.OrderBy(d => d.Group).ToList();
        }
    }
}

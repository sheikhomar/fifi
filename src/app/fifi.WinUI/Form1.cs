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
            /*
            MDSCluster Cluster1 = new MDSCluster();
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, 4));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(4, 4));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(3, 3.5));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 2));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, 3.7));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.3, 4.1));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.5, 4.8));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.8, 3));

            MDSCluster Cluster2 = new MDSCluster();
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 1));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 1.2));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1.1, 1.2));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1.4, 0.78));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.8, 0.7));

            MDSCluster Cluster3 = new MDSCluster();
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(8, 6));
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(8.6, 8));
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(9, 7.4));

            List<MDSCluster> input = new List<MDSCluster>();
            input.Add(Cluster1);
            input.Add(Cluster2);
            input.Add(Cluster3);
            



            ScatterPlot result = new ScatterPlot(input, chart1);
            result.Draw();
            */
            Test();
        }

        private void Test()
        {
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDataImporter(reader);
            var dataCollection = importer.Run();
            var k = 5;
            var distanceMetric = new EuclideanMetric();

            var kmeans = new KMeans(dataCollection, k, distanceMetric);
            var result = kmeans.Generate();

            DistanceMatrix distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            double[,] matrix = distanceMatrix.GenerateMatrix();

            var mds = new MultiDimensionalScaling(matrix);
            double[,] resultMatrix = mds.Calculate(); //a shitty name
            MDSCluster Cluster1 = new MDSCluster();
            

            for (int row = 0; row < resultMatrix.GetLength(1); row++)
            {
                double x = resultMatrix[0, row];
                double y = resultMatrix[1, row];
                Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(x, y));
                
            }
            List<MDSCluster> input = new List<MDSCluster>();
            input.Add(Cluster1);
            var scatterPlot = new ScatterPlot(input, chart1);
            scatterPlot.Draw();


            ChartArea area = chart1.ChartAreas[0];

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;
            


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using fifi.Core;
using fifi.WinUI.Properties;

namespace fifi.WinUI
{
    public partial class DataVisualizationForm : BaseForm
    {
        private readonly IdentifiableDataPointCollection dataSet;
        private readonly DataConversionTask dataConversionTask;
        private IDistanceMetric distanceMetric;
        private IList<DrawableDataPoint> chartDataSource;
        private ClusteringResult clusterResult;
        private DistanceMatrix distanceMatrix;
        private KMeans kmeans;
        private string currentDistanceMatrix;
        private int currentClusterNumber;
        private string currentClusterAlgorithm;

        public DataVisualizationForm()
        {
            InitializeComponent();
            this.loadingImage.Location = this.scatterPlotControl1.Location;
            this.loadingImage.Size = this.scatterPlotControl1.Size;
            scatterPlotControl1.DataPointClick += DataPointClicked;
            grpAlgorithmSettings.Enabled = false;
            currentDistanceMatrix = null;
            currentClusterNumber = 0;
            currentClusterAlgorithm = null;

            // Resources.Loading is stolen from https://dribbble.com/shots/1420523-Loading-Chart
            this.loadingImage.Image = Resources.Loading2;
        }

        public DataVisualizationForm(IdentifiableDataPointCollection dataSet) 
            : this()
        {
            this.dataSet = dataSet;
            distanceMetric = DistanceMatrix(currentDistanceMatrix, distanceMetric);

            dataConversionTask = new DataConversionTask();
            dataConversionTask.Success += DataConversionTask_Success;
            dataConversionTask.Failure += DataConversionTask_Failure;
        }

        private void DataConversionTask_Success(object sender, DataConversionResult result)
        {
            loadingImage.Visible = false;
            chartDataSource = result.DataPoints;
            distanceMatrix = result.DistanceMatrix;

            scatterPlotControl1.BuildScatterPlot(chartDataSource);

            grpAlgorithmSettings.Enabled = true;
            MakeTheWholeThingWork();
        }

        private void DataConversionTask_Failure(object sender, IEnumerable<Exception> errors)
        {
            loadingImage.Visible = false;
            StringBuilder temp = new StringBuilder();
            temp.AppendLine("Data import failed with following errors:");
            foreach (var exp in errors)
                temp.Append(" - ").AppendLine(exp.Message);

            MessageBox.Show(temp.ToString(), "Data conversion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DataVisualizationForm_Shown(object sender, EventArgs e)
        {
            dataConversionTask.Start(dataSet, distanceMetric);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeTheWholeThingWork();
        }

        private void MakeTheWholeThingWork()
        {
            if (chartDataSource != null)
            {
                Cluster cluster;

                distanceMetric = DistanceMatrix(currentDistanceMatrix, distanceMetric);

                clusterResult = ClusterCalculate(clusterResult);

                /* Executing scatterplot */
                foreach (var dataPoint in chartDataSource)
                {
                    cluster = clusterResult.FindCluster(dataPoint.Origin);
                    if (cluster != null)
                    {
                        dataPoint.Group = string.Format("Cluster {0}", cluster.Id);
                    }
                }
                chartDataSource = chartDataSource.OrderBy(item => item.Group).ToList();

                scatterPlotControl1.BuildScatterPlot(chartDataSource);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //OutlierDetectForm form = new OutlierDetectForm(distanceMatrix);
            //form.ShowDialog();
        }

        private void DataPointClicked(object sender, DrawableDataPoint e)
        {
            if (clusterResult != null)
            {
                IdentifiableDataPoint point = e.Origin;
                Cluster cluster = clusterResult.FindCluster(point);
                if (cluster != null)
                {
                    dataPointDetailsComponent1.GenerateDetails(point, cluster.Centroid);
                }
            }
        }

        private IDistanceMetric DistanceMatrix(string currentDistanceMatrix, IDistanceMetric currentMetric)
        {
            string distanceMatrixName = cbDistanceAlgo.Text;

            /* Choosing distance algorithm */
            switch (distanceMatrixName)
            {
                case "Euclidian distance":
                    if (distanceMatrixName != currentDistanceMatrix)
                    {
                        currentDistanceMatrix = distanceMatrixName;
                        return new EuclideanMetric();
                    }
                    break;
                default:
                    if (distanceMatrixName != currentDistanceMatrix)
                    {
                        currentDistanceMatrix = distanceMatrixName;
                        return new EuclideanMetric();
                    }
                    break;
            }
            return currentMetric;
        }

        private ClusteringResult ClusterCalculate(ClusteringResult currentClusterResult)
        {
            int inputClusterNumber = Convert.ToInt32(numberOfClusters.Value);
            string inputClusterAlgo = cbClusteringAlgo.Text;

            if (inputClusterNumber != currentClusterNumber)
            {
                currentClusterNumber = inputClusterNumber;

                /* Choosing clustering algorithm without name filter */
                switch (inputClusterAlgo)
                {
                    case "K-means":
                            currentClusterAlgorithm = inputClusterAlgo;
                            kmeans = new KMeans(this.dataSet, currentClusterNumber, distanceMetric);
                            return kmeans.Calculate();
                    default:
                            currentClusterAlgorithm = inputClusterAlgo;
                            kmeans = new KMeans(this.dataSet, currentClusterNumber, distanceMetric);
                            return kmeans.Calculate();
                }
            }

            /* Choosing clustering algorithm with name filter */
            switch (inputClusterAlgo)
            {
                case "K-means":
                    if (inputClusterAlgo != currentClusterAlgorithm)
                    {
                        currentClusterAlgorithm = inputClusterAlgo;
                        kmeans = new KMeans(this.dataSet, currentClusterNumber, distanceMetric);
                        return kmeans.Calculate();
                    }
                    break;
                default:
                    if (inputClusterAlgo != currentClusterAlgorithm)
                    {
                        currentClusterAlgorithm = inputClusterAlgo;
                        kmeans = new KMeans(this.dataSet, currentClusterNumber, distanceMetric);
                        return kmeans.Calculate();
                    }
                    break;
            }
            return currentClusterResult;
        }
    }
}

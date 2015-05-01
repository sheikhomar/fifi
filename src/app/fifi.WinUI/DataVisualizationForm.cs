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
        private readonly IDistanceMetric distanceMetric;
        private List<DrawableDataPoint> chartDataSource;

        public DataVisualizationForm()
        {
            InitializeComponent();
            this.loadingImage.Location = this.chart.Location;
            this.loadingImage.Size = this.chart.Size;
            grpAlgorithmSettings.Enabled = false;

            // Resources.Loading is stolen from https://dribbble.com/shots/1420523-Loading-Chart
            this.loadingImage.Image = Resources.Loading2;
        }

        public DataVisualizationForm(IdentifiableDataPointCollection dataSet, IDistanceMetric distanceMetric) 
            : this()
        {
            this.dataSet = dataSet;
            this.distanceMetric = distanceMetric;

            dataConversionTask = new DataConversionTask();
            dataConversionTask.Success += DataConversionTask_Success;
            dataConversionTask.Failure += DataConversionTask_Failure;
        }

        private void DataConversionTask_Success(object sender, IEnumerable<DrawableDataPoint> result)
        {
            loadingImage.Visible = false;
            chartDataSource = result.ToList();
            var scatterPlot = new ScatterPlot(chartDataSource, chart);
            scatterPlot.Draw();

            ChartArea area = chart.ChartAreas[0];

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;

            grpAlgorithmSettings.Enabled = true;
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
            if (chartDataSource != null)
            {
                int k = Convert.ToInt32(numericUpDown1.Value);
                var kmeans = new KMeans(this.dataSet, k, distanceMetric);
                var result = kmeans.Calculate();
                foreach (var dataPoint in chartDataSource)
                {
                    Cluster cluster = result.FindCluster(dataPoint.Origin);
                    if (cluster != null)
                    {
                        dataPoint.Group = string.Format("Cluster {0}", cluster.Id);
                    }
                }
                chartDataSource = chartDataSource.OrderBy(item => item.Group).ToList();
                var scatterPlot = new ScatterPlot(chartDataSource, chart);
                scatterPlot.Draw();
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {
            Random ran = new Random();
            dataPointDetail1.GenerateDetails(dataSet[ran.Next(0, 150)], dataSet[ran.Next(0, 150)]);
        }
    }
}

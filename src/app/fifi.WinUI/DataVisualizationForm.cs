using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using fifi.Core;
using fifi.Core.Algorithms;
using fifi.WinUI.Properties;

namespace fifi.WinUI
{
    public partial class DataVisualizationForm : BaseForm
    {
        private readonly IdentifiableDataPointCollection dataSet;
        private readonly DataConversionTask dataConversionTask;
        private readonly IDistanceMetric distanceMetric;

        public DataVisualizationForm()
        {
            InitializeComponent();
            this.loadingImage.Location = this.chart.Location;
            this.loadingImage.Size = this.chart.Size;

            // Loading chart stolen from https://dribbble.com/shots/1420523-Loading-Chart
            this.loadingImage.Image = Resources.Loading;
        }

        public DataVisualizationForm(IdentifiableDataPointCollection dataSet, IDistanceMetric distanceMetric) : this()
        {
            this.dataSet = dataSet;
            this.distanceMetric = distanceMetric;

            dataConversionTask = new DataConversionTask();
            dataConversionTask.Success += DataConversionTask_Success;
            dataConversionTask.Failure += DataConversionTask_Failure;
        }

        private void DataVisualizationForm_Load(object sender, System.EventArgs e)
        {
        }

        private void DataConversionTask_Success(object sender, IEnumerable<DrawableDataPoint> result)
        {
            loadingImage.Visible = false;
            var scatterPlot = new ScatterPlot(result.ToList(), chart);
            scatterPlot.Draw();

            ChartArea area = chart.ChartAreas[0];

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;
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
    }
}

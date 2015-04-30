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
    public partial class OutlierDetectForm : Form
    {
        private DistanceMatrix distanceMatrix;

        public OutlierDetectForm()
        {
            InitializeComponent();

            IConfiguration configuration =
               (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDynamicDataImporter(reader, configuration);
            var dataCollection = importer.Run();

            var distanceMetric = new EuclideanMetric();
            distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
        }

        public OutlierDetectForm(DistanceMatrix distanceMatrix, int k, int limit)
        {
            this.distanceMatrix = distanceMatrix;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = GenerateSortedLocalOutlierList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GenerateSortedLocalOutlierList();
        }

        private List<LocalOutlierFactorPoint> GenerateSortedLocalOutlierList()
        {
            var localOutlierFactor = new LocalOutlierFactor(distanceMatrix, kValue);
            localOutlierFactor.Run();

            var localOutlierList = localOutlierFactor.ResultList;

            return localOutlierList.OrderByDescending(point => point.LocalOutlierFactor).Take(limit).ToList();
        }

        private int kValue { get { return (int)numericUpDown1.Value; } }
        private int limit { get { return (int)numericUpDown2.Value; } }
    }
}
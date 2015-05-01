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
        IdentifiableDataPointCollection identifiableDataPointCollection;
        private DistanceMatrix distanceMatrix;
        private List<LocalOutlierFactorItem> itemList;
        private Dictionary<int, LocalOutlierFactorItem> idLookUptable;
        private int kValue { get { return (int)numericUpDown1.Value; } }
        private int limit { get { return (int)numericUpDown2.Value; } }

        public OutlierDetectForm()
        {
            InitializeComponent();

            IConfiguration configuration =
               (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            var reader = new StreamReader("UserData.csv");
            var importer = new CsvDynamicDataImporter(reader, configuration);
            this.identifiableDataPointCollection = importer.Run();

            var distanceMetric = new EuclideanMetric();
            distanceMatrix = new DistanceMatrix(identifiableDataPointCollection, distanceMetric);

            CreateItemList();
            idLookUptable = itemList.ToDictionary(item => item.Id);
        }

        public OutlierDetectForm(IdentifiableDataPointCollection identifiableDataPointCollection, DistanceMatrix distanceMatrix, int k, int limit)
        {
            this.identifiableDataPointCollection = identifiableDataPointCollection;
            this.distanceMatrix = distanceMatrix;
            CreateItemList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = itemList.OrderByDescending(point => point.LocalOutlierFactor).Take(limit).ToList();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var liveItemList = (List<LocalOutlierFactorItem>)dataGridView1.DataSource;
                var markedItem = idLookUptable[liveItemList[e.RowIndex].Id];
                markedItem.UpdateIcon();

                dataGridView1.UpdateCellValue(e.ColumnIndex, e.RowIndex);
            }
            if (e.ColumnIndex > 0)
            {
                var liveItemList = (List<LocalOutlierFactorItem>)dataGridView1.DataSource;
                var markedItem = idLookUptable[liveItemList[e.RowIndex].Id];

                //Todo send this id to someone.

                dataPointDetail1.GenerateDetails(new IdentifiableDataPoint(e.ColumnIndex, 5), new IdentifiableDataPoint(e.ColumnIndex, 5));
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            UpdateLocalOutlierItemList();
            dataGridView1.DataSource = itemList.OrderByDescending(point => point.LocalOutlierFactor).Take(limit).ToList(); ;
        }


        private void CreateItemList()
        {
            this.itemList = new List<LocalOutlierFactorItem>();
            var localOutlierPointList = CreateLocalOutlierPointList();

            foreach (var item in localOutlierPointList)
            {
                itemList.Add(new LocalOutlierFactorItem(item.ID, item.LocalOutlierFactor));
            }
        }


        private List<LocalOutlierFactorPoint> CreateLocalOutlierPointList()
        {
            var localOutlierFactor = new LocalOutlierFactor(distanceMatrix, kValue);
            localOutlierFactor.Run();

            return localOutlierFactor.ResultList;
        }


        private void UpdateLocalOutlierItemList()
        {
            var localOutlierPointList = CreateLocalOutlierPointList();

            foreach (var point in localOutlierPointList)
            {
                if (idLookUptable.ContainsKey(point.ID))
                {
                    var item = idLookUptable[point.ID];
                    item.LocalOutlierFactor = point.LocalOutlierFactor;
                }
                else
                {
                    throw new Exception("ID not found");
                }
            }
        }
    }
}
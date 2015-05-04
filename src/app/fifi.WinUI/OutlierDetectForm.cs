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
        private List<LocalOutlierFactorItem> itemList;
        private Dictionary<int, LocalOutlierFactorItem> idLookUptable;
        private int kValue { get { return (int)numericUpDown1.Value; } }
        private int limit { get { return (int)numericUpDown2.Value; } }

        public OutlierDetectForm()
        {
            InitializeComponent();
        }

        public OutlierDetectForm(DistanceMatrix distanceMatrix)
        {
            InitializeComponent();
            
            this.distanceMatrix = distanceMatrix;
            CreateItemList();
            idLookUptable = itemList.ToDictionary(item => item.Id);
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

                dataPointDetail1.GenerateDetails( distanceMatrix.GetObject(markedItem.Id) as IdentifiableDataPoint, new IdentifiableDataPoint(e.ColumnIndex, 60));
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

            for (int Id = 0; Id < localOutlierPointList.Count; Id++)
            {
                itemList.Add(new LocalOutlierFactorItem(Id, localOutlierPointList[Id].LocalOutlierFactor));
                
            }
        }


        private List<LocalOutlierFactorPoint> CreateLocalOutlierPointList()
        {
            var localOutlierFactor = new LocalOutlierFactor(distanceMatrix, kValue);

            return localOutlierFactor.Run();
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet. \nSorry :(");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
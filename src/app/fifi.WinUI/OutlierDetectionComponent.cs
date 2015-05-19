using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using fifi.Core;

namespace fifi.WinUI
{
    public partial class OutlierDetectionComponent : UserControl
    {
        public event EventHandler<IdentifiableDataPoint> DataPointClick;
        private DistanceMatrix distanceMatrix;
        private List<LocalOutlierFactorItem> itemList;
        private Dictionary<int, LocalOutlierFactorItem> idLookUptable;
        private int kValue { get { return (int)numericUpDown1.Value; } }
        private int limit { get { return (int)numericUpDown2.Value; } }

        public OutlierDetectionComponent()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        public void Build(DistanceMatrix input)
        {
            dataGridView1.Visible = true;
            this.distanceMatrix = input;
            CreateItemList();
            idLookUptable = itemList.ToDictionary(item => item.Id);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = itemList.OrderByDescending(point => point.LocalOutlierFactor).Take(limit).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var liveItemList = (List<LocalOutlierFactorItem>)dataGridView1.DataSource;
            var markedItem = idLookUptable[liveItemList[e.RowIndex].Id];
            
            if (e.ColumnIndex == 0)
            {
                markedItem.UpdateIcon();
                dataGridView1.UpdateCellValue(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex > 0)
            {
                if (DataPointClick != null)
                {
                    var identifiableDataPoint = distanceMatrix.GetObject(markedItem.Id) as IdentifiableDataPoint;

                    if (identifiableDataPoint != null)
                    {
                        DataPointClick(this, identifiableDataPoint);
                    }
                }
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

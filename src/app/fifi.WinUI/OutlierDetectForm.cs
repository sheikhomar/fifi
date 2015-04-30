using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fifi.Core;

namespace fifi.WinUI
{
    public partial class OutlierDetectForm : Form
    {
        private int kValue = 5;

        public OutlierDetectForm()
        {
            InitializeComponent();
        }

        public OutlierDetectForm(DistanceMatrix distanceMatrix)
        {
            var localOutlierFactor = new LocalOutlierFactor(distanceMatrix, kValue);
            localOutlierFactor.Run();


            //var localOutliers = localOutlierFactor.ResultList;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var localOutliers = new List<LocalOutlierFactorPoint>();

            var hans = new LocalOutlierFactorPoint();
            hans.LocalOutlierFactor = 5;
            hans.ID = 0;
            localOutliers.Add(hans);
            #region LOF points
            var carl = new LocalOutlierFactorPoint();
            carl.LocalOutlierFactor = 5;
            carl.ID = 0;
            localOutliers.Add(carl);

            var peter = new LocalOutlierFactorPoint();
            peter.LocalOutlierFactor = 5;
            peter.ID = 0;
            localOutliers.Add(peter);
            #endregion

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = localOutliers;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

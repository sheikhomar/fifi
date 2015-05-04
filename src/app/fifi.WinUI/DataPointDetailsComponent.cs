using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fifi.Core;

namespace fifi.WinUI
{
    public partial class DataPointDetailsComponent : UserControl
    {
        private List<DataPointInfo> dataPointInfoList;
        private DataPointInfo dataPointInfo;

        public DataPointDetailsComponent()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        public void GenerateDetails(IdentifiableDataPoint dataPoint, DataPoint centroid)
        {
            dataGridView1.Visible = true;
            dataPointInfoList = new List<DataPointInfo>();

            lblID.Text = "ID: " + dataPoint.Id.ToString();

            dataGridView1.AutoGenerateColumns = false;

            for (int attributes = 0; attributes < dataPoint.Attributes.Count; attributes++)
            {
                dataPointInfo = new DataPointInfo();
                dataPointInfo.Field = dataPoint.Attributes[attributes];
                dataPointInfo.Value = dataPoint.Coordinates[attributes];
                dataPointInfo.Percent = PercentageCalculator(dataPoint.Coordinates[attributes], centroid.Coordinates[attributes]);
                dataPointInfo.Similarity = SimilarityCalculator(dataPointInfo.Percent);
                dataPointInfoList.Add(dataPointInfo);
            }

            dataPointInfoList.Sort(delegate(DataPointInfo item1, DataPointInfo item2)
            {
                if (item1.Percent > item2.Percent)
                    return 1;
                else if (item1.Percent < item2.Percent)
                    return -1;
                else
                    return 0;
            });

            dataGridView1.DataSource = dataPointInfoList;
        }

        private double PercentageCalculator(double dataPointAttribute, double centroidAttribute)
        {
            double percentage = 0;
            percentage = centroidAttribute - dataPointAttribute;
            if (percentage < 0)
                percentage *= (-1);
            return (1 - percentage) * 100;
        }

        private Similarity SimilarityCalculator(double percentage)
        {
            if (percentage <= 33.33)
                return Similarity.Different;
            else if (percentage <= 66.66)
                return Similarity.Similar;
            else
                return Similarity.Same;
        }
    }
}

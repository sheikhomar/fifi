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
                dataPointInfo.Value = dataPoint.OriginalValues[attributes];
                dataPointInfo.Percent = PercentageCalculator(dataPoint.Coordinates[attributes], centroid.Coordinates[attributes]);
                dataPointInfo.Similarity = SimilarityCalculator(dataPointInfo.Percent);
                dataPointInfoList.Add(dataPointInfo);
            }

            dataPointInfoList.Sort(delegate(DataPointInfo item1, DataPointInfo item2)
            {
                if (item1.Percent == 200 && item2.Percent != 200)
                    return 1;
                else if (item1.Percent != 200 && item2.Percent == 200)
                    return -1;
                else if (item1.Percent < item2.Percent)
                    return 1;
                else if (item1.Percent > item2.Percent)
                    return -1;
                else if (item1.Percent == item2.Percent)
                    if (string.Compare(item1.Value, item2.Value) > 0)
                        return 1;
                    else if (string.Compare(item1.Value, item2.Value) < 0)
                        return -1;
                    else
                        return 0;
                else
                    return 0;
            });

            dataGridView1.DataSource = dataPointInfoList;
        }

        private double PercentageCalculator(double dataPointAttribute, double centroidAttribute)
        {
            double differense = 0, result = 0;
            differense = centroidAttribute - dataPointAttribute;
            if (differense < 0)
                differense *= (-1);
            if (differense == 0)
                return 0;
            result = (differense / ((centroidAttribute + dataPointAttribute) * 0.5)) * 100;
            return result;
        }

        private Similarity SimilarityCalculator(double percentage)
        {
            if (percentage <= 66.66)
                return Similarity.Same;
            else if (percentage <= 133.33)
                return Similarity.Similar;
            else
                return Similarity.Different;
        }
    }
}

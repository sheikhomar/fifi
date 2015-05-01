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
    public partial class DataPointSourceForm : Form
    {
        private Random ran;
        private IdentifiableDataPoint testPoint, testCentroid;
        private int fun;

        public DataPointSourceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testPoint = new IdentifiableDataPoint(1, 12);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Gender", 1d);
            testPoint.AddAttribute("Income", 0.1429);
            testPoint.AddAttribute("Age", 0.16d);
            testPoint.AddAttribute("Purchase", 0.5d);
            testPoint.AddAttribute("Control", 1d);

            testCentroid = new IdentifiableDataPoint(1, 12);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Gender", 0d);
            testCentroid.AddAttribute("Income", 0.2858d);
            testCentroid.AddAttribute("Age", 0.16d);
            testCentroid.AddAttribute("Purchase", 1d);
            testCentroid.AddAttribute("Control", 0d);

            ran = new Random();
            fun = ran.Next(5, 100);
            //DataPointDetail test = new DataPointDetail();
            //this.Controls.Add(test);
            //test.GenerateDetails(testPoint, testCentroid);
            //test.Location = new Point(fun, fun);
            //test.BringToFront();
            //button1.BringToFront();
            dataPointDetail1.GenerateDetails(testPoint, testCentroid);
        }
    }
}

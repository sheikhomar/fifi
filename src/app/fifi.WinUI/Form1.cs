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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MDSCluster Cluster1 = new MDSCluster();
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, 4));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(4, 4));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(3, 3.5));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 2));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, 3.7));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.3, 4.1));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.5, 4.8));
            Cluster1.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(2.8, 3));

            MDSCluster Cluster2 = new MDSCluster();
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 1));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 1.2));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1.1, 1.2));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(1.4, 0.78));
            Cluster2.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(0.8, 0.7));

            MDSCluster Cluster3 = new MDSCluster();
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(8, 6));
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(8.6, 8));
            Cluster3.MDSDataPoints.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(9, 7.4));

            List<MDSCluster> input = new List<MDSCluster>();
            input.Add(Cluster1);
            input.Add(Cluster2);
            input.Add(Cluster3);

            ScatterPlot result = new ScatterPlot(input, chart1);
            result.Draw();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

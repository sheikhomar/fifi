namespace fifi.WinUI
{
    partial class DataVisualizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpAlgorithmSettings = new System.Windows.Forms.GroupBox();
            this.cbClusteringAlgo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDistanceAlgo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfClusters = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateClusters = new System.Windows.Forms.Button();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.dataPointDetail1 = new fifi.WinUI.DataPointDetail();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grpAlgorithmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(11, 165);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(490, 427);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // grpAlgorithmSettings
            // 
            this.grpAlgorithmSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAlgorithmSettings.Controls.Add(this.cbClusteringAlgo);
            this.grpAlgorithmSettings.Controls.Add(this.label3);
            this.grpAlgorithmSettings.Controls.Add(this.cbDistanceAlgo);
            this.grpAlgorithmSettings.Controls.Add(this.label2);
            this.grpAlgorithmSettings.Controls.Add(this.label1);
            this.grpAlgorithmSettings.Controls.Add(this.numberOfClusters);
            this.grpAlgorithmSettings.Controls.Add(this.btnGenerateClusters);
            this.grpAlgorithmSettings.Location = new System.Drawing.Point(12, 12);
            this.grpAlgorithmSettings.Name = "grpAlgorithmSettings";
            this.grpAlgorithmSettings.Size = new System.Drawing.Size(892, 148);
            this.grpAlgorithmSettings.TabIndex = 2;
            this.grpAlgorithmSettings.TabStop = false;
            this.grpAlgorithmSettings.Text = "Clustering algorithm settings";
            // 
            // cbClusteringAlgo
            // 
            this.cbClusteringAlgo.FormattingEnabled = true;
            this.cbClusteringAlgo.Items.AddRange(new object[] {
            "K-means"});
            this.cbClusteringAlgo.Location = new System.Drawing.Point(136, 53);
            this.cbClusteringAlgo.Name = "cbClusteringAlgo";
            this.cbClusteringAlgo.Size = new System.Drawing.Size(121, 21);
            this.cbClusteringAlgo.TabIndex = 7;
            this.cbClusteringAlgo.Text = "K-means";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clustering algorithm";
            // 
            // cbDistanceAlgo
            // 
            this.cbDistanceAlgo.FormattingEnabled = true;
            this.cbDistanceAlgo.Items.AddRange(new object[] {
            "Euclidian distance"});
            this.cbDistanceAlgo.Location = new System.Drawing.Point(136, 26);
            this.cbDistanceAlgo.Name = "cbDistanceAlgo";
            this.cbDistanceAlgo.Size = new System.Drawing.Size(121, 21);
            this.cbDistanceAlgo.TabIndex = 5;
            this.cbDistanceAlgo.Text = "Euclidian distance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Distance-matrix algorithm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of clusters";
            // 
            // numberOfClusters
            // 
            this.numberOfClusters.Location = new System.Drawing.Point(136, 83);
            this.numberOfClusters.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numberOfClusters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfClusters.Name = "numberOfClusters";
            this.numberOfClusters.Size = new System.Drawing.Size(47, 20);
            this.numberOfClusters.TabIndex = 2;
            this.numberOfClusters.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnGenerateClusters
            // 
            this.btnGenerateClusters.Location = new System.Drawing.Point(9, 115);
            this.btnGenerateClusters.Name = "btnGenerateClusters";
            this.btnGenerateClusters.Size = new System.Drawing.Size(112, 23);
            this.btnGenerateClusters.TabIndex = 0;
            this.btnGenerateClusters.Text = "Generate clusters";
            this.btnGenerateClusters.UseVisualStyleBackColor = true;
            this.btnGenerateClusters.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadingImage
            // 
            this.loadingImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingImage.BackColor = System.Drawing.Color.White;
            this.loadingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loadingImage.Location = new System.Drawing.Point(12, 166);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(26, 28);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            // 
            // dataPointDetail1
            // 
            this.dataPointDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPointDetail1.Location = new System.Drawing.Point(506, 166);
            this.dataPointDetail1.Name = "dataPointDetail1";
            this.dataPointDetail1.Size = new System.Drawing.Size(398, 425);
            this.dataPointDetail1.TabIndex = 3;
            // 
            // DataVisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 603);
            this.Controls.Add(this.dataPointDetail1);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.grpAlgorithmSettings);
            this.Controls.Add(this.chart);
            this.Name = "DataVisualizationForm";
            this.Text = "Display clusters";
            this.Shown += new System.EventHandler(this.DataVisualizationForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grpAlgorithmSettings.ResumeLayout(false);
            this.grpAlgorithmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox grpAlgorithmSettings;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.Button btnGenerateClusters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberOfClusters;
        private DataPointDetail dataPointDetail1;
        private System.Windows.Forms.ComboBox cbClusteringAlgo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDistanceAlgo;
        private System.Windows.Forms.Label label2;
    }
}
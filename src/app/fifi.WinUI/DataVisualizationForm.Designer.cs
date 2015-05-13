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
            this.grpAlgorithmSettings = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerateClusters = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbClusteringAlgo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDistanceAlgo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfClusters = new System.Windows.Forms.NumericUpDown();
            this.ImageLoadingScreen = new System.Windows.Forms.PictureBox();
            this.scatterPlotControl1 = new fifi.WinUI.ScatterPlotComponent();
            this.dataPointDetailsComponent1 = new fifi.WinUI.DataPointDetailsComponent();
            this.outlierDetectionComponent1 = new fifi.WinUI.OutlierDetectionComponent();
            this.grpAlgorithmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLoadingScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAlgorithmSettings
            // 
            this.grpAlgorithmSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAlgorithmSettings.Controls.Add(this.button1);
            this.grpAlgorithmSettings.Controls.Add(this.btnGenerateClusters);
            this.grpAlgorithmSettings.Controls.Add(this.button2);
            this.grpAlgorithmSettings.Controls.Add(this.cbClusteringAlgo);
            this.grpAlgorithmSettings.Controls.Add(this.label3);
            this.grpAlgorithmSettings.Controls.Add(this.cbDistanceAlgo);
            this.grpAlgorithmSettings.Controls.Add(this.label2);
            this.grpAlgorithmSettings.Controls.Add(this.label1);
            this.grpAlgorithmSettings.Controls.Add(this.numberOfClusters);
            this.grpAlgorithmSettings.Location = new System.Drawing.Point(16, 15);
            this.grpAlgorithmSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAlgorithmSettings.Name = "grpAlgorithmSettings";
            this.grpAlgorithmSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAlgorithmSettings.Size = new System.Drawing.Size(1299, 85);
            this.grpAlgorithmSettings.TabIndex = 2;
            this.grpAlgorithmSettings.TabStop = false;
            this.grpAlgorithmSettings.Text = "Clustering";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1016, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Commit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnGenerateClusters
            // 
            this.btnGenerateClusters.Location = new System.Drawing.Point(769, 22);
            this.btnGenerateClusters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerateClusters.Name = "btnGenerateClusters";
            this.btnGenerateClusters.Size = new System.Drawing.Size(133, 43);
            this.btnGenerateClusters.TabIndex = 0;
            this.btnGenerateClusters.Text = "Generate";
            this.btnGenerateClusters.UseVisualStyleBackColor = true;
            this.btnGenerateClusters.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1157, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbClusteringAlgo
            // 
            this.cbClusteringAlgo.FormattingEnabled = true;
            this.cbClusteringAlgo.Items.AddRange(new object[] {
            "K-means"});
            this.cbClusteringAlgo.Location = new System.Drawing.Point(432, 32);
            this.cbClusteringAlgo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbClusteringAlgo.Name = "cbClusteringAlgo";
            this.cbClusteringAlgo.Size = new System.Drawing.Size(100, 24);
            this.cbClusteringAlgo.TabIndex = 7;
            this.cbClusteringAlgo.Text = "K-means";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clustering Method:";
            // 
            // cbDistanceAlgo
            // 
            this.cbDistanceAlgo.FormattingEnabled = true;
            this.cbDistanceAlgo.Items.AddRange(new object[] {
            "Euclidian distance"});
            this.cbDistanceAlgo.Location = new System.Drawing.Point(128, 32);
            this.cbDistanceAlgo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDistanceAlgo.Name = "cbDistanceAlgo";
            this.cbDistanceAlgo.Size = new System.Drawing.Size(160, 24);
            this.cbDistanceAlgo.TabIndex = 5;
            this.cbDistanceAlgo.Text = "Euclidian distance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Distance Metric:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of clusters:";
            // 
            // numberOfClusters
            // 
            this.numberOfClusters.Location = new System.Drawing.Point(680, 33);
            this.numberOfClusters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numberOfClusters.Size = new System.Drawing.Size(63, 22);
            this.numberOfClusters.TabIndex = 2;
            this.numberOfClusters.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ImageLoadingScreen
            // 
            this.ImageLoadingScreen.Location = new System.Drawing.Point(3, 213);
            this.ImageLoadingScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImageLoadingScreen.Name = "ImageLoadingScreen";
            this.ImageLoadingScreen.Size = new System.Drawing.Size(21, 42);
            this.ImageLoadingScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageLoadingScreen.TabIndex = 8;
            this.ImageLoadingScreen.TabStop = false;
            // 
            // scatterPlotControl1
            // 
            this.scatterPlotControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scatterPlotControl1.Location = new System.Drawing.Point(15, 106);
            this.scatterPlotControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scatterPlotControl1.Name = "scatterPlotControl1";
            this.scatterPlotControl1.Size = new System.Drawing.Size(763, 354);
            this.scatterPlotControl1.TabIndex = 5;
            // 
            // dataPointDetailsComponent1
            // 
            this.dataPointDetailsComponent1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPointDetailsComponent1.Location = new System.Drawing.Point(785, 107);
            this.dataPointDetailsComponent1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataPointDetailsComponent1.Name = "dataPointDetailsComponent1";
            this.dataPointDetailsComponent1.Size = new System.Drawing.Size(529, 642);
            this.dataPointDetailsComponent1.TabIndex = 6;
            // 
            // outlierDetectionComponent1
            // 
            this.outlierDetectionComponent1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outlierDetectionComponent1.Location = new System.Drawing.Point(15, 466);
            this.outlierDetectionComponent1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.outlierDetectionComponent1.Name = "outlierDetectionComponent1";
            this.outlierDetectionComponent1.Size = new System.Drawing.Size(763, 282);
            this.outlierDetectionComponent1.TabIndex = 7;
            // 
            // DataVisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 763);
            this.Controls.Add(this.ImageLoadingScreen);
            this.Controls.Add(this.dataPointDetailsComponent1);
            this.Controls.Add(this.scatterPlotControl1);
            this.Controls.Add(this.grpAlgorithmSettings);
            this.Controls.Add(this.outlierDetectionComponent1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1343, 800);
            this.Name = "DataVisualizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display clusters";
            this.Shown += new System.EventHandler(this.DataVisualizationForm_Shown);
            this.grpAlgorithmSettings.ResumeLayout(false);
            this.grpAlgorithmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageLoadingScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAlgorithmSettings;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.Button btnGenerateClusters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberOfClusters;
        private System.Windows.Forms.ComboBox cbClusteringAlgo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDistanceAlgo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ScatterPlotComponent scatterPlotControl1;
        private DataPointDetailsComponent dataPointDetailsComponent1;
        private OutlierDetectionComponent outlierDetectionComponent1;
        private System.Windows.Forms.PictureBox ImageLoadingScreen;
    }
}
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
            this.cbClusteringAlgo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDistanceAlgo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfClusters = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateClusters = new System.Windows.Forms.Button();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            this.dataPointDetail1 = new fifi.WinUI.DataPointDetail();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.scatterPlotControl1 = new fifi.WinUI.ScatterPlotControl();
            this.grpAlgorithmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.grpAlgorithmSettings.Location = new System.Drawing.Point(16, 15);
            this.grpAlgorithmSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAlgorithmSettings.Name = "grpAlgorithmSettings";
            this.grpAlgorithmSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAlgorithmSettings.Size = new System.Drawing.Size(652, 182);
            this.grpAlgorithmSettings.TabIndex = 2;
            this.grpAlgorithmSettings.TabStop = false;
            this.grpAlgorithmSettings.Text = "Clustering algorithm settings";
            // 
            // cbClusteringAlgo
            // 
            this.cbClusteringAlgo.FormattingEnabled = true;
            this.cbClusteringAlgo.Items.AddRange(new object[] {
            "K-means"});
            this.cbClusteringAlgo.Location = new System.Drawing.Point(181, 65);
            this.cbClusteringAlgo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbClusteringAlgo.Name = "cbClusteringAlgo";
            this.cbClusteringAlgo.Size = new System.Drawing.Size(160, 24);
            this.cbClusteringAlgo.TabIndex = 7;
            this.cbClusteringAlgo.Text = "K-means";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clustering algorithm";
            // 
            // cbDistanceAlgo
            // 
            this.cbDistanceAlgo.FormattingEnabled = true;
            this.cbDistanceAlgo.Items.AddRange(new object[] {
            "Euclidian distance"});
            this.cbDistanceAlgo.Location = new System.Drawing.Point(181, 32);
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
            this.label2.Size = new System.Drawing.Size(167, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Distance-matrix algorithm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of clusters";
            // 
            // numberOfClusters
            // 
            this.numberOfClusters.Location = new System.Drawing.Point(181, 102);
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
            // btnGenerateClusters
            // 
            this.btnGenerateClusters.Location = new System.Drawing.Point(12, 142);
            this.btnGenerateClusters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerateClusters.Name = "btnGenerateClusters";
            this.btnGenerateClusters.Size = new System.Drawing.Size(149, 28);
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
            this.loadingImage.Location = new System.Drawing.Point(16, 204);
            this.loadingImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(35, 34);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            // 
            // dataPointDetail1
            // 
            this.dataPointDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPointDetail1.Location = new System.Drawing.Point(675, 204);
            this.dataPointDetail1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataPointDetail1.Name = "dataPointDetail1";
            this.dataPointDetail1.Size = new System.Drawing.Size(531, 523);
            this.dataPointDetail1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(677, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(528, 181);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aditional actions";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 64);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Detect Outliers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // scatterPlotControl1
            // 
            this.scatterPlotControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scatterPlotControl1.Location = new System.Drawing.Point(15, 203);
            this.scatterPlotControl1.Name = "scatterPlotControl1";
            this.scatterPlotControl1.Size = new System.Drawing.Size(653, 526);
            this.scatterPlotControl1.TabIndex = 5;
            // 
            // DataVisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 742);
            this.Controls.Add(this.scatterPlotControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataPointDetail1);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.grpAlgorithmSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DataVisualizationForm";
            this.Text = "Display clusters";
            this.Shown += new System.EventHandler(this.DataVisualizationForm_Shown);
            this.grpAlgorithmSettings.ResumeLayout(false);
            this.grpAlgorithmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ScatterPlotControl scatterPlotControl1;
    }
}
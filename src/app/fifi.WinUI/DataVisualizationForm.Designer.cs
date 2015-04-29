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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateClusters = new System.Windows.Forms.Button();
            this.loadingImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grpAlgorithmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.chart.Location = new System.Drawing.Point(11, 85);
            this.chart.Margin = new System.Windows.Forms.Padding(2);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(893, 507);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // grpAlgorithmSettings
            // 
            this.grpAlgorithmSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAlgorithmSettings.Controls.Add(this.label1);
            this.grpAlgorithmSettings.Controls.Add(this.numericUpDown1);
            this.grpAlgorithmSettings.Controls.Add(this.btnGenerateClusters);
            this.grpAlgorithmSettings.Location = new System.Drawing.Point(12, 12);
            this.grpAlgorithmSettings.Name = "grpAlgorithmSettings";
            this.grpAlgorithmSettings.Size = new System.Drawing.Size(892, 68);
            this.grpAlgorithmSettings.TabIndex = 2;
            this.grpAlgorithmSettings.TabStop = false;
            this.grpAlgorithmSettings.Text = "Clustering algorithm settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "k-value";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(67, 31);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnGenerateClusters
            // 
            this.btnGenerateClusters.Location = new System.Drawing.Point(120, 28);
            this.btnGenerateClusters.Name = "btnGenerateClusters";
            this.btnGenerateClusters.Size = new System.Drawing.Size(112, 23);
            this.btnGenerateClusters.TabIndex = 0;
            this.btnGenerateClusters.Text = "k-means";
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
            this.loadingImage.Location = new System.Drawing.Point(12, 86);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(26, 28);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            // 
            // DataVisualizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 603);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.grpAlgorithmSettings);
            this.Controls.Add(this.chart);
            this.Name = "DataVisualizationForm";
            this.Text = "VisualizeForm";
            this.Load += new System.EventHandler(this.DataVisualizationForm_Load);
            this.Shown += new System.EventHandler(this.DataVisualizationForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grpAlgorithmSettings.ResumeLayout(false);
            this.grpAlgorithmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox grpAlgorithmSettings;
        private System.Windows.Forms.PictureBox loadingImage;
        private System.Windows.Forms.Button btnGenerateClusters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
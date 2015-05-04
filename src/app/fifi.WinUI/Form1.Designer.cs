namespace fifi.WinUI
{
    partial class Form1
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
            this.scatterPlotControl1 = new fifi.WinUI.ScatterPlotControl();
            this.SuspendLayout();
            // 
            // scatterPlotControl1
            // 
            this.scatterPlotControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scatterPlotControl1.Location = new System.Drawing.Point(0, 0);
            this.scatterPlotControl1.Name = "scatterPlotControl1";
            this.scatterPlotControl1.Size = new System.Drawing.Size(880, 578);
            this.scatterPlotControl1.TabIndex = 0;
            this.scatterPlotControl1.DataPointClick += new System.EventHandler<fifi.Core.DrawableDataPoint>(this.scatterPlotControl1_DataPointClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 578);
            this.Controls.Add(this.scatterPlotControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ScatterPlotControl scatterPlotControl1;

    }
}


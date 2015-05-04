namespace fifi.WinUI
{
    partial class DataPointDetailsComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ColSimilarity = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(0, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSimilarity,
            this.ColField,
            this.ColValue,
            this.ColPercent});
            this.dataGridView1.Location = new System.Drawing.Point(3, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(391, 218);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Details";
            // 
            // ColSimilarity
            // 
            this.ColSimilarity.DataPropertyName = "Color";
            this.ColSimilarity.HeaderText = "Similarity";
            this.ColSimilarity.Image = global::fifi.WinUI.Properties.Resources.CircleBlue;
            this.ColSimilarity.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColSimilarity.Name = "ColSimilarity";
            this.ColSimilarity.ReadOnly = true;
            this.ColSimilarity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSimilarity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColSimilarity.Width = 75;
            // 
            // ColField
            // 
            this.ColField.DataPropertyName = "Field";
            this.ColField.HeaderText = "Field";
            this.ColField.Name = "ColField";
            this.ColField.ReadOnly = true;
            this.ColField.Width = 75;
            // 
            // ColValue
            // 
            this.ColValue.DataPropertyName = "Value";
            this.ColValue.HeaderText = "Value";
            this.ColValue.Name = "ColValue";
            this.ColValue.ReadOnly = true;
            this.ColValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColValue.Width = 75;
            // 
            // ColPercent
            // 
            this.ColPercent.DataPropertyName = "FormatedPercent";
            this.ColPercent.HeaderText = "% similar with centroid";
            this.ColPercent.Name = "ColPercent";
            this.ColPercent.ReadOnly = true;
            this.ColPercent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColPercent.Width = 140;
            // 
            // DataPointDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "DataPointDetail";
            this.Size = new System.Drawing.Size(397, 257);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn ColSimilarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPercent;

    }
}

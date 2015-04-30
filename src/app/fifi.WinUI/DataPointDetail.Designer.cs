namespace fifi.WinUI
{
    partial class DataPointDetail
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
            this.ColSimilarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "lblID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSimilarity,
            this.ColField,
            this.ColValue,
            this.ColPercent});
            this.dataGridView1.Location = new System.Drawing.Point(3, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(303, 132);
            this.dataGridView1.TabIndex = 3;
            // 
            // ColSimilarity
            // 
            this.ColSimilarity.DataPropertyName = "Similarity";
            this.ColSimilarity.HeaderText = "Similarity";
            this.ColSimilarity.Name = "ColSimilarity";
            this.ColSimilarity.ReadOnly = true;
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
            this.ColValue.Width = 75;
            // 
            // ColPercent
            // 
            this.ColPercent.DataPropertyName = "Percent";
            this.ColPercent.HeaderText = "Percentage";
            this.ColPercent.Name = "ColPercent";
            this.ColPercent.ReadOnly = true;
            this.ColPercent.Width = 75;
            // 
            // DataPointDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblID);
            this.Name = "DataPointDetail";
            this.Size = new System.Drawing.Size(419, 296);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSimilarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColField;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPercent;

    }
}

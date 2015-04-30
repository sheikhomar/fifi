namespace fifi.WinUI
{
    partial class OutlierDetectForm
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
            this.comlumnLocalOutlierFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIcon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comlumnLocalOutlierFactor
            // 
            this.comlumnLocalOutlierFactor.DataPropertyName = "LocalOutlierFactor";
            this.comlumnLocalOutlierFactor.HeaderText = "Local Outlier Factor";
            this.comlumnLocalOutlierFactor.Name = "comlumnLocalOutlierFactor";
            // 
            // columnProfile
            // 
            this.columnProfile.DataPropertyName = "ID";
            this.columnProfile.HeaderText = "Profile";
            this.columnProfile.Name = "columnProfile";
            // 
            // columnIcon
            // 
            this.columnIcon.HeaderText = "Icon";
            this.columnIcon.Name = "columnIcon";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnIcon,
            this.columnProfile,
            this.comlumnLocalOutlierFactor});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(354, 152);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OutlierDetectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 417);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OutlierDetectForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn comlumnLocalOutlierFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProfile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnIcon;
        private System.Windows.Forms.DataGridView dataGridView1;


    }
}
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using fifi.Core;
using fifi.Data;
using fifi.Data.Configuration.Import;

namespace fifi.WinUI
{
    public partial class ImportDataForm : BaseForm
    {
        private class ImportOptions
        {
            public string Path { get; set; }
            public string FieldDelimiter { get; set; }
            public char ValueDelimiter { get; set; }
            public bool RemoveWhiteSpace { get; set; }
            public IConfiguration Configuration { get; set; }
        }

        public ImportDataForm()
        {
            InitializeComponent();
        }

        public IdentifiableDataPointCollection Result { get; private set; }

        #region Event Handlers
        private void LoadDataForm_Load(object sender, EventArgs e)
        {
            txtSelectedFile.Text = Path.Combine(Environment.CurrentDirectory, "UserData.csv");
            btnBrowse.Select();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ToggleUserInputControls(false);

            ImportOptions importOptions = GetImportOptions();

            var task = Task.Factory.StartNew<IdentifiableDataPointCollection>(DataImportTask_Run, importOptions);
            task.ContinueWith(DataImportTask_Complete, FormTaskScheduler);
            task.ContinueWith(DataImportTask_Faulted, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, FormTaskScheduler);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {CheckFileExists = true};
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                txtSelectedFile.Text = dialog.FileName;
        }

        private IdentifiableDataPointCollection DataImportTask_Run(object input)
        {
            ImportOptions options = input as ImportOptions;

            var reader = new StreamReader(options.Path);
            var importer = new CsvDynamicDataImporter(reader, options.Configuration)
            {
                FieldDelimiter = options.FieldDelimiter,
                ValueDelimiter = options.ValueDelimiter,
                RemoveWhiteSpace = options.RemoveWhiteSpace
            };
            return importer.Run();
        }

        private void DataImportTask_Complete(Task<IdentifiableDataPointCollection> task)
        {
            ToggleUserInputControls(true);

            Result = task.Result;
            DataVisualizationForm form = new DataVisualizationForm(Result);
            form.Show();
        }

        private void DataImportTask_Faulted(Task<IdentifiableDataPointCollection> task)
        {
            ToggleUserInputControls(true);

            if (task.Exception != null)
            {
                StringBuilder temp = new StringBuilder();
                temp.AppendLine("Data import failed with following errors:");
                foreach (var exp in task.Exception.InnerExceptions)
                    temp.Append(" - ").AppendLine(exp.Message);

                MessageBox.Show(temp.ToString(), "Data import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private ImportOptions GetImportOptions()
        {
            IConfiguration configuration =
                (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");

            return new ImportOptions
            {
                Configuration = configuration,
                Path = txtSelectedFile.Text,
                FieldDelimiter = ",",
                ValueDelimiter = ',',
                RemoveWhiteSpace = chkRemoveWhitespace.Checked
            };
        }

        private bool ValidateUserInput()
        {
            return true;
        }

        private void ToggleUserInputControls(bool enabled)
        {
            groupBox1.Enabled = enabled;
            btnImport.Enabled = enabled;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

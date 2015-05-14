using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using fifi.Core;
using fifi.Data.Configuration.Import;
using System.Threading;

namespace fifi.Data
{
    public class CsvDynamicDataImporter : IDataImporter
    {
        private TextReader reader;
        private IConfiguration config;
        private string fieldDelimiter;
        private CultureInfo cultureFormat;

        public CsvDynamicDataImporter(TextReader reader, IConfiguration config)
        {
            this.reader = reader;
            this.config = config;

            // Assign default values
            this.RemoveWhiteSpace = true;
            this.FieldDelimiter = ",";
            this.ValueDelimiter = ',';
        }

        public string FieldDelimiter
        {
            get { return fieldDelimiter; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw  new ArgumentException("Field delimiter cannot be null or whitespace.");
                fieldDelimiter = value;
            }
        }

        public char ValueDelimiter { get; set; }

        public bool RemoveWhiteSpace { get; set; }

        public IdentifiableDataPointCollection Run()
        {
            var dataSet = new IdentifiableDataPointCollection();

            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = FieldDelimiter;

            var idCounter = 0;
            while (csv.Read())
            {
                IdentifiableDataPoint dataPoint = ParseRow(csv, idCounter++);
                dataSet.AddItem(dataPoint);
            }

            return dataSet;
        }

        private IdentifiableDataPoint ParseRow(CsvReader csv, int id)
        {
            IdentifiableDataPoint dataItem = new IdentifiableDataPoint(id, config.DimensionCount);
            foreach (IField field in config.Fields)
            {
                switch (field.Type)
                {
                    case FieldType.Scalar:
                        ParseScalarField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleBinaryFields:
                        ParseMultipleBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleChoiceMultipleBinaryFields:
                        ParseMultipleChoiceBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.Numeric:
                        ParseNumericField(field, csv, dataItem);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown field type.");
                }
            }

            return dataItem;
        }

        private void ParseNumericField(IField field, CsvReader csv, IdentifiableDataPoint dataItem)
        {
            double valueInDataField;
            string val = csv.GetField(field.Index);
            cultureFormat = new CultureInfo("en");

            if (!double.TryParse(val, NumberStyles.Any, cultureFormat, out valueInDataField))
                throw new InvalidNumericValueException(csv.Row, field.Index);

            string originalValue = valueInDataField.ToString();
            double difference = field.MaxValue - field.MinValue;
            double normalizedValue = (valueInDataField - field.MinValue) / difference;
            double finalValue = normalizedValue*field.Weight;
            dataItem.AddAttribute(field.Category, finalValue, originalValue);
        }

        private void ParseMultipleChoiceBinaryField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            if (RemoveWhiteSpace)
                label = label.Trim();

            string[] array = label.Split(ValueDelimiter).Select(l => l.Trim()).ToArray();

            foreach (IFieldValue possibleFieldValue in field.Values)
            {
                double value = 0;
                string originalValue = "No";
                if (array.Contains(possibleFieldValue.Name))
                {
                    value = field.Weight;
                    originalValue = "Yes";
                }

                string name = String.Format("{0}: {1}", field.Category, possibleFieldValue.Name);
                profile.AddAttribute(name, value, originalValue);
            }
        }

        private void ParseMultipleBinaryField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            if (RemoveWhiteSpace)
                label = label.Trim();

            foreach (IFieldValue possibleFieldValue in field.Values)
            {
                double value = 0;
                string originalValue = "No";
                if (possibleFieldValue.Name.Equals(label))
                {
                    value = field.Weight;
                    originalValue = "Yes";
                }

                string name = String.Format("{0}: {1}", field.Category, possibleFieldValue.Name);
                profile.AddAttribute(name, value, originalValue);
            }
        }

        private void ParseScalarField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            double? translatedField = field.Values.GetDoubleValueFor(label);
            if (!translatedField.HasValue)
                throw new InvalidFieldValueException(csv.Row, field.Index);

            double value = translatedField.Value*field.Weight;
            profile.AddAttribute(field.Category, value, label);
        }
    }
}
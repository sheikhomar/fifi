using System;
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
                    case FieldType.BinaryValue:
                        ParseBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleBinaryFields:
                        ParseMultipleBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleChoiceMultipleBinaryFields:
                        ParseMultipleChoiceBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.NumericField:
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
            double valueInDataField = csv.GetField<double>(field.Index);
            double difference = field.MaxValue - field.MinValue;
            double normalizedValue = (valueInDataField - field.MinValue) / difference;
            dataItem.AddAttribute(field.Category, normalizedValue);
        }


        private void ParseMultipleChoiceBinaryField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            if (RemoveWhiteSpace)
                label = label.Trim();

            string[] array = label.Split(ValueDelimiter).Select(l => l.Trim()).ToArray();

            foreach (IFieldValue possibleFieldValue in field.Values)
            {
                if (array.Contains(possibleFieldValue.Name))
                {
                    profile.AddAttribute(possibleFieldValue.Name, 1);
                }
                else
                {
                    profile.AddAttribute(possibleFieldValue.Name, 0);
                }
            }
        }

        private void ParseMultipleBinaryField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            if (RemoveWhiteSpace)
                label = label.Trim();

            foreach (IFieldValue possibleFieldValue in field.Values)
            {
                if (possibleFieldValue.Name.Equals(label))
                {
                    profile.AddAttribute(possibleFieldValue.Name, 1);
                }
                else
                {
                    profile.AddAttribute(possibleFieldValue.Name, 0);    
                }
            }
        }

        private void ParseBinaryField(IField field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string label = csv.GetField<string>(field.Index);
            double? translatedField = field.Values.GetDoubleValueFor(label);

            if (translatedField.HasValue)
            {
                profile.AddAttribute(field.Category, translatedField.Value);
            }
            else
            {
                var msg = string.Format("Data contains invalid value at row {0} field index {1}.", csv.Row, field.Index);
                throw new InvalidDataException(msg);
            }
        }
    }
}
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using CsvHelper;
using fifi.Core;
using fifi.Data.Configuration.Import;

namespace fifi.Data
{
    public class CsvDynamicDataImporter : IProfileImporter
    {
        private TextReader reader;
        private ConfigurationSectionHandler config;
        private string fieldDelimiter;
        private string valueDelimiter;

        public CsvDynamicDataImporter(TextReader reader, 
            string fieldDelimiter = ",", string valueDelimiter = ",", bool removeWhitespace = true)
        {
            this.reader = reader;
            this.config = (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
            this.FieldDelimiter = fieldDelimiter;
            this.ValueDelimiter = valueDelimiter;
            this.RemoveWhiteSpace = removeWhitespace;
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

        public string ValueDelimiter
        {
            get { return valueDelimiter; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Value delimiter cannot be null or whitespace.");
                valueDelimiter = value;
            }
        }

        public bool RemoveWhiteSpace { get; set; }

        public IdentifiableDataPointCollection Run()
        {
            var dataSet = new IdentifiableDataPointCollection();

            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = FieldDelimiter;

            var idCounter = 0;
            while (csv.Read())
            {
                IdentifiableDataPoint dataPoint = ParseRowIntoDataPoint(csv, idCounter++);
                dataSet.AddItem(dataPoint);
            }

            return dataSet;
        }

        private IdentifiableDataPoint ParseRowIntoDataPoint(CsvReader csv, int id)
        {
            IdentifiableDataPoint dataItem = new IdentifiableDataPoint(id, config.DimensionCount);
            foreach (Field field in config.Fields)
            {
                switch (field.Type)
                {
                    case FieldType.BinaryValue:
                        LoadBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleBinaryFields:
                        LoadMultipleBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.MultipleChoiceMultipleBinaryFields:
                        LoadMultipleChoiceBinaryField(field, csv, dataItem);
                        break;
                    case FieldType.NumericField:
                        LoadNumericField(field, csv, dataItem);
                        break;
                    default:
                        throw new InvalidOperationException("New unexpected field type.");
                }
            }

            return dataItem;
        }

        private void LoadNumericField(Field field, CsvReader csv, IdentifiableDataPoint dataItem)
        {
            double valueInDataField = csv.GetField<double>(field.Index);
            double difference = field.MaxValue - field.MinValue;
            double normalizedValue = (valueInDataField - field.MinValue) / difference;
            dataItem.AddAttribute(field.Category, normalizedValue);
        }


        private void LoadMultipleChoiceBinaryField(Field field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string valueInDataField = csv.GetField<string>(field.Index);
            string[] array = valueInDataField.Replace(", ", ",").Split(',');

            foreach (FieldValue possibleFieldValue in field.Values)
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

        private void LoadMultipleBinaryField(Field field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string valueInDataField = csv.GetField<string>(field.Index);

            foreach (FieldValue possibleFieldValue in field.Values)
            {
                if (possibleFieldValue.Name.Equals(valueInDataField))
                {
                    profile.AddAttribute(possibleFieldValue.Name, 1);
                }
                else
                {
                    profile.AddAttribute(possibleFieldValue.Name, 0);    
                }
            }
        }

        private void LoadBinaryField(Field field, CsvReader csv, IdentifiableDataPoint profile)
        {
            string stringValue = csv.GetField<string>(field.Index);
            double? translatedField = field.Values.GetAssignedValue(stringValue);

            if (translatedField.HasValue)
            {
                profile.AddAttribute(field.Category, translatedField.Value);
            }
            else
            {
                throw new InvalidDataException("Data contains invalid field value.");
            }
        }
    }
}
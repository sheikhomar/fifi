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

        public CsvDynamicDataImporter(TextReader reader)
        {
            this.reader = reader;
            this.config = (ConfigurationSectionHandler)ConfigurationManager.GetSection("csvDataImport");
        }

        public IdentifiableDataPointCollection Run()
        {
            var dataSet = new IdentifiableDataPointCollection();

            var csv = new CsvReader(reader);
            csv.Configuration.Delimiter = ",";

            var idCounter = 0;
            while (csv.Read())
            {
                IdentifiableDataPoint profile = new IdentifiableDataPoint(idCounter++, 60);
                
                ReadLine(csv, profile);

                dataSet.AddItem(profile);
            }

            return dataSet;


        }

        private void ReadLine(CsvReader csv, IdentifiableDataPoint profile)
        {
            foreach (Field field in this.config.Fields)
            {
                Console.WriteLine("Field index {0} and type: {1}", field.Index, field.Type);

                if (field.Type.Equals("BinaryValue"))
                {
                    LoadBinaryField(field, csv, profile);
                }
                else if (field.Type.Equals("MultipleBinaryFields"))
                {
                    LoadMultipleBinaryField(field, csv, profile);
                }
                else if (field.Type.Equals("MultipleChoiceMultipleBinaryFields"))
                {
                    LoadMultipleChoiceBinaryField(field, csv, profile);
                } 

                

                Console.WriteLine("Test ");
            }


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
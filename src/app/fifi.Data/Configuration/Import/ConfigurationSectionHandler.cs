using System.Configuration;
using System.IO;

namespace fifi.Data.Configuration.Import
{
    public class ConfigurationSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("fields")]
        [ConfigurationCollection(typeof(FieldCollection),
           AddItemName = "add")]
        public FieldCollection Fields
        {
            get { return (FieldCollection)this["fields"]; }
        }

        public int DimensionCount
        {
            get
            {
                int sum = 0;

                foreach (Field field in Fields)
                {
                    switch (field.Type)
                    {
                        case FieldType.BinaryValue:
                        case FieldType.NumericField:
                            sum++;
                            break;
                        case FieldType.MultipleBinaryFields:
                        case FieldType.MultipleChoiceMultipleBinaryFields:
                            sum += field.Values.Count;
                            break;
                        default:
                            throw new InvalidDataException("Unknown field type detected. Don't know what to do.");
                    }
                }

                return sum;
            }
        }
    }
}

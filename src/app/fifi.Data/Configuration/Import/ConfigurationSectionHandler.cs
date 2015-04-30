using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace fifi.Data.Configuration.Import
{
    public class ConfigurationSectionHandler : ConfigurationSection, IConfiguration
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
                        case FieldType.Scalar:
                        case FieldType.Numeric:
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

        #region IConfiguration Implementation

        int IConfiguration.DimensionCount
        {
            get { return DimensionCount; }
        }

        IFieldCollection IConfiguration.Fields
        {
            get { return Fields; }
        }

        #endregion
    }
}

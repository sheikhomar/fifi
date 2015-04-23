using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class Field : ConfigurationElement
    {
        const string AttributeIndex = "index";
        const string AttributeType = "type";
        const string AttributeCategory = "category";
        const string AttributeMinValue = "minValue";
        const string AttributeMaxValue = "maxValue";

        [ConfigurationProperty(AttributeIndex, IsRequired = true)]
        public int Index
        {
            get { return (int)this[AttributeIndex]; }
            set { this[AttributeIndex] = value; }
        }

        [ConfigurationProperty(AttributeType, IsRequired = true)]
        public FieldType Type
        {
            get { return (FieldType)this[AttributeType]; }
            set { this[AttributeType] = value; }
        }

        [ConfigurationProperty(AttributeCategory, IsRequired = true)]
        public string Category
        {
            get { return (string)this[AttributeCategory]; }
            set { this[AttributeCategory] = value; }
        }

        [ConfigurationProperty("values")]
        [ConfigurationCollection(typeof(FieldValueCollection),
           AddItemName = "add")]
        public FieldValueCollection Values
        {
            get { return (FieldValueCollection)this["values"]; }
        }

        [ConfigurationProperty(AttributeMinValue, IsRequired = false)]
        public double MinValue
        {
            get { return (double)this[AttributeMinValue]; }
            set { this[AttributeMinValue] = value; }
        }

        [ConfigurationProperty(AttributeMaxValue, IsRequired = false)]
        public double MaxValue
        {
            get { return (double)this[AttributeMaxValue]; }
            set { this[AttributeMaxValue] = value; }
        }
    }
}

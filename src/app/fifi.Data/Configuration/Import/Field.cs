using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class Field : ConfigurationElement
    {
        const string AttributeIndex = "index";
        const string AttributeType = "type";
        const string AttributeCategory = "category";

        [ConfigurationProperty(AttributeIndex, IsRequired = true)]
        public int Index
        {
            get { return (int)this[AttributeIndex]; }
            set { this[AttributeIndex] = value; }
        }

        [ConfigurationProperty(AttributeType, IsRequired = true)]
        public string Type
        {
            get { return (string)this[AttributeType]; }
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
    }
}

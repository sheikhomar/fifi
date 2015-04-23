using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class FieldValue : ConfigurationElement
    {
        const string AttributeName = "name";
        const string AttributeValue = "value";

        [ConfigurationProperty(AttributeName, IsRequired = true)]
        public string Name
        {
            get { return (string)this[AttributeName]; }
            set { this[AttributeName] = value; }
        }

        [ConfigurationProperty(AttributeValue, IsRequired = false)]
        public double Value
        {
            get { return (double)this[AttributeValue]; }
            set { this[AttributeValue] = value; }
        }
    }
}
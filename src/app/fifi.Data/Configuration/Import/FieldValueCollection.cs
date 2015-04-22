using System;
using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class FieldValueCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FieldValue();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var fieldValue = element as FieldValue;
            if (fieldValue == null)
                throw new ArgumentException("Parameter 'element' should be of type FieldValue", "element");

            return fieldValue.Name;
        }

        public double? GetAssignedValue(string stringValue)
        {
            foreach (FieldValue fv in this)
                if (fv.Name.Equals(stringValue))
                    return fv.Value;
             
            return null;
        }
    }
}
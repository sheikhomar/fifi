using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class Field : ConfigurationElement, IField
    {
        const string AttributeIndex = "index";
        const string AttributeType = "type";
        const string AttributeCategory = "category";
        const string AttributeMinValue = "minValue";
        const string AttributeMaxValue = "maxValue";
        const string AttributeWeight = "weight";
        const string AttributeValues = "values";

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

        [ConfigurationProperty(AttributeValues)]
        [ConfigurationCollection(typeof(FieldValueCollection),
           AddItemName = "add")]
        public FieldValueCollection Values
        {
            get { return (FieldValueCollection)this[AttributeValues]; }
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

        [ConfigurationProperty(AttributeWeight, IsRequired = false, DefaultValue = 1.0D)]
        public double Weight
        {
            get { return (double)this[AttributeWeight]; }
            set { this[AttributeWeight] = value; }
        }

        #region IField Implementation

        int IField.Index
        {
            get { return Index; }
        }

        FieldType IField.Type
        {
            get { return Type; }
        }

        string IField.Category
        {
            get { return Category; }
        }

        IFieldValueCollection IField.Values
        {
            get { return Values; }
        }

        double IField.MinValue
        {
            get { return MinValue; }
        }

        double IField.MaxValue
        {
            get { return MaxValue; }
        }

        double IField.Weight
        {
            get { return Weight; }
        }

        #endregion
    }
}

using fifi.Data.Configuration.Import;

namespace fifi.Tests.Data
{
    internal class MockField : IField
    {
        public int Index { get; set; }
        public FieldType Type { get; set; }
        public string Category { get; set; }
        public IFieldValueCollection Values { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}
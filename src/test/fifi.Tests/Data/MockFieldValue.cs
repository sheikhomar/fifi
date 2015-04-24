using fifi.Data.Configuration.Import;

namespace fifi.Tests.Data
{
    internal class MockFieldValue : IFieldValue
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
using fifi.Data.Configuration.Import;

namespace fifi.Tests.Data
{
    internal class MockConfiguration : IConfiguration
    {
        public int DimensionCount { get; set; }
        public IFieldCollection Fields { get; set; }
    }
}
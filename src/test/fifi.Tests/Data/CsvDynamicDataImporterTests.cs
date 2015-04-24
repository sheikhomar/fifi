using System.IO;
using fifi.Core;
using fifi.Data;
using fifi.Data.Configuration.Import;
using NUnit.Framework;

namespace fifi.Tests.Data
{
    [TestFixture]
    public class CsvDynamicDataImporterTests
    {
        private IdentifiableDataPointCollection dataSet;

        [SetUp]
        public void SetUp()
        {
            var fieldValues = new MockFieldValueCollection
            {
                new MockFieldValue {Name = "Male", Value = 0.234},
                new MockFieldValue {Name = "Female", Value = 1.134d}
            };
            var fields = new MockFieldCollection
            {
                new MockField
                {
                    Index = 1,
                    Category = "Gender",
                    Type = FieldType.BinaryValue,
                    Values = fieldValues
                }
            };
            var config = new MockConfiguration
            {
                DimensionCount = 1,
                Fields = fields
            };

            var reader = new StringReader(Resources.SampleData);
            var importer = new CsvDynamicDataImporter(reader, config);
            dataSet = importer.Run();
        }

        [Test]
        public void ShouldImportAllLines()
        {
            Assert.AreEqual(2, dataSet.Count);
        }

        [Test]
        public void ShouldParseBinaryValuesCorrectly()
        {
            Assert.AreEqual(0.234, dataSet[0][0]);
            Assert.AreEqual(1.134, dataSet[1][0]);
        }
    }
}
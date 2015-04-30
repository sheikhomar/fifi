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

        private MockField GenerateGenderField(int index)
        {
            var fieldValues2 = new MockFieldValueCollection
            {
                new MockFieldValue {Name = "Male"        , Value=0.234},
                new MockFieldValue {Name = "Female"       , Value=1.134},
            };
            return new MockField
            {
                Index = index,
                Category = "Gender",
                Type = FieldType.Scalar,
                Values = fieldValues2
            };
        }
        private MockField GenerateEmploymentStatusField(int index)
        {
            var fieldValues2 = new MockFieldValueCollection
            {
                new MockFieldValue {Name = "Study job" },
                new MockFieldValue {Name = "Full time" },
                new MockFieldValue {Name = "Unemployed" },
            };
            return new MockField
            {
                Index = index,
                Category = "Employment",
                Type = FieldType.MultipleBinaryFields,
                Values = fieldValues2
            };
        }

        [SetUp]
        public void SetUp()
        {
            var fields = new MockFieldCollection
            {
                GenerateGenderField(1),
                GenerateEmploymentStatusField(2)
            };
            var config = new MockConfiguration
            {
                DimensionCount = 4,
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
        public void ShouldParseScalarFieldsCorrectly()
        {
            Assert.AreEqual(0.234, dataSet[0]["Gender"]);
            Assert.AreEqual(1.134, dataSet[1]["Gender"]);
        }

        [Test]
        public void ShouldParseMultipleBinaryFieldsCorrectly()
        {
            Assert.AreEqual(1, dataSet[0]["Study job"]);
            Assert.AreEqual(0, dataSet[0]["Full time"]);
            Assert.AreEqual(0, dataSet[0]["Unemployed"]);
            Assert.AreEqual(0, dataSet[1]["Study job"]);
            Assert.AreEqual(1, dataSet[1]["Full time"]);
            Assert.AreEqual(0, dataSet[1]["Unemployed"]);
        }
    }
}
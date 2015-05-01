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
                Values = fieldValues2,
                Weight = 2
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
                Category = "", // Not used
                Type = FieldType.MultipleBinaryFields,
                Values = fieldValues2,
                Weight = 2.5D
            };
        }
        private MockField GenerateBookField(int index)
        {
            var fieldValues2 = new MockFieldValueCollection
            {
                new MockFieldValue {Name = "Books" },
                new MockFieldValue {Name = "Magazines" },
                new MockFieldValue {Name = "Specialist books" }
            };
            return new MockField
            {
                Index = index,
                Category = "", // Not used
                Type = FieldType.MultipleChoiceMultipleBinaryFields,
                Values = fieldValues2,
                Weight = 1.5
            };
        }
        private MockField GenerateNumericField(int index)
        {
            return new MockField
            {
                Index = index,
                Category = "Age",
                Type = FieldType.Numeric,
                MinValue = 1900,
                MaxValue = 2000,
                Weight = 4.5
            };
        }

        private IConfiguration SetupMockConfiguration()
        {
            var fields = new MockFieldCollection
            {
                GenerateGenderField(0),
                GenerateEmploymentStatusField(1),
                GenerateBookField(2),
                GenerateNumericField(3)
            };
            return new MockConfiguration
            {
                DimensionCount = 8,
                Fields = fields
            };
        }

        [SetUp]
        public void SetUp()
        {
            var config = SetupMockConfiguration();
            var reader = new StringReader(Resources.SampleData);
            var importer = new CsvDynamicDataImporter(reader, config);
            dataSet = importer.Run();
        }

        [Test]
        public void ShouldImportAllLines()
        {
            Assert.AreEqual(3, dataSet.Count);
        }

        [Test]
        public void ShouldParseScalarFieldsCorrectly()
        {
            Assert.AreEqual(0.234 * 2, dataSet[0]["Gender"]);
            Assert.AreEqual(1.134 * 2, dataSet[1]["Gender"]);
            Assert.AreEqual(1.134 * 2, dataSet[2]["Gender"]);
        }

        [Test]
        public void ShouldParseMultipleBinaryFieldsCorrectly()
        {
            Assert.AreEqual(2.5D, dataSet[0]["Study job"]);
            Assert.AreEqual(0, dataSet[0]["Full time"]);
            Assert.AreEqual(0, dataSet[0]["Unemployed"]);
            Assert.AreEqual(0, dataSet[1]["Study job"]);
            Assert.AreEqual(2.5D, dataSet[1]["Full time"]);
            Assert.AreEqual(0, dataSet[1]["Unemployed"]);
            Assert.AreEqual(2.5D, dataSet[2]["Study job"]);
            Assert.AreEqual(0, dataSet[2]["Full time"]);
            Assert.AreEqual(0, dataSet[2]["Unemployed"]);
        }

        [Test]
        public void ShouldParseMultipleChoiceMultipleBinaryFieldsCorrectly()
        {
            Assert.AreEqual(1.5D, dataSet[0]["Books"]);
            Assert.AreEqual(1.5D, dataSet[0]["Magazines"]);
            Assert.AreEqual(1.5D, dataSet[0]["Specialist books"]);
            Assert.AreEqual(0, dataSet[1]["Books"]);
            Assert.AreEqual(1.5D, dataSet[1]["Magazines"]);
            Assert.AreEqual(0, dataSet[1]["Specialist books"]);
            Assert.AreEqual(0, dataSet[2]["Books"]);
            Assert.AreEqual(0, dataSet[2]["Magazines"]);
            Assert.AreEqual(0, dataSet[2]["Specialist books"]);
        }

        [Test]
        public void ShouldParseNumericFieldsCorrectly()
        {
            Assert.AreEqual(0.75 * 4.5, dataSet[0]["Age"]);
            Assert.AreEqual(0.9 * 4.5, dataSet[1]["Age"]);
            Assert.AreEqual(4.5, dataSet[2]["Age"]);
        }
    }
}
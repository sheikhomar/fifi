using System.IO;
using fifi.Data;
using fifi.Data.Configuration.Import;
using NUnit.Framework;

namespace fifi.Tests.Data
{
    [TestFixture]
    public class CsvDynamicDataImporterWithFaultyTests
    {
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

        private IConfiguration SetupMockConfiguration()
        {
            var fields = new MockFieldCollection
            {
                GenerateGenderField(0)
            };
            return new MockConfiguration { DimensionCount = 8, Fields = fields };
        }

        [Test]
        public void ShouldThrowExceptionWhenScalarValueIsNotValid()
        {
            var config = SetupMockConfiguration();
            var data = @"
Male
Female
Invalid";
            var reader = new StringReader(data);
            var importer = new CsvDynamicDataImporter(reader, config);

            var exception = Assert.Throws<InvalidFieldValueException>(() => importer.Run());
            Assert.AreEqual(exception.LineNumber, 4);
            Assert.AreEqual(exception.Field, 0);
        }
    }
}
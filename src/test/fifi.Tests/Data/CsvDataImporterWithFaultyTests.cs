using System.IO;
using fifi.Data;
using fifi.Data.Configuration.Import;
using NUnit.Framework;
    
namespace fifi.Tests.Data
{
    [TestFixture]
    public class CsvDataImporterWithFaultyTests
    {
        private MockField GenerateGenderField(int index)
        {
            var fieldValues2 = new MockFieldValueCollection
            {
                new MockFieldValue {Name = "Male"        , Value=0.234},
                new MockFieldValue {Name = "Female"      , Value=1.134},
            };
            return new MockField
            {
                Index = index,
                Category = "Gender",
                Type = FieldType.Scalar,
                Values = fieldValues2
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
                MaxValue = 2000
            };
        }

        private IConfiguration SetupMockConfiguration()
        {
            var fields = new MockFieldCollection
            {
                GenerateGenderField(0),
                GenerateNumericField(1)
            };
            return new MockConfiguration
            {
                DimensionCount = 2,
                Fields = fields
            };
        }

        [Test]
        public void ShouldThrowExceptionWhenScalarValueIsNotValid()
        {
            var config = SetupMockConfiguration();
            var data = 
@"Gender,BirthYear
Male,1956
Female,1964
Invalid,1930";
            var reader = new StringReader(data);
            var importer = new CsvDataImporter(reader, config);

            var exception = Assert.Throws<InvalidFieldValueException>(() => importer.Run());
            Assert.AreEqual(4, exception.LineNumber);
            Assert.AreEqual(0, exception.Field);
        }

        [Test]
        public void ShouldThrowExceptionWhenScalarValueIsEmpty()
        {
            var config = SetupMockConfiguration();
            var data =
@"Gender,BirthYear
,1998
Female,1993";
            var reader = new StringReader(data);
            var importer = new CsvDataImporter(reader, config);

            var exception = Assert.Throws<InvalidFieldValueException>(() => importer.Run());
            Assert.AreEqual(2, exception.LineNumber);
            Assert.AreEqual(0, exception.Field);
        }

        [Test]
        public void ShouldThrowExceptionWhenNumericFieldContainsInvalidValue()
        {
            var config = SetupMockConfiguration();
            var data =
@"Gender,BirthYear
Female,1998a
Male,1993";
            var reader = new StringReader(data);
            var importer = new CsvDataImporter(reader, config);

            var exception = Assert.Throws<InvalidNumericValueException>(() => importer.Run());
            Assert.AreEqual(2, exception.LineNumber);
            Assert.AreEqual(1, exception.Field);
        }

        [Test]
        public void ShouldThrowExceptionWhenNumericFieldIsEmpty()
        {
            var config = SetupMockConfiguration();
            var data =
@"Gender,BirthYear
Female,1998
Male,";
            var reader = new StringReader(data);
            var importer = new CsvDataImporter(reader, config);

            var exception = Assert.Throws<InvalidNumericValueException>(() => importer.Run());
            Assert.AreEqual(3, exception.LineNumber);
            Assert.AreEqual(1, exception.Field);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using fifi.Core;
using fifi.Data;
using System.IO;

namespace fifi.Tests.Data
{
    [TestFixture]
    public class CsvProfileImporterTests
    {
        private DataCollection results;

        [SetUp]
        public void Setup()
        {
            var reader = new StringReader(Resources.SampleData);
            var importer = new CsvProfileImporter(reader);
            results = importer.Run();
        }

        [Test]
        public void ShouldImportAllLines()
        {
            //Assert.AreEqual(results.Count, 2);
        }

        [Test]
        public void ShouldParseGenderCorrectly()
        {
            //Assert.AreEqual(results[0]["Gender"].Value, 1);
            //Assert.AreEqual(results[1]["Gender"].Value, 0);
        }
    }
}

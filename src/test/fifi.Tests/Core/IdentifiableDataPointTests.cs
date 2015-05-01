using System;
using fifi.Core;
using NUnit.Framework;

namespace fifi.Tests.Core
{
    [TestFixture]
    public class IdentifiableDataPointTests
    {
        [Test]
        public void AddAttributeShouldCheckUpperBound()
        {
            var datapoint = new IdentifiableDataPoint(0, 1);
            datapoint.AddAttribute("Age", 27);

            Assert.Throws<NumberOfDimensionsExceededException>(() => datapoint.AddAttribute("Status", 1));
        }

        [Test]
        public void ShouldSaveAttributesInOrder()
        {
            var datapoint = new IdentifiableDataPoint(0, 3);
            datapoint.AddAttribute("Attr1", 27);
            datapoint.AddAttribute("Attr2", 23);
            datapoint.AddAttribute("Attr3", 24);

            Assert.AreEqual("Attr1", datapoint.Attributes[0]);
            Assert.AreEqual("Attr2", datapoint.Attributes[1]);
            Assert.AreEqual("Attr3", datapoint.Attributes[2]);
        }

        [Test]
        public void AttributesWithTheSameNameShouldBeAllowed()
        {
            var datapoint = new IdentifiableDataPoint(0, 5);
            datapoint.AddAttribute("Attr1", 41);
            datapoint.AddAttribute("Attr1", 42);

            Assert.AreEqual("Attr1", datapoint.Attributes[0]);
            Assert.AreEqual("Attr1", datapoint.Attributes[1]);
            Assert.AreEqual(41, datapoint[0]);
            Assert.AreEqual(42, datapoint[1]);
        }

        [Test]
        public void ShouldSaveIdAttribute()
        {
            var datapoint = new IdentifiableDataPoint(42, 1);
            Assert.AreEqual(42, datapoint.Id);
        }

        [Test]
        public void IndexerShouldReturnCorrectValue()
        {
            var datapoint = new IdentifiableDataPoint(0, 5);
            datapoint.AddAttribute("Attr1", 42);
            datapoint.AddAttribute("Attr2", 24);
            datapoint.AddAttribute("Attr3", 25);

            Assert.AreEqual(42, datapoint["Attr1"]);
            Assert.AreEqual(24, datapoint["Attr2"]);
            Assert.AreEqual(25, datapoint["Attr3"]);
        }

        [Test]
        public void AccessingNonExistingAttributeNameShouldThrowException()
        {
            var datapoint = new IdentifiableDataPoint(0, 5);

            var ex = Assert.Throws<ArgumentException>(() => datapoint["Attr1"].ToString());
            Assert.AreEqual("attributeName", ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("'Attr1' does not exists"));
        }
    }
}

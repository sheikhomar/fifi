using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;
using NUnit.Framework;

namespace fifi.Tests.Core
{
    [TestFixture]
    public class IdentifiableDataPointTests
    {
        [Test]
        public void AddAttributesShouldCheckBounds()
        {
            IdentifiableDataPoint _datapoint = new IdentifiableDataPoint(0, 1);

            _datapoint.AddAttribute("Hej", 27);

            Assert.Throws<NumberOfDimensionsExceededException>(() => _datapoint.AddAttribute("", 0));
        }

        [Test]
        public void AddAttributesShouldCheckBound1()
        {
            IdentifiableDataPoint _datapoint = new IdentifiableDataPoint(0, 5);

            _datapoint.AddAttribute("Hej", 27);
            _datapoint.AddAttribute("Hej", 23);
            _datapoint.AddAttribute("Hej", 24);
            _datapoint.AddAttribute("Hej", 25);
            _datapoint.AddAttribute("Hej", 27);

            Assert.Pass("Passes because no Exception was thrown.");
        }

        [Test]
        public void CopyFromMakeCopyOfAnotherDataPoint()
        {
            var dataPointA = new DataPoint(new double[]{1, 2, 3, 4});
            var dataPointB = new DataPoint(new double[]{0, 0, 0, 0});

            dataPointB.CopyFrom(dataPointA);

            Assert.AreEqual(1, dataPointB[0]);
            Assert.AreEqual(2, dataPointB[1]);
            Assert.AreEqual(3, dataPointB[2]);
            Assert.AreEqual(4, dataPointB[3]);
        }

        [Test]
        public void CopyFromThrowsExceptionIfDimensionsMissmatch()
        {
            var dataPointA = new DataPoint(new double[] { 1, 2, 3, 4, 5 });
            var dataPointB = new DataPoint(new double[] { 0, 0, 0, 0 });

            Assert.Throws<ArgumentException>(() => dataPointB.CopyFrom(dataPointA));
        }

        [Test]
        public void CopyCopiesDataPoint()
        {
            var dataPointA = new DataPoint(new double[] { 1, 2, 3, 4 });
            
            var dataPointB = dataPointA.Copy();

            Assert.AreEqual(1, dataPointB[0]);
            Assert.AreEqual(2, dataPointB[1]);
            Assert.AreEqual(3, dataPointB[2]);
            Assert.AreEqual(4, dataPointB[3]);

        }

        [Test]
        public void EqualsReturnTrueIfObjectsAreEqual()
        {
            
        }
    }
}

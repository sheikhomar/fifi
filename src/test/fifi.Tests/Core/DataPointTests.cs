using System;
using fifi.Core;
using NUnit.Framework;

namespace fifi.Tests.Core
{
    [TestFixture]
    public class DataPointTests
    {
        [Test]
        public void ConstructorShouldSaveDimensions()
        {
            var datapoint = new DataPoint(2);
            Assert.AreEqual(2, datapoint.Dimensions);
        }

        [Test]
        public void UnassignedCoordinatesShouldBeZero()
        {
            var datapoint = new DataPoint(2);

            Assert.AreEqual(0.0D, datapoint[0]);
            Assert.AreEqual(0.0D, datapoint[1]);
        }

        [Test]
        public void IndexerShouldAssignCoordinates()
        {
            var datapoint = new DataPoint(2);
            datapoint[0] = 42.3D;
            datapoint[1] = 43.4D;

            Assert.AreEqual(42.3D, datapoint.Coordinates[0]);
            Assert.AreEqual(43.4D, datapoint.Coordinates[1]);
        }

        [Test]
        public void ConstructorShouldAssignCoordinates()
        {
            var datapoint = new DataPoint(new[] {42D, 43D});

            Assert.AreEqual(42D, datapoint.Coordinates[0]);
            Assert.AreEqual(43D, datapoint.Coordinates[1]);
            Assert.AreEqual(42D, datapoint[0]);
            Assert.AreEqual(43D, datapoint[1]);
        }

        [Test]
        public void ConstructorShouldNotAllowZeroDimension()
        {
            var ex = Assert.Throws<ArgumentException>(() => new DataPoint(0));
            Assert.AreEqual("dimensions", ex.ParamName);
        }

        [Test]
        public void ConstructorShouldNotAllowNullArray()
        {
            double[] nullArray = null;
            var ex = Assert.Throws<ArgumentNullException>(() => new DataPoint(nullArray));
            Assert.AreEqual("coordinates", ex.ParamName);
        }

        [Test]
        public void ConstructorShouldNotAllowEmptyCoordinates()
        {
            double[] emptyArray = new double[0];
            var ex = Assert.Throws<ArgumentException>(() => new DataPoint(emptyArray));
            Assert.AreEqual("coordinates", ex.ParamName);
        }

        [Test]
        public void ConstructorShouldNotAllowNegativeDimension()
        {
            var ex = Assert.Throws<ArgumentException>(() => new DataPoint(-1));
            Assert.AreEqual("dimensions", ex.ParamName);
        }

        [Test]
        public void GetIndexerShouldCheckLowerBound()
        {
            var dataPoint = new DataPoint(5);

            var ex = Assert.Throws<ArgumentException>(() => dataPoint[-1].ToString());
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public void GetIndexerShouldCheckUpperBound()
        {
            var dataPoint = new DataPoint(5);

            var ex = Assert.Throws<ArgumentException>(() => dataPoint[5].ToString());
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public void SetIndexerShouldCheckLowerBound()
        {
            var dataPoint = new DataPoint(5);

            var ex = Assert.Throws<ArgumentException>(() => dataPoint[-3] = 42);
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public void SetIndexerShouldCheckUpperBound()
        {
            var dataPoint = new DataPoint(5);

            var ex = Assert.Throws<ArgumentException>(() => dataPoint[29] = 43);
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public void CopyFromMakeCopyOfAnotherDataPoint()
        {
            var dataPointA = new DataPoint(new double[] { 1, 2, 3, 4 });
            var dataPointB = new DataPoint(4);

            dataPointB.CopyFrom(dataPointA);

            Assert.AreEqual(1D, dataPointB[0]);
            Assert.AreEqual(2D, dataPointB[1]);
            Assert.AreEqual(3D, dataPointB[2]);
            Assert.AreEqual(4D, dataPointB[3]);
        }

        [Test]
        public void CopyFromThrowsExceptionIfArgumentIsNull()
        {
            var dataPointA = new DataPoint(new double[] { 1, 2, 3, 4, 5 });
            Assert.Throws<ArgumentNullException>(() => dataPointA.CopyFrom(null));
        }

        [Test]
        public void CopyFromThrowsExceptionIfDimensionsMismatches()
        {
            var dataPointA = new DataPoint(5);
            var dataPointB = new DataPoint(4);

            Assert.Throws<DimensionsMismatchExceptions>(() => dataPointB.CopyFrom(dataPointA));
        }

        [Test]
        public void CloneShouldCreateNewIdenticalDataPoint()
        {
            var dataPoint = new DataPoint(new double[] { 1, 2, 3, 4 });

            var clonedDataPoint = dataPoint.Copy();

            Assert.AreNotSame(dataPoint, clonedDataPoint);
            Assert.AreNotSame(dataPoint.Coordinates, clonedDataPoint.Coordinates);

            Assert.AreEqual(4, clonedDataPoint.Dimensions);

            Assert.AreEqual(1D, clonedDataPoint[0]);
            Assert.AreEqual(2D, clonedDataPoint[1]);
            Assert.AreEqual(3D, clonedDataPoint[2]);
            Assert.AreEqual(4D, clonedDataPoint[3]);
        }

        [Test]
        public void EqualsReturnsTrueIfObjectsAreSame()
        {
            var dataPoint = new DataPoint(2);

            Assert.IsTrue(dataPoint.Equals(dataPoint));
        }

        [Test]
        public void EqualsReturnsFalseIfDifferentDimensions()
        {
            var dataPointA = new DataPoint(2);
            var dataPointB = new DataPoint(3);

            Assert.IsFalse(dataPointA.Equals(dataPointB));
        }


        [Test]
        public void EqualsReturnsTrueIfCoordinatesAreIdentical()
        {
            var dataPointA = new DataPoint(new[] { 1D / 3D });
            var dataPointB = new DataPoint(new[] { 0.33333333D });

            Assert.IsTrue(dataPointA.Equals(dataPointB));
        }


    }

}

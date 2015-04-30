using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core;

namespace fifi.Tests.Core.Algorithms
{
    [TestFixture]
    public class EuclideanMetricTests
    {
        private EuclideanMetric metric;
        private DataPoint dataPointA;
        private DataPoint dataPointB;


        [SetUp]
        public void SetUp()
        {
            metric = new EuclideanMetric(); 
        }


        [Test]
        public void CalculateWithSameCoordinates()
        {
            var coordinates = new double[] {1,1,1,1,1};
            dataPointA = new DataPoint(coordinates);

            var result = metric.Calculate(dataPointA, dataPointA);
            Assert.AreEqual(0D, result);
        }


        [Test]
        public void CalculateWithDifferntCoordinates()
        {
            var coordinatesA = new double[] { 0, 0, 0, 0, 0 };
            dataPointA = new DataPoint(coordinatesA);
            var coordinatesB = new double[] { 1, 1, 1, 1, 1 };
            dataPointB = new DataPoint(coordinatesB);

            var result = metric.Calculate(dataPointA, dataPointB);
            Assert.LessOrEqual(result - 2.2360679774997897D, 0.0000000000000010D);
        }

        [Test]
        public void CalculateWithSwappingCoordinates()
        {
            var coordinatesA = new double[] { 0, 0, 0, 0, 0 };
            dataPointA = new DataPoint(coordinatesA);
            var coordinatesB = new double[] { 1, 1, 1, 1, 1 };
            dataPointB = new DataPoint(coordinatesB);

            var result = metric.Calculate(dataPointA, dataPointB) - metric.Calculate(dataPointB, dataPointA);
            Assert.AreEqual(0D, result);
        }


        [Test]
        public void CalculateWithDifferntDimensionSize()
        {
            var coordinatesA = new double[] { 0, 0, 0, 0, 0 };
            dataPointA = new DataPoint(coordinatesA);
            var coordinatesB = new double[] { 1, 1, 1, 1, 1, 1 };
            dataPointB = new DataPoint(coordinatesB);

            var ex = Assert.Throws<DimensionsMismatchExceptions>(() => metric.Calculate(dataPointA, dataPointB));

            Assert.AreEqual(ex.Data["pointA Dimensions"], dataPointA.Dimensions);
            Assert.AreEqual(ex.Data["pointB Dimensions"], dataPointB.Dimensions);
        }


        [Test]
        public void CalculateWithOverflowCausedByCoordinates()
        {
            var coordinatesA = new double[] { double.MaxValue };
            dataPointA = new DataPoint(coordinatesA);
            var coordinatesB = new double[] { 0 };
            dataPointB = new DataPoint(coordinatesB);

            Assert.Throws<OverflowException>(() => metric.Calculate(dataPointA, dataPointB));
        }

        [Test]
        public void CalculateWithOverflowCausedByDimensionsSum()
        {
            double halfFullDouble = double.MaxValue / 2;

            var coordinatesA = new double[6] { halfFullDouble, halfFullDouble, halfFullDouble, halfFullDouble, halfFullDouble, halfFullDouble};
            dataPointA = new DataPoint(coordinatesA);
            var coordinatesB = new double[6] { 0, 0, 0, 0, 0, 0 };
            dataPointB = new DataPoint(coordinatesB);

            Assert.Throws<OverflowException>(() => metric.Calculate(dataPointA, dataPointB));
        }

    }
}

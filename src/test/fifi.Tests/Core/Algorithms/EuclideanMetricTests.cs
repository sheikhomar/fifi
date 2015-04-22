using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core.Algorithms;
using fifi.Core;

namespace fifi.Tests.Core.Algorithms
{
    [TestFixture]
    public class EuclideanMetricTests
    {
        private static int dimensions = 5;
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


        //[Test]
        //public void 
      
        //test ideas:
        // close to 0, close to max, medium results, swapping A and B should yeild the same, differnt array size (this will result in an error)
        //Notes: I somehow need to make the below coordinate definition work with our test runs... Several people suggest TestCaseSource - but I can't get a result with that?!

    }
}

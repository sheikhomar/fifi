using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core.Algorithms;

namespace fifi.Tests.Core.Algorithms
{
    [TestFixture]
    public class EuclideanMetricTests
    {
        private EuclideanMetric metric;

        [SetUp]
        public void Setup()
        {
            metric = new EuclideanMetric();
        }

        [Test]
        public void ShouldCalculateDistanceFromSamePoint()
        {
            var a = new double[] { 1, 2 };
            var result = metric.Calculate(a, a);
            Assert.AreEqual(0f, result);
        }

        [Test]
        public void ShouldCalculateDistanceFromDifferentPoints()
        {
            var a = new double[] { 1, 2, 6 };
            var b = new double[] { 2, 4, 8 };
            var result = metric.Calculate(a, b);
            Assert.AreEqual(3.0f, result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core;
using fifi.WinUI;

namespace fifi.Tests.WinUI
{
    [TestFixture]
    class ScatterPlotUtilityTests
    {
        [TestCase(620, 100)]
        [TestCase(45, 10)]
        [TestCase(10, 10)]
        [TestCase(9.99, 1)]
        [TestCase(5, 1)]
        [TestCase(1.01, 1)]
        [TestCase(1, 1)]
        [TestCase(0.99, 0.1)]
        [TestCase(0.05, 0.01)]
        public void ScatterPlotUtility_ComputeAxisInterval_ReturnsReasonableResult(double diff, double Expected)
        {
            // arrange
            ScatterPlotUtility plot = new ScatterPlotUtility();

            // act
            double result = plot.ComputeAxisInterval(diff);

            // Assert
            Assert.AreEqual(Expected, result);
        }
    }
}

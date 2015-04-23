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
        [TestCase(620, 0, 100)]
        [TestCase(45, 0, 10)]
        [TestCase(10, 0, 10)]
        [TestCase(9.99, 0, 1)]
        [TestCase(5, 0, 1)]
        [TestCase(1.01, 0, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(0.99, 0, 0.1)]
        [TestCase(0.05, 0, 0.01)]
        public void ScatterPlotUtility_ComputeAxisInterval_ReturnsReasonableResult(double AxisMax, double AxisMin, double Expected)
        {
            // arrange
            ScatterPlotUtility plot = new ScatterPlotUtility();

            // act
            double result = plot.ComputeAxisInterval(AxisMax, AxisMin);

            // Assert
            Assert.AreEqual(Expected, result);
        }
    }
}

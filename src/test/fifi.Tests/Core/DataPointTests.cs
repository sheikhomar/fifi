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

    }
}

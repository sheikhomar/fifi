using System.Drawing.Drawing2D;
using NUnit.Framework;

namespace fifi.Data
{
    [TestFixture]
    public class LocalOutlierFactorTest
    {
        private Matrix distanceMatrix;
        private int kNeighbors;

        [SetUp]
        public void SetUp()
        {
            distanceMatrix = new Matrix();
            kNeighbors = 5;
        }

        [Test]
        public void 
    }
}
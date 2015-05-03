using fifi.Core;
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
            distanceMatrix = new Matrix(5,5);
        }

        [Test]
        public void Calculate()
        {
            double[,] LOFInput = { { 0, 87, 284, 259, 270 }, 
                                   { 87, 0, 195, 183, 222 }, 
                                   { 284, 195, 0, 123, 260 }, 
                                   { 259, 183, 123, 0, 140 }, 
                                   { 270, 222, 260, 140, 0 } };
            distanceMatrix.GetSetMatrix = LOFInput;
            kNeighbors = 3;
            LocalOutlierFactor LOF = new LocalOutlierFactor(distanceMatrix, kNeighbors);
            var list = LOF.Run();
            Assert.AreEqual(1, list[0].LocalOutlierFactor);
        }
    }
}
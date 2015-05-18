using System;
using fifi.Core;
using NUnit.Framework;

namespace fifi.Data
{
    [TestFixture]
    public class LocalOutlierFactorTest
    {

        [Test]
        public void LOFOnANormalDistanceMatrix()
        {
            double[,] LOFInput = { { 0, 87, 284, 259, 270 }, 
                                   { 87, 0, 195, 183, 222 }, 
                                   { 284, 195, 0, 123, 260 }, 
                                   { 259, 183, 123, 0, 140 }, 
                                   { 270, 222, 260, 140, 0 } };
            double[] LOFResult = { 1.03891, 1.03319, 0.915506, 1.06623, 0.968356 };
            Matrix distanceMatrix = new Matrix(LOFInput);
            int kNeighbors = 3;
            LocalOutlierFactor LOF = new LocalOutlierFactor(distanceMatrix, kNeighbors);
            var persons = LOF.Run();
            double expectedValue;
            bool validTest = false;
            double calculatedValue;

            for (int i = 0; i < LOFInput.GetLength(0); i++)
            {
                expectedValue = LOFResult[i];
                calculatedValue = persons[i].LocalOutlierFactor;
                if (Math.Abs(calculatedValue - expectedValue) < 0.00001)
                {
                    validTest = true;
                }
            }

            Assert.IsTrue(validTest);
        }

        [Test]
        public void LOFWhereLastTwoValuesAreEqual()
        {
            double[,] LOFInput = { { 0, 87, 231, 259, 259 }, 
                                   { 87, 0, 195, 183, 222 }, 
                                   { 231, 195, 0, 123, 260 }, 
                                   { 259, 183, 123, 0, 140 }, 
                                   { 259, 222, 260, 140, 0 } };
            double[] LOFResult = { 1.06583, 0.996521, 0.925384, 1.0416, 0.964608 };
            Matrix distanceMatrix = new Matrix(LOFInput);
            int kNeighbors = 3;
            LocalOutlierFactor LOF = new LocalOutlierFactor(distanceMatrix, kNeighbors);
            var persons = LOF.Run();
            double expectedValue;
            bool validTest = false;
            double calculatedValue;

            for (int i = 0; i < LOFInput.GetLength(0); i++)
            {
                expectedValue = LOFResult[i];
                calculatedValue = persons[i].LocalOutlierFactor;
                if (Math.Abs(calculatedValue - expectedValue) < 0.00001)
                {
                    validTest = true;
                }
            }

            Assert.IsTrue(validTest);
        }
    }
}
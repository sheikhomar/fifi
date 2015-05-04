using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core;

namespace fifi.Tests.Core
{
    [TestFixture]
    class MultiDimensionalScalingTest
    {
        [Test]
        public void MDSReturnCorrectFiveTimesFiveMatrixItShould()
        {
            double[,] mdsInput = { { 0, 87, 284, 259, 259 }, 
                                   { 87, 0, 195, 183, 222 }, 
                                   { 284, 195, 0, 123, 260 }, 
                                   { 259, 183, 123, 0, 140 }, 
                                   { 259, 222, 260, 140, 0 } };
            Matrix mdsInputMatrix = new Matrix(mdsInput);
            double[,] expectedRes = { { 163.278, 82.341, -95.441, -95.675, -54.504 }, 
                                      { 1.044, -34.181, -115.548, 7.617, 141.184 } };
            Matrix expectedResMatrix = new Matrix(expectedRes);
            MultiDimensionalScaling mdsResult = new MultiDimensionalScaling(mdsInputMatrix);
            Matrix givenMDSResult = mdsResult.Calculate();
            double difference;

            for (int row = 0; row < expectedRes.GetLength(0); row++)
            {
                for (int col = 0; col < expectedRes.GetLength(1); col++)
                {
                    difference = expectedRes[row, col] - givenMDSResult[row, col];
                    if (!(difference < 0.1 && difference > -0.1))
                    {
                        Assert.Fail("{0}, row = {1}, col = {2}", difference, row, col);
                    }
                }
            }
        }

        [Test]
        public void MDSReturnCorrectFourTimesFourMatrixItShould()
        {
            double[,] mdsInput = { { 0, 93, 82, 133 }, 
                                   { 93, 0, 52, 60 }, 
                                   { 82, 52, 0, 111 }, 
                                   { 133, 60, 111, 0 } };
            Matrix mdsInputMatrix = new Matrix(mdsInput);
            double[,] expectedRes = { { -62.815, 18.44, -24.948, 69.422 }, 
                                      { -32.947, 12.032, 39.693, -18.778 } };
            Matrix expectedResMatrix = new Matrix(expectedRes);
            MultiDimensionalScaling mdsResult = new MultiDimensionalScaling(mdsInputMatrix);
            Matrix givenMDSResult = mdsResult.Calculate();
            double difference;

            for (int row = 0; row < expectedRes.GetLength(0); row++)
            {
                for (int col = 0; col < expectedRes.GetLength(1); col++)
                {
                    difference = expectedRes[row, col] - givenMDSResult[row, col];
                    if (!(difference < 0.1 && difference > -0.1))
                    {
                        Assert.Fail("{0}, row = {1}, col = {2}", difference, row, col);
                    }
                }
            }
        }

        [Test]
        public void MDSReturnCorrectFourProfilesTimesFourProfilesMatrixItShould()
        {
            double[,] mdsInput = { { 0, 0.5946, 0.6571, 0.5517 }, 
                                   { 0.5946, 0, 0.6486, 0.7222 }, 
                                   { 0.6571, 0.6486, 0, 0.6452 }, 
                                   { 0.5517, 0.7222, 0.6452, 0 } };
            Matrix mdsInputMatrix = new Matrix(mdsInput);
            double[,] expectedRes = { { -0.084, 0.36, 0.073, -0.349 }, 
                                      { -0.227, -0.148, 0.389, -0.016 } };
            Matrix expectedResMatrix = new Matrix(expectedRes);
            MultiDimensionalScaling mdsResult = new MultiDimensionalScaling(mdsInputMatrix);
            Matrix givenMDSResult = mdsResult.Calculate();
            double difference;

            for (int row = 0; row < expectedRes.GetLength(0); row++)
            {
                for (int col = 0; col < expectedRes.GetLength(1); col++)
                {
                    difference = expectedRes[row, col] - givenMDSResult[row, col];
                    if (!(difference < 0.01 && difference > -0.01))
                    {
                        Assert.Fail("{0}, row = {1}, col = {2}", difference, row, col);
                    }
                }
            }
        }

        [Test]
        public void MDSThrowRankExceptionItShould()
        {
            double[,] mdsInput = { { 2, 3, 4, 5 }, { 3, 4, 5, 6 } };
            Matrix mdsInputMatrix = new Matrix(mdsInput);
            Assert.Catch<RankException>(() => { new MultiDimensionalScaling(mdsInputMatrix); });
        }
    }
}

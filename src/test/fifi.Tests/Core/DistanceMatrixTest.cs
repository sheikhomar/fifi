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
    class DistanceMatrixTest
    {
        private int collectionSize;
        private IdentifiableDataPointCollection dataCollection;
        private IDistanceMetric distanceMetric;
        private GenerateIdentifiableDataPointCollection generatedDataCollection;
        private Matrix distanceMatrix, expectedMatrix;

        [SetUp]
        public void SetUp()
        {
            distanceMetric = new EuclideanMetric();
        }

        [Test]
        public void DistanceMatrixShouldReturnCorrectDistanceMatrix()
        {
            double difference;
            collectionSize = 10;

            distanceMetric = new EuclideanMetric();
            generatedDataCollection = new GenerateIdentifiableDataPointCollection(collectionSize);
            dataCollection = generatedDataCollection.Generate();

            distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            expectedMatrix = ExpectedMatrix();

            for (int row = 0; row < distanceMatrix.Row; row++)
            {
                for (int col = 0; col < distanceMatrix.Column; col++)
                {
                    difference = distanceMatrix[row, col] - expectedMatrix[row, col];
                    if (!(difference < 0.01 && difference > -0.01 && distanceMatrix[row, col] >= 0))
                    {
                        Assert.Fail("{0}, row = {1}, col = {2}", difference, row, col);
                    }
                }
            }
        }

        [Test]
        public void DistanceMatrixShouldReturnLargerCorrectDistanceMatrix()
        {
            double difference;
            collectionSize = 111;

            distanceMetric = new EuclideanMetric();
            generatedDataCollection = new GenerateIdentifiableDataPointCollection(collectionSize);
            dataCollection = generatedDataCollection.Generate();

            distanceMatrix = new DistanceMatrix(dataCollection, distanceMetric);
            expectedMatrix = ExpectedMatrix();

            for (int row = 0; row < distanceMatrix.Row; row++)
            {
                for (int col = 0; col < distanceMatrix.Column; col++)
                {
                    difference = distanceMatrix[row, col] - expectedMatrix[row, col];
                    if (!(difference < 0.01 && difference > -0.01 && distanceMatrix[row, col] >= 0))
                    {
                        Assert.Fail("{0}, row = {1}, col = {2}", difference, row, col);
                    }
                }
            }
        }

        [Test]
        public void DistanceMatrixThrowArgumentNullExceptionItShouldOnDistanceMetric()
        {
            collectionSize = 111;
            generatedDataCollection = new GenerateIdentifiableDataPointCollection(collectionSize);
            dataCollection = generatedDataCollection.Generate();
            Assert.Catch<ArgumentNullException>(() => { new DistanceMatrix(dataCollection, null); });
        }

        #region Hardcoded matrix and ExpectedMatrix function
        private Matrix ExpectedMatrix()
        {
            Matrix expectedMatrix = new Matrix(collectionSize, collectionSize);
            Matrix smallExpectedMatrix = new Matrix(10, 10);
            double[,] hardCodedExpectedMatrix = {{0, 0,	0.7071,	0.7071,	0.8718,	0.8718,	0.8718, 0.8718,	0.8718, 1.4087},
                                                {0,	0, 0.7071, 0.7071, 0.8718, 0.8718, 0.8718, 0.8718, 0.8718, 1.4087},
                                                {0.7071, 0.7071, 0,	0, 0.8718, 0.8718, 0.8718, 0.8718, 0.8718, 1.7276},
                                                {0.7071, 0.7071, 0,	0, 0.8718, 0.8718, 0.8718, 0.8718, 0.8718, 1.7276},
                                                {0.8718, 0.8718, 0.8718, 0.8718, 0,	0, 0, 0, 0, 1.4214},
                                                {0.8718, 0.8718, 0.8718, 0.8718, 0,	0, 0, 0, 0,	1.4214},
                                                {0.8718, 0.8718, 0.8718, 0.8718, 0,	0, 0, 0, 0,	1.4214},
                                                {0.8718, 0.8718, 0.8718, 0.8718, 0,	0, 0, 0, 0,	1.4214},
                                                {0.8718, 0.8718, 0.8718, 0.8718, 0,	0, 0, 0, 0,	1.4214},
                                                {1.4087, 1.4087, 1.7276, 1.7276, 1.4214, 1.4214, 1.4214, 1.4214, 1.4214, 0}};
            smallExpectedMatrix = new Matrix(hardCodedExpectedMatrix);

            for (int row = 0; row < collectionSize; row++)
            {
                for (int col = 0; col < collectionSize; col++)
                {
                    expectedMatrix[row, col] = smallExpectedMatrix[row % 10, col % 10];
                }
            }

            return expectedMatrix;
        }
        #endregion
    }
}

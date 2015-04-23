using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;
using fifi.Core.Algorithms;
using NUnit.Framework;

namespace fifi.Tests.Core.Algorithms
{
    [TestFixture]
    public class KMeansTests
    {
     
        private static int k = 5;
        private int id;
        private IdentifiableDataPointCollection dataCollection;
        private int maxIterations = 100;
        private IDistanceMetric distanceMetric;
        private IdentifiableDataPoint dataPoint;
        private DataPointAttribute dataPointAttribute;

        [SetUp]
        public void SetUp()
        {
            distanceMetric = new EuclideanMetric();
            id = new int();
        }

        [Test]
        public void CalculateKMeansClustersSimple()
        {
            id = 1;
            int dimentions = 5;

            dataCollection = new IdentifiableDataPointCollection();
            for (int i = 0; i < 10; i++)
            {
                dataPoint = new IdentifiableDataPoint(id++, dimentions);
                dataCollection.AddItem(dataPoint);
            }

            for (int i = 0; i < 9; i++)
            {
                dataCollection[i].AddAttribute("Gender", 1d);
            }

            dataCollection[9].AddAttribute("Gender", 0d);

            Assert.AreEqual(dataCollection[0].Attributes[0].Value, dataCollection[1].Attributes[0].Value);

        }
    }
}

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
            //var dataPointB = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointC = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointD = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointE = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointF = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointG = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointH = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointI = new IdentifiableDataPoint(id++, dimentions);
            //var dataPointJ = new IdentifiableDataPoint(id++, dimentions);
            for (int i = 0; i < 10; i++)
            {
                dataPoint = new IdentifiableDataPoint(id++, dimentions);
                dataCollection.AddItem(dataPoint);
            }
            //dataCollection.AddItem(dataPointA);
            //dataCollection.AddItem(dataPointB);
            //dataCollection.AddItem(dataPointC);
            //dataCollection.AddItem(dataPointD);
            //dataCollection.AddItem(dataPointE);
            //dataCollection.AddItem(dataPointF);
            //dataCollection.AddItem(dataPointG);
            //dataCollection.AddItem(dataPointH);
            //dataCollection.AddItem(dataPointI);
            //dataCollection.AddItem(dataPointJ);

            for (int i = 0; i < 9; i++)
            {
                dataCollection[i].AddAttribute("Gender", 1d);
            }

            //dataCollection[0].AddAttribute("Gender", 1d);
            //dataCollection[1].AddAttribute("Gender", 1d);
            //dataCollection[2].AddAttribute("Gender", 1d);
            //dataCollection[3].AddAttribute("Gender", 1d);
            //dataCollection[4].AddAttribute("Gender", 1d);
            //dataCollection[5].AddAttribute("Gender", 1d);
            //dataCollection[6].AddAttribute("Gender", 1d);
            //dataCollection[7].AddAttribute("Gender", 1d);
            //dataCollection[8].AddAttribute("Gender", 1d);
            dataCollection[9].AddAttribute("Gender", 0d);

            Assert.AreEqual(dataCollection[0].Attributes[0].Value, dataCollection[1].Attributes[0].Value);

        }
    }
}

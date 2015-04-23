using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public void KMeansDataPointCheck()
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
                if (i < 4)
                {
                    dataCollection[i].AddAttribute("Income", 1d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Income", 0.2858d);
                }
                dataCollection[i].AddAttribute("Age", 0.16d);
                if (i < 2 || i > 3)
                {
                    dataCollection[i].AddAttribute("Purchase", 1d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Purchase", 0.5d);
                }
                if (i < 2)
                {
                    dataCollection[i].AddAttribute("Control", 0.5d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Control", 1d);
                }
                
            }

            dataCollection[9].AddAttribute("Gender", 0d);
            dataCollection[9].AddAttribute("Income", 0.1429d);
            dataCollection[9].AddAttribute("Age", 0.16d);
            dataCollection[9].AddAttribute("Purchase", 1d);
            dataCollection[9].AddAttribute("Control", 0d);

            Assert.AreEqual(dataCollection[0].Attributes[0].Value, dataCollection[1].Attributes[0].Value);
            Assert.AreNotEqual(dataCollection[0].Attributes[0].Value, dataCollection[9].Attributes[0].Value);
            
            Assert.AreEqual(dataCollection[0].Attributes[1].Value, dataCollection[1].Attributes[1].Value);
            Assert.AreNotEqual(dataCollection[0].Attributes[1].Value, dataCollection[9].Attributes[1].Value);
            Assert.AreNotEqual(dataCollection[0].Attributes[1].Value, dataCollection[4].Attributes[1].Value);
            
            Assert.AreEqual(dataCollection[0].Attributes[2].Value, dataCollection[1].Attributes[2].Value);
            Assert.AreEqual(dataCollection[0].Attributes[2].Value, dataCollection[9].Attributes[2].Value);
            
            Assert.AreEqual(dataCollection[0].Attributes[3].Value, dataCollection[1].Attributes[3].Value);
            Assert.AreNotEqual(dataCollection[0].Attributes[3].Value, dataCollection[3].Attributes[3].Value);
            Assert.AreEqual(dataCollection[0].Attributes[3].Value, dataCollection[9].Attributes[3].Value);

            Assert.AreNotEqual(dataCollection[0].Attributes[4].Value, dataCollection[2].Attributes[4].Value);
            Assert.AreNotEqual(dataCollection[0].Attributes[4].Value, dataCollection[9].Attributes[4].Value);
        }

        [Test]
        public void CentroidsArePlacedCorrect()
        {
            
        }

        [Test]
        public void DataPointsAreAssignedToCentroids()
        {
            
        }
    }
}

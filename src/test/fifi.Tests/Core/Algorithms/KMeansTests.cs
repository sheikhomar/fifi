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

        private static int k = 3;
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
                else if (i > 3)
                {
                    dataCollection[i].AddAttribute("Income", 0.2858d);
                }
                dataCollection[i].AddAttribute("Age", 0.16d);
                if (i > 1 && i < 4)
                {
                    dataCollection[i].AddAttribute("Purchase", 0.5d);
                }
                else
                {
                    dataCollection[i].AddAttribute("Purchase", 1d);
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
        }

        [Test]
        public void KMeansDataPointCheck()
        {
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
            var kmeans = new KMeans(dataCollection, k, distanceMetric);
            var result = kmeans.Generate();

            double[] _centroid1 = {1, 1, 0.16, 0.75, 0.75};
            double[] _centroid2 = {1, 1, 0.16, 1, 1};

            Assert.AreEqual(_centroid1[0], result.Clusters[2].Centroid.Coordinates[0]);
            Assert.AreEqual(_centroid1[1], result.Clusters[2].Centroid.Coordinates[1]);
            Assert.AreEqual(_centroid1[2], result.Clusters[2].Centroid.Coordinates[2]);
            Assert.AreEqual(_centroid1[3], result.Clusters[2].Centroid.Coordinates[3]);
            Assert.AreEqual(_centroid1[4], result.Clusters[2].Centroid.Coordinates[4]);

        }

        [Test]
        public void KMeansClusteringWorksOnOneDimension()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 1);
            var p2 = new IdentifiableDataPoint(1, 1);
            var p3 = new IdentifiableDataPoint(2, 1);
            var p4 = new IdentifiableDataPoint(3, 1);

            p1.AddAttribute("Gender", 1);
            p2.AddAttribute("Gender", 0);
            p3.AddAttribute("Gender", 1);
            p4.AddAttribute("Gender", 1);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(2, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(0, result2.Clusters[2].Members.Count);
        }

        [Test]
        public void KMeansClusteringWorksOnTwoDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 2);
            var p2 = new IdentifiableDataPoint(1, 2);
            var p3 = new IdentifiableDataPoint(2, 2);
            var p4 = new IdentifiableDataPoint(3, 2);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);

            p2.AddAttribute("Gender", 0);
            p2.AddAttribute("Income", 0.1429);
            
            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);

            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(1, result2.Clusters[0].Members.Count);
            Assert.AreEqual(2, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);
        }

        [Test]
        public void KMeansCentroidsArePlacedRightInTwoDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 2);
            var p2 = new IdentifiableDataPoint(1, 2);
            var p3 = new IdentifiableDataPoint(2, 2);
            var p4 = new IdentifiableDataPoint(3, 2);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);

            p2.AddAttribute("Gender", 0);
            p2.AddAttribute("Income", 0.1429);
            
            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            
            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            
            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid1 = new double[] {1, 0.2858};
            double[] _centroid2 = new double[] {1, 1};
            double[] _centroid3 = new double[] {0, 0.1429};


            Assert.AreEqual(_centroid1, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid2, result2.Clusters[1].Centroid.Coordinates);
            Assert.AreEqual(_centroid3, result2.Clusters[2].Centroid.Coordinates);

        }

        [Test]
        public void KMeansClusteringWorksOnThreeDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 3);
            var p2 = new IdentifiableDataPoint(1, 3);
            var p3 = new IdentifiableDataPoint(2, 3);
            var p4 = new IdentifiableDataPoint(3, 3);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);
            p1.AddAttribute("Age", 0.16);
            
            p2.AddAttribute("Gender", 0);
            p2.AddAttribute("Income", 0.1429);
            p2.AddAttribute("Age", 0.16);

            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            p3.AddAttribute("Age", 0.16);
            
            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            p4.AddAttribute("Age", 0.16);
            
            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(1, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);

        }

        [Test]
        public void KMeansClusteringWorksOnFourDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 4);
            var p2 = new IdentifiableDataPoint(1, 4);
            var p3 = new IdentifiableDataPoint(2, 4);
            var p4 = new IdentifiableDataPoint(3, 4);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);
            p1.AddAttribute("Age", 0.16);
            p1.AddAttribute("Purchase", 0.5);

            p2.AddAttribute("Gender", 0);
            p2.AddAttribute("Income", 0.1429);
            p2.AddAttribute("Age", 0.16);
            p2.AddAttribute("Purchase", 1);

            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            p3.AddAttribute("Age", 0.16);
            p3.AddAttribute("Purchase", 1);

            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            p4.AddAttribute("Age", 0.16);
            p4.AddAttribute("Purchase", 1);


            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(1, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);
        }

        [Test]
        public void KMeansClusteringWorksOnFiveDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 5);
            var p2 = new IdentifiableDataPoint(1, 5);
            var p3 = new IdentifiableDataPoint(2, 5);
            var p4 = new IdentifiableDataPoint(3, 5);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);
            p1.AddAttribute("Age", 0.16);
            p1.AddAttribute("Purchase", 0.5);
            p1.AddAttribute("Control", 1);

            p2.AddAttribute("Gender", 0);
            p2.AddAttribute("Income", 0.1429);
            p2.AddAttribute("Age", 0.16);
            p2.AddAttribute("Purchase", 1);
            p1.AddAttribute("Control", 0);

            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            p3.AddAttribute("Age", 0.16);
            p3.AddAttribute("Purchase", 1);
            p1.AddAttribute("Control", 1);

            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            p4.AddAttribute("Age", 0.16);
            p4.AddAttribute("Purchase", 1);
            p1.AddAttribute("Control", 0.5);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, 3, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(1, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);
        }
    }
}

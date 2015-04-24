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

        private IdentifiableDataPointCollection dataCollection;
        private IDistanceMetric distanceMetric;

        [SetUp]
        public void SetUp()
        {
            distanceMetric = new EuclideanMetric();

            GenerateIdentifiableDataPointCollection _generatedDataCollection = new GenerateIdentifiableDataPointCollection(10);
            dataCollection = _generatedDataCollection.Generate();        
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

            var kmeans2 = new KMeans(dataSet, new []{0, 1}, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(3, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
        }


        [Test]
        public void KMeansCentroidsArePlacedRightInOneDimension()
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

            var kmeans2 = new KMeans(dataSet, new [] {0, 1} , new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid1 = { 1 };
            double[] _centroid2 = { 0 };

            Assert.AreEqual(_centroid1, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid2, result2.Clusters[1].Centroid.Coordinates);
           
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

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(2, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
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

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid1 = { 1, 0.2858 };
            double[] _centroid2 = { 1, 1 };
            double[] _centroid3 = { 0, 0.1429 };


            Assert.AreEqual(_centroid2, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid3, result2.Clusters[1].Centroid.Coordinates);
            Assert.AreEqual(_centroid1, result2.Clusters[2].Centroid.Coordinates);

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

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(2, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);

        }

        [Test]
        public void KMeansCentroidsArePlacedRightInThreeDimensions()
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

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid1 = { 1, 1, 0.16 };
            double[] _centroid2 = { 0, 0.1429, 0.16 };
            double[] _centroid3 = { 1, 0.2858, 0.16 };

            Assert.AreEqual(_centroid1, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid2, result2.Clusters[1].Centroid.Coordinates);
            Assert.AreEqual(_centroid3, result2.Clusters[2].Centroid.Coordinates);

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

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(2, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);
        }

        [Test]
        public void KMeansCentroidsArePlacedRightInFourDimensions()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 4);
            var p2 = new IdentifiableDataPoint(1, 4);
            var p3 = new IdentifiableDataPoint(2, 4);
            var p4 = new IdentifiableDataPoint(3, 4);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);
            p1.AddAttribute("Age", 0.16);
            p1.AddAttribute("Purchase", 1);

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
            p4.AddAttribute("Purchase", 0.5);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid3 = { 1, 0.2858, 0.16, 1 };
            double[] _centroid1 = { 1, 1, 0.16, 0.75, };
            double[] _centroid2 = { 0, 0.1429, 0.16, 1 };

            Assert.AreEqual(_centroid1, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid2, result2.Clusters[1].Centroid.Coordinates);
            Assert.AreEqual(_centroid3, result2.Clusters[2].Centroid.Coordinates);

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
            p2.AddAttribute("Control", 0);

            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            p3.AddAttribute("Age", 0.16);
            p3.AddAttribute("Purchase", 1);
            p3.AddAttribute("Control", 1);

            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            p4.AddAttribute("Age", 0.16);
            p4.AddAttribute("Purchase", 1);
            p4.AddAttribute("Control", 0.5);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();

            Assert.AreEqual(2, result2.Clusters[0].Members.Count);
            Assert.AreEqual(1, result2.Clusters[1].Members.Count);
            Assert.AreEqual(1, result2.Clusters[2].Members.Count);
        }

        [Test]
        public void KMeansCentroidsArePlacedRightInFiveDimensions()
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
            p2.AddAttribute("Control", 0);

            p3.AddAttribute("Gender", 1);
            p3.AddAttribute("Income", 0.2858);
            p3.AddAttribute("Age", 0.16);
            p3.AddAttribute("Purchase", 1);
            p3.AddAttribute("Control", 1);

            p4.AddAttribute("Gender", 1);
            p4.AddAttribute("Income", 1);
            p4.AddAttribute("Age", 0.16);
            p4.AddAttribute("Purchase", 1);
            p4.AddAttribute("Control", 0.5);

            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);
            dataSet.AddItem(p4);

            var kmeans2 = new KMeans(dataSet, new []{0, 1, 2}, new EuclideanMetric());

            var result2 = kmeans2.Generate();
            double[] _centroid1 = { 1, 0.2858, 0.16, 1, 1 };
            double[] _centroid2 = { 1, 1, 0.16, 0.75, 0.75 };
            double[] _centroid3 = { 0, 0.1429, 0.16, 1, 0 };


            Assert.AreEqual(_centroid2, result2.Clusters[0].Centroid.Coordinates);
            Assert.AreEqual(_centroid3, result2.Clusters[1].Centroid.Coordinates);
            Assert.AreEqual(_centroid1, result2.Clusters[2].Centroid.Coordinates);

        }

        [Test]
        public void CalculateWithZeroClusters()
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

            Assert.Throws<ArgumentException>(() => new KMeans(dataSet, 0, new EuclideanMetric()) );
        }

        [Test]
        public void CentroidsHaveDistinctValues()
        {
            var dataSet = new IdentifiableDataPointCollection();
            var p1 = new IdentifiableDataPoint(0, 2);
            var p2 = new IdentifiableDataPoint(1, 2);
            var p3 = new IdentifiableDataPoint(2, 2);

            p1.AddAttribute("Gender", 1);
            p1.AddAttribute("Income", 1);

            p2.AddAttribute("Gender", 1);
            p2.AddAttribute("Income", 1);

            p3.AddAttribute("Gender", 0);
            p3.AddAttribute("Income", 0);


            dataSet.AddItem(p1);
            dataSet.AddItem(p2);
            dataSet.AddItem(p3);

            Assert.Throws<InvalidOperationException>(() => new KMeans(dataSet, new []{0,1}, new EuclideanMetric()));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace fifi.Core
{
    /// <summary>
    /// Represents k-means clustering algorithm.
    /// </summary>
    public class KMeans : IClusteringAlgorithm
    {
        private readonly IdentifiableDataPointCollection dataCollection;
        private readonly int maxIterations;
        private readonly IDistanceMetric distanceMetric;
        private readonly IList<DataPoint> centroids;

        public KMeans(IdentifiableDataPointCollection dataCollection, int k, IDistanceMetric distanceMetric, int maxIterations = 100)
        {
            if (k < 1)
                throw new ArgumentException("Clusters cannot be generated for less than one centroid");
        
            this.dataCollection = dataCollection;
            this.maxIterations = maxIterations;
            this.distanceMetric = distanceMetric;
            this.centroids = dataCollection
                .OrderBy(dataPoint => Guid.NewGuid()) // Random order
                .Take(k)
                .Select(dataPoint => dataPoint.Clone())
                .ToList();

            EnsureDistinctCentroid();
        }

        public KMeans(IdentifiableDataPointCollection dataCollection, int[] centroidIndicies, IDistanceMetric distanceMetric, int maxIterations = 100)
        {
            this.dataCollection = dataCollection;
            this.maxIterations = maxIterations;
            this.distanceMetric = distanceMetric;

            if (centroidIndicies.Length != centroidIndicies.Distinct().Count())
                throw new ArgumentException(
                    "Array contains dublicate indicies, which is not allowed.", "centroidIndicies");

            this.centroids = centroidIndicies
                .Select(index => this.dataCollection[index].Clone())
                .ToList();

            EnsureDistinctCentroid();
        }

        public ClusteringResult Calculate()
        {
            ClusteringResult result = new ClusteringResult(centroids);

            bool centroidMoved = false;
            int iterationCount = 0;

            do
            {
                iterationCount++;
                result.ClearMembers();
                AssignEachDataPointToNearestCluster(result.Clusters);
                result.Clusters.RemoveAll(cluster => cluster.Members.Count == 0);
                centroidMoved = false;
                foreach (var cluster in result.Clusters)
                {
                    if (MoveCentroidIfNeeded(cluster))
                    {
                        centroidMoved = true;
                        break;
                    }
                }

                if (iterationCount >= maxIterations)
                    centroidMoved = false;
            } while (centroidMoved);

            return result;
        }

        private void AssignEachDataPointToNearestCluster(IList<Cluster> clusters)
        {
            foreach (var dataItem in dataCollection)
            {
                Cluster closestCluster = null;
                double minDistance = double.MaxValue;
                foreach (var cluster in clusters)
                {
                    var centroid = cluster.Centroid;
                    double distance = distanceMetric.Calculate(centroid, dataItem);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestCluster = cluster;
                    }
                }

                ClusterMember member = new ClusterMember(dataItem, minDistance);
                closestCluster.Members.Add(member);
            }
        }

        private void EnsureDistinctCentroid()
        {
            for (int i = 0; i < centroids.Count; i++)
            {
                for (int j = i+1; j < centroids.Count; j++)
                {
                    if (centroids[i].Equals(centroids[j]))
                    {
                        // We can avoid this exception by implementing
                        // a method that looks for new centroids if this.centroids
                        // contains duplicate DataPoints.
                        //throw new InvalidOperationException("Centroids contains duplicate data points.");
                    }
                }
            }
        }

        private bool MoveCentroidIfNeeded(Cluster cluster)
        {
            DataPoint centroid = cluster.Centroid;

            DataPoint gravityCenter = CalculateGravityCenter(cluster);

            bool hasCentroidMoved = !gravityCenter.Equals(centroid);

            if (hasCentroidMoved)
                centroid.CopyFrom(gravityCenter);

            return hasCentroidMoved;
        }

        private DataPoint CalculateGravityCenter(Cluster cluster)
        {
            DataPoint centroid = cluster.Centroid;
            int dimension = centroid.Dimensions;

            DataPoint gravityCenter = new DataPoint(dimension);
            foreach (var member in cluster.Members)
            {
                var profile = member.Member;
                for (int i = 0; i < dimension; i++)
                    gravityCenter[i] += profile.Coordinates[i];
            }

            for (int i = 0; i < dimension; i++)
                gravityCenter[i] /= cluster.Members.Count;

            return gravityCenter;
        }
    }
}

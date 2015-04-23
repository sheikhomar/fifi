using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    /// <summary>
    /// Represents k-means clustering algorithm.
    /// </summary>
    public class KMeans : IClusteringAlgorithm
    {
        private int k;
        private IdentifiableDataPointCollection dataCollection;
        private int maxIterations;
        private IDistanceMetric distanceMetric;

        public KMeans(IdentifiableDataPointCollection dataCollection, int k, IDistanceMetric distanceMetric, int maxIterations = 100)
        {
            this.dataCollection = dataCollection;
            this.k = k;
            this.maxIterations = maxIterations;
            this.distanceMetric = distanceMetric;
        }

        public ClusteringResult Generate()
        {
            ClusteringResult result = new ClusteringResult();

            IList<DataPoint> centroids = GenerateRandomCentroids();
            foreach (var centroid in centroids)
            {
                result.Clusters.Add(new Cluster(centroid));
            }

            bool centroidMoved = false;
            int count = 0;

            do
            {
                count++;

                foreach (var cluster in result.Clusters)
                {
                    cluster.Members.Clear();
                }

                foreach (var dataItem in dataCollection)
                {
                    Cluster closestCluster = null;
                    double minDistance = double.MaxValue;
                    foreach (var cluster in result.Clusters)
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
                centroidMoved = false;

                foreach (var cluster in result.Clusters)
                {
                    if (MoveCentroidIfNeeded(cluster))
                        centroidMoved = true;
                }

                if (count >= maxIterations)
                    centroidMoved = false;

            } while (centroidMoved);

            return result;
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
        private IList<DataPoint> GenerateRandomCentroids()
        {
            var centroids = new List<DataPoint>();
            int dimensions = dataCollection.ItemDimensions; //If the items does not have the same ammout of values, this might break :=)

            for (int i = 0; i < k; i++)
                centroids.Add(Cluster.GenerateRandomCentroid(dimensions));

            return centroids;
        }
    }
}

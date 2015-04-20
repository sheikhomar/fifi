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
        private DataCollection dataCollection;
        private int maxIterations;
        private IDistanceMetric distanceMetric;

        public KMeans(DataCollection dataCollection, int k, IDistanceMetric distanceMetric, int maxIterations = 100)
        {
            this.dataCollection = dataCollection;
            this.k = k;
            this.maxIterations = maxIterations;
            this.distanceMetric = distanceMetric;
        }

        public ClusteringResult Generate()
        {
            ClusteringResult result = new ClusteringResult();

            IList<Centroid> centroids = GenerateRandomCentroids();
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
                    Centroid closestCentroid = null;
                    Cluster closestCluster = null;
                    double minDistance = double.MaxValue;
                    foreach (var cluster in result.Clusters)
                    {
                        var centroid = cluster.Centroid;
                        double distance = distanceMetric.Calculate(centroid.Values, dataItem.Values);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            closestCentroid = centroid;
                            closestCluster = cluster;
                        }
                    }

                    ClusterMember member = new ClusterMember(dataItem, minDistance);
                    closestCluster.Members.Add(member);

                    //closestCentroid.Add(dataItem);
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
            Centroid centroid = cluster.Centroid;

            for (int i = 0; i < centroid.GravityCenter.Length; i++)
            {
                centroid.GravityCenter[i] = 0;
            }

            foreach (var member in cluster.Members)
            {
                var dataItem = member.DataItem;
                for (int i = 0; i < dataItem.Values.Count; i++)
                {
                    centroid.GravityCenter[i] += dataItem.Values[i];
                }
            }

            for (int i = 0; i < centroid.GravityCenter.Length; i++)
            {
                centroid.GravityCenter[i] /= cluster.Members.Count;
            }

            bool centroidHasMoved = false;

            for (int i = 0; i < centroid.Values.Count; i++)
            {
                if (centroid.Values[i] != centroid.GravityCenter[i])
                {
                    centroidHasMoved = true;
                }
            }

            if (centroidHasMoved)
            {
                for (int i = 0; i < centroid.Values.Count; i++)
                {
                    centroid.Values[i] = centroid.GravityCenter[i];
                }
            }

            return centroidHasMoved;
        }

        private IList<Centroid> GenerateRandomCentroids()
        {
            IList<Centroid> centroids = new List<Centroid>();

            int dimensions = dataCollection.Items[0].Values.Count; //If the items does not have the same ammout of values, this might break :=)

            for (int i = 0; i < k; i++)
            {
                centroids.Add(Centroid.GenerateRandom(dimensions));
            }

            return centroids;
        }
    }
}

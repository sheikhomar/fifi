using System;
using System.Collections.Generic;

namespace fifi.Core
{
    /// <summary>
    /// Represents result of <see cref="IClusteringAlgorithm"/>.
    /// </summary>
    public class ClusteringResult
    {
        public ClusteringResult(IList<DataPoint> centroids)
        {
            if (centroids == null) 
                throw new ArgumentNullException("centroids");

            Clusters = new List<Cluster>();

            for (int i = 0; i < centroids.Count; i++)
                Clusters.Add(new Cluster(i + 1, centroids[i]));
        }

        public List<Cluster> Clusters { get; private set; }

        public Cluster FindCluster(IdentifiableDataPoint dataPoint)
        {
            foreach (var cluster in Clusters)
            {
                foreach (var clusterMember in cluster.Members)
                {
                    if (clusterMember.Member.Equals(dataPoint))
                    {
                        return cluster;
                    }
                }
            }

            return null;
        }

        public void ClearMembers()
        {
            foreach (var cluster in Clusters)
            {
                cluster.Members.Clear();
            }
        }
    }
}

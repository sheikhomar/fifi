using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;

namespace fifi.Core
{
    public class ClusteringResult
    {
        public ClusteringResult()
        {
            Clusters = new List<Cluster>();
        }

        public List<Cluster> Clusters { get; set; }

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
    }
}

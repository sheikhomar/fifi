using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    public class ClusteringResult
    {
        public ClusteringResult()
        {
            Clusters = new List<Cluster>();
        }

        public List<Cluster> Clusters { get; set; }
    }
}

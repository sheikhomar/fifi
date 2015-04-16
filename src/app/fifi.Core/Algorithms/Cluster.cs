using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Cluster : DataPoint
    {
        public Cluster(Centroid centroid)
        {
            Centroid = centroid;
            Members = new List<ClusterMember>();
        }

        public Centroid Centroid { get; private set; }
        public IList<ClusterMember> Members { get; private set; }
    }
}

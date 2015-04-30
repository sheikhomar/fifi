using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class Cluster
    {
        public Cluster(int id, DataPoint centroid)
        {
            Centroid = centroid;
            Members = new List<ClusterMember>();
            Id = id;
        }

        public DataPoint Centroid { get; private set; }
        public IList<ClusterMember> Members { get; private set; }
        public int Id { get; private set; }
    }
}

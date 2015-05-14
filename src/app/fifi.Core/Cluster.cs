using System;
using System.Collections.Generic;

namespace fifi.Core
{
    public class Cluster
    {
        public Cluster(int id, DataPoint centroid)
        {
            if (centroid == null) 
                throw new ArgumentNullException("centroid");

            Centroid = centroid;
            Members = new List<ClusterMember>();
            Id = id;
        }

        public DataPoint Centroid { get; private set; }
        public IList<ClusterMember> Members { get; private set; }
        public int Id { get; private set; }
    }
}

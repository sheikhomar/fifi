using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    class Outlier
    {
        Centroid belongingCluster;
        ClusterMember identifiableDataPoint;

        public Outlier(ClusterMember inputDataPoint, Centroid inputBelongingCluster)
        {
            this.identifiableDataPoint = inputDataPoint;
            this.belongingCluster = inputBelongingCluster;
        }
    }
}

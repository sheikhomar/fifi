using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    public class Outlier
    {
        public Centroid belongingCluster;
        public ClusterMember identifiableDataPoint;

        public Outlier(ClusterMember inputDataPoint, Centroid inputBelongingCluster)
        {
            this.identifiableDataPoint = inputDataPoint;
            this.belongingCluster = inputBelongingCluster;
        }



    }
}

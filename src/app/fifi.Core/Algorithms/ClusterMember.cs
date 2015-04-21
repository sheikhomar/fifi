using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterMember
    {
        public ClusterMember(IdentifiableDataPoint identifiableDataPoint, double distance)
        {
            ItemIdentifiableDataPoint = identifiableDataPoint;
            Distance = distance;
        }

        public IdentifiableDataPoint ItemIdentifiableDataPoint { get; private set; }
        public double Distance { get; private set; }
    }
}

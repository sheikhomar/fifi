using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterMember
    {
        public ClusterMember(IdentifiableDataPoint member, double distance)
        {
            Member = member;
            Distance = distance;
        }

        public IdentifiableDataPoint Member { get; private set; }
        public double Distance { get; private set; }
    }
}

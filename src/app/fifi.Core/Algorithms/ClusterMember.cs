using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterMember
    {
        public ClusterMember(IdentifiableDataPoint dataItem, double distance)
        {
            DataItem = dataItem;
            Distance = distance;
        }

        public IdentifiableDataPoint DataItem { get; private set; }
        public double Distance { get; private set; }
    }
}

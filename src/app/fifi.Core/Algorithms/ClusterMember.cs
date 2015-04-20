using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterMember
    {
        public ClusterMember(DataItem dataItem, double distance)
        {
            DataItem = dataItem;
            Distance = distance;
        }

        public DataItem DataItem{ get; private set; }
        public double Distance { get; private set; }
    }
}

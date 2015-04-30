using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DimensionsMismatchExceptions : ArgumentException
    {
        public DimensionsMismatchExceptions(DataPoint pointA, DataPoint pointB) : base (String.Format("Mismatch in dimensions, cannot calculate the distance between to differnt dimensions. First point has {0} imensions, second point has {1} dimensions", pointA.Dimensions, pointB.Dimensions))
        {
            this.Data.Add("pointA Dimensions", pointA.Dimensions);
            this.Data.Add("pointB Dimensions", pointB.Dimensions);
        }
    }
}

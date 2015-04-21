using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class IdentifiableDataPoint : DataPoint
    {
        public IdentifiableDataPoint(int id, int dimensions) : base(dimensions)
        {
            Id = id;
            Attributes = new List<DataItemAttribute>();
        }

        public int Id { get; private set; }
        public IList<DataItemAttribute> Attributes { get; private set; }
    }
}

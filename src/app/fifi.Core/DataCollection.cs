using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class IdentifiableDataPointCollection
    {
        public List<IdentifiableDataPoint> Items { get; private set; }

        public IdentifiableDataPointCollection()
        {
            Items = new List<IdentifiableDataPoint>();
        }

        public void AddItem(IdentifiableDataPoint value)
        {
            Items.Add(value);
        }

        public IEnumerator<IdentifiableDataPoint> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}

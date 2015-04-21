using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class IdentifiableDataPointCollection : IEnumerable<IdentifiableDataPoint>
    {
        private IList<IdentifiableDataPoint> items;
        private int itemDimensions;

        public IdentifiableDataPointCollection()
        {
            items = new List<IdentifiableDataPoint>();
        }

        public void AddItem(IdentifiableDataPoint value)
        {
            if (itemDimensions == 0)
                itemDimensions = value.Dimensions;

            items.Add(value);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public int ItemDimensions
        {
            get { return itemDimensions; }
        }

        public IdentifiableDataPoint this[int index]
        {
            get { return this.items[index]; }
        }

        public IEnumerator<IdentifiableDataPoint> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}

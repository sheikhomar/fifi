using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class IdentifiableDataPointCollection
    {
        public List<DataItem> Items { get; private set; }

        public IdentifiableDataPointCollection()
        {
            Items = new List<DataItem>();
        }

        public void AddItem(DataItem value)
        {
            Items.Add(value);
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}

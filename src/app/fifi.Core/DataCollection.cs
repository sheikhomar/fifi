using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataCollection
    {
        public List<DataItem> Items { get; private set; }

        public DataCollection()
        {
            Items = new List<DataItem>();
        }

        public void AddItem(DataItem value)
        {
            Items.Add(value);
        }
    }
}

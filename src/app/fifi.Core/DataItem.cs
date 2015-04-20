using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataItem
    {
        public List<double> Values { get; private set; }

        public DataItem()
        {
            Values = new List<double>();
        }

        public void AddValue(double value)
        {
            Values.Add(value);
        }
    }
}

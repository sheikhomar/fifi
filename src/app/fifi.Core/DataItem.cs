using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataItem : IdentifiableDataPoint
    {
        public List<double> Values { get; private set; }
        public int Id { get; set; } //Not working atm, ID needs to be increased when a new instance is created.

        public DataItem() : base(1, 30)
        {
            Values = new List<double>();
        }

        public void AddValue(double value)
        {
            Values.Add(value);
        }
    }
}

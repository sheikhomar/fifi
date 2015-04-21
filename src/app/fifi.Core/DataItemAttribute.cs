using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataItemAttribute
    {
        public DataItemAttribute(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public double Value { get; private set; }
    }
}

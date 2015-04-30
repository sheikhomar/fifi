using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;

namespace fifi.WinUI
{
    class DataPointInfo
    {
        public Similarity Similarity { get; set; }

        public string Field { get; set; }

        public double Value { get; set; }

        public double Percent { get; set; }
    }
}

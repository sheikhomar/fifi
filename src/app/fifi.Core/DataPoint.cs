﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataPoint
    {
        public List<double> Values { get; private set; }
        public DataItem Item { get; set; }

        public DataPoint()
        {
            Values = new List<double>();
        }
    }
}

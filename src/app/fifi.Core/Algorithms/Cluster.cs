﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class Cluster
    {
        public Centroid Centroid { get; set; }
        public IList<ClusterMember> Members { get; set; }
    }
}

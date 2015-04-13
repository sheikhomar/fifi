﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class ClusterMember
    {
        public ClusterMember(Profile profile, double distance)
        {
            Profile = profile;
            Distance = distance;
        }

        public Profile Profile { get; private set; }
        public double Distance { get; private set; }
    }
}

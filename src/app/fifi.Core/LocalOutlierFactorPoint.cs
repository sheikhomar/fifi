using System;
using System.Collections.Generic;

namespace fifi.Core
{
    public class LocalOutlierFactorPoint
    {
        public List<Tuple<int, double>> DistanceToNeighbours = new List<Tuple<int, double>>();
        public double LocalReachabilityDensity;
        public double LocalOutlierFactor;
        public double KDistance;
    }
}
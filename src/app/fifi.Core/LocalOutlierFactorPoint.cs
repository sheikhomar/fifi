using System;
using System.Collections.Generic;

namespace fifi.Core
{
    public class LocalOutlierFactorPoint
    {
        public List<Tuple<int, double>> DistanceToNeighbours = new List<Tuple<int, double>>();
        public double LocalReachabilityDensity { get; set; }
        public double LocalOutlierFactor { get; set; }
        public double KDistance { get; set; }
        public int ID { get; set; }
    }
}
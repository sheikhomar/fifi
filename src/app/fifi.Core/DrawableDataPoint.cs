using System;
using fifi.Core.Algorithms;

namespace fifi.Core
{
    public class DrawableDataPoint : DataPoint
    {
        public DrawableDataPoint(Cluster cluster, double x, double y) : base(2)
        {
            Cluster = cluster;
            Group = string.Format("Cluster {0}", cluster.Id);
            X = x;
            Y = y;
        }

        public Cluster Cluster { get; private set; }
        public string Group { get; private set; }

        public double X
        {
            get { return this[0]; }
            set { this[0] = value; }
        }

        public double Y
        {
            get { return this[1]; }
            set { this[1] = value; }
        }
    }
}
using System;
using fifi.Core;

namespace fifi.Core
{
    public class DrawableDataPoint : DataPoint
    {
        public DrawableDataPoint(IdentifiableDataPoint orgin, double x, double y)
            : base(2)
        {
            Origin = orgin;
            X = x;
            Y = y;
        }

        public IdentifiableDataPoint Origin { get; private set; }

        public string Group { get; set; }

        public double X
        {
            get { return this[0]; }
            private set { this[0] = value; }
        }

        public double Y
        {
            get { return this[1]; }
            private set { this[1] = value; }
        }
    }
}
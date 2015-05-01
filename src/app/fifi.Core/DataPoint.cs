using System;

namespace fifi.Core
{
    public class DataPoint
    {
        public DataPoint(int dimensions)
        {
            if (dimensions < 1)
                throw new ArgumentException("Dimensions must be larger than zero.", "dimensions");

            Coordinates = new double[dimensions];
            Dimensions = dimensions;
        }

        public DataPoint(double[] coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException("coordinates");
            if (coordinates.Length == 0)
                throw new ArgumentException("Coordinates cannot be zero.", "coordinates");

            Coordinates = coordinates;
            Dimensions = Coordinates.Length; 
        }

        public double[] Coordinates { get; private set; }

        public int Dimensions { get; private set; }

        public double this[int index]
        {
            get
            {
                EnsureIndexIsWithinBounds(index);
                return Coordinates[index];
            }
            set
            {
                EnsureIndexIsWithinBounds(index);
                Coordinates[index] = value;
            }
        }

        /// <summary>
        /// Copies all elements from another DataPoint.
        /// </summary>
        public void CopyFrom(DataPoint another)
        {
            if (another == null)
                throw  new ArgumentNullException("another");

            if (Dimensions != another.Dimensions)
                throw new DimensionsMismatchExceptions(this, another);

            for (int i = 0; i < Dimensions; i++)
                this[i] = another[i];
        }

        public DataPoint Copy()
        {
            DataPoint dataPoint = new DataPoint(Dimensions);
            for (int i = 0; i < Dimensions; i++)
                dataPoint[i] = this[i];
            return dataPoint;
        }

        public override bool Equals(object obj)
        {
            DataPoint other = obj as DataPoint;
            if (other != null)
                return Equals(other);

            return false;
        }

        public bool Equals(DataPoint other)
        {
            if (ReferenceEquals(other, this))
                return true;

            if (other.Dimensions == Dimensions)
            {
                for (int i = 0; i < Dimensions; i++)
                {
                    if (Math.Abs(other[i] - this[i]) > 0.0000001)
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private void EnsureIndexIsWithinBounds(int index)
        {
            if (index < 0 || index >= Dimensions)
                throw new ArgumentException("Index is out of bounds.", "index");
        }
    }
}

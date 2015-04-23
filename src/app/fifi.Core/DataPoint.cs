using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataPoint
    {
        public DataPoint(int dimensions)
        {
            Coordinates = new double[dimensions];
            Dimensions = dimensions;
        }

        public DataPoint(double[] coordinates)
        {
            Coordinates = coordinates;
            Dimensions = Coordinates.Length; 
        }

        public double[] Coordinates { get; private set; }

        public int Dimensions { get; private set; }

        public double this[int index]
        {
            get { return Coordinates[index]; }
            set { Coordinates[index] = value; }
        }

        /// <summary>
        /// Copies all elements from another DataPoint.
        /// </summary>
        public void CopyFrom(DataPoint another)
        {
            if (another.Dimensions != this.Dimensions)
                throw new ArgumentException("Dimensions mismatch.", "another");

            for (int i = 0; i < this.Dimensions; i++)
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
            if (ReferenceEquals(obj, this))
                return true;

            DataPoint other = obj as DataPoint;
            if (other != null)
            {
                if (other.Dimensions == this.Dimensions)
                {
                    for (int i = 0; i < this.Dimensions; i++)
                    {
                        if (other[i] != this[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            return false;
        }
    }
}

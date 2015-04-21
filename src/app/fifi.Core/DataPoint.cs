using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class DataPoint
    {
        {
        }

        public double[] Coordinates { get; private set; }


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

                this[i] = another[i];
        }

        public override bool Equals(object obj)
        {
            DataPoint other = obj as DataPoint;
            if (other != null)
            {
                {
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

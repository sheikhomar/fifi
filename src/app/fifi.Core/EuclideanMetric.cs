using System;
using System.Collections.Generic;

namespace fifi.Core
{
    /// <summary>
    /// Represents Euclidean distance metric. 
    /// </summary>
    public class EuclideanMetric : IDistanceMetric
    {
        /// <summary>
        /// Returns the Euclidean (straight line) distance between two points in a multidimensional space.
        /// </summary>
        /// <param name="point1">The first of the two points to compare.</param>
        /// <param name="point2">The second of the two points to compare.</param>
        /// <returns>
        ///   Returns the Euclidean distance between <paramref name="point1"/> and <paramref name="point2"/>.
        /// </returns>
        public double Calculate(DataPoint point1, DataPoint point2)
        {
            // TODO: Check for array bounds / list sizes 
            if (point1.Dimensions != point2.Dimensions)
            {
                throw new DimensionsMismatchExceptions(point1, point2);
            }

            double sum = 0D;
            for (int i = 0; i < point1.Dimensions; i++)
                sum += Math.Pow(point1[i] - point2[i], 2);

            if (double.IsNaN(sum) || double.IsInfinity(sum))
            {
                throw new OverflowException("Overflow in the calculated result. Please ensure that the sum of all coordinates for each point does not exceed the square root value of a doubles' maxValue");
            }

            return Math.Sqrt(sum);
        }
    }
}

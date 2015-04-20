using System;
using System.Collections.Generic;

namespace fifi.Core.Algorithms
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
        public double Calculate(List<double> point1, List<double> point2)
        {
            // TODO: Check for array bounds / list sizes 

            double sum = 0D;
            for (int i = 0; i < point1.Count; i++)
                sum += Math.Pow(point1[i] - point2[i], 2);
            return Math.Sqrt(sum);
        }
    }
}

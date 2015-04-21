using System;
using System.Collections.Generic;

namespace fifi.Core.Algorithms
{
    /// <summary>
    /// Represents a contract for classes implementing distance metrics.
    /// </summary>
    public interface IDistanceMetric
    {
        /// <summary>
        /// Returns the distance between two points in a multidimensional space.
        /// </summary>
        /// <param name="point1">The first of the two points to compare.</param>
        /// <param name="point2">The second of the two points to compare.</param>
        /// <returns>
        ///   Returns the distance between <paramref name="point1"/> and <paramref name="point2"/>.
        /// </returns>
        double Calculate(DataPoint point1, DataPoint point2);
    }
}

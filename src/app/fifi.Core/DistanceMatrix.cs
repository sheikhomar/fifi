using System;
using System.Collections.Generic;
using System.Linq;

namespace fifi.Core
{
    /// <summary>
    /// Represents a distance matrix.
    /// </summary>
    public class DistanceMatrix : Matrix
    {
        private readonly IDistanceMetric distanceMetric;
        private readonly IEnumerable<DataPoint> dataCollection;

        public DistanceMatrix(IEnumerable<DataPoint> input, IDistanceMetric distanceMetric)
            : base(input.Count(), input.Count())
        {
            if (distanceMetric == null)
                throw new ArgumentNullException("distanceMetric");
            this.distanceMetric = distanceMetric;
            dataCollection = input;
            CalculateEntries();
        }

        private void CalculateEntries()
        {
            DataPoint[] dataPoints = dataCollection.ToArray();
            int size = dataPoints.Length;
            double distance;

            for (int row = 0, columnOffset = 1; row < size; row++, columnOffset++)
			{
                for (int column = columnOffset; column < size; column++)
			    {
                    distance = distanceMetric.Calculate(dataPoints[row], dataPoints[column]);
                    this[row, column] = distance;
                    this[column, row] = distance;
			    }
			}
        }
    }
}

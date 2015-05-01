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
        private readonly IList<DataPoint> dataPointList;

        public DistanceMatrix(IEnumerable<DataPoint> input, IDistanceMetric distanceMetric)
            : base(input.Count(), input.Count())
        {
            if (distanceMetric == null)
                throw new ArgumentNullException("distanceMetric");
            this.distanceMetric = distanceMetric;
            dataPointList = input.ToList();
            CalculateEntries();
        }

        public DataPoint GetObject(int index)
        {
            if (index < 0 && index > dataPointList.Count)
                throw new ArgumentOutOfRangeException("index", "Index is out of range.");

            return dataPointList[index];
        }

        private void CalculateEntries()
        {
            int size = dataPointList.Count;
            double distance;

            for (int row = 0, columnOffset = 1; row < size; row++, columnOffset++)
			{
                for (int column = columnOffset; column < size; column++)
			    {
                    distance = distanceMetric.Calculate(dataPointList[row], dataPointList[column]);
                    this[row, column] = distance;
                    this[column, row] = distance;
			    }
			}
        }
    }
}

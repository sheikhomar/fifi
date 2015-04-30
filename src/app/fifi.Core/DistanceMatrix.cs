using System;
using fifi.Core;

namespace fifi.Core
{
    public class DistanceMatrix : Matrix
     {
        private readonly IDistanceMetric distanceMetric;
        private readonly IdentifiableDataPointCollection dataCollection;

        public DistanceMatrix(IdentifiableDataPointCollection input, IDistanceMetric distanceMetric) : base (input.Count, input.Count)
        {
            if (distanceMetric == null)
                throw new ArgumentNullException("distanceMetric");
            this.distanceMetric = distanceMetric;
            dataCollection = input;
            CalculateEntries();
        }

        private void CalculateEntries()
        {
            int dataCollectionSize = dataCollection.Count;
            double distance;

            for (int row = 0, columnOffset = 1; row < dataCollectionSize; row++, columnOffset++)
			{
                for (int column = columnOffset; column < dataCollectionSize; column++)
			    {
                    distance = distanceMetric.Calculate(dataCollection[row], dataCollection[column]);
                    this[row, column] = distance;
                    this[column, row] = distance;
			    }
			}
        }
    }
}

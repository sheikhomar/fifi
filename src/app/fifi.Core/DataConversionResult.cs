using System.Collections.Generic;

namespace fifi.Core
{
    public class DataConversionResult
    {
        public DataConversionResult(IList<DrawableDataPoint> dataPoints, DistanceMatrix distanceMatrix)
        {
            DataPoints = dataPoints;
            DistanceMatrix = distanceMatrix;
        }

        public IList<DrawableDataPoint> DataPoints { get; private set; }
        public DistanceMatrix DistanceMatrix { get; private set; }
    }
}
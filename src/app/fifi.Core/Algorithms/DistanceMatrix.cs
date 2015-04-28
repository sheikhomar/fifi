using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class DistanceMatrix : Matrix
     {
        private IDistanceMetric distanceMetric;
        private IdentifiableDataPointCollection dataCollection;
        private Matrix matrix;

        public DistanceMatrix(IdentifiableDataPointCollection input, IDistanceMetric distanceMetric) : base (input.Count, input.Count)
        {
            if (distanceMetric == null)
                throw new ArgumentNullException("Can't create DistanceMatrix on empty IDistanceMetric!");
            this.distanceMetric = distanceMetric;
            dataCollection = input;
            matrix = GenerateMatrix();
        }

        public Matrix GenerateMatrix()
        {
            return calculatedMatrix(dataCollection);
        }

        private Matrix calculatedMatrix(IdentifiableDataPointCollection dataCollection)
        {
            int dataCollectionSize = dataCollection.Count;
            Matrix matrix = new Matrix(dataCollectionSize, dataCollectionSize);
            double distance;

            for (int row = 0, columnOffset = 1; row < dataCollectionSize; row++, columnOffset++)
			{
                for (int column = columnOffset; column < dataCollectionSize; column++)
			    {
                    distance = distanceMetric.Calculate(dataCollection[row], dataCollection[column]);
                    matrix[row, column] = distance;
                    matrix[column, row] = distance;
			    }
			}

            return matrix;
        }
    }
}

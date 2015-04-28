using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core.Algorithms
{
    public class DistanceMatrix
    {
        private IDistanceMetric distanceMetric;
        private IdentifiableDataPointCollection dataCollection;
        private Matrix matrix;

        public DistanceMatrix(IdentifiableDataPointCollection input, IDistanceMetric distanceMetric)
        {
            if (input == null)
                throw new ArgumentNullException("Can't create DistanceMatrix on empty IdentifiableDataPointCollection!");
            else if (distanceMetric == null)
                throw new ArgumentNullException("Can't create DistanceMatrix on empty IDistanceMetric!");
            else if (input.Count<IdentifiableDataPoint>() <= 0)
                throw new IndexOutOfRangeException("To many members on the list or 0, it has to be in the range of int and larger than 0");
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

            for (int row = 0, collumOffset = 1; row < dataCollectionSize; row++, collumOffset++)
			{
                for (int collum = collumOffset; collum < dataCollectionSize; collum++)
			    {
                    distance = distanceMetric.Calculate(dataCollection[row], dataCollection[collum]);
                    matrix[row, collum] = distance;
                    matrix[collum, row] = distance;
			    }
			}

            return matrix;
        }
    }
}

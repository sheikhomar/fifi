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
        IdentifiableDataPointCollection dataCollection;
        Matrix matrix;

        public DistanceMatrix(IdentifiableDataPointCollection input, IDistanceMetric distanceMetric)
        {
            this.distanceMetric = distanceMetric;
            this.dataCollection = input;
            this.matrix = GenerateMatrix();
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

            //Nulling the matrix
            for (int i = 0; i < dataCollectionSize; i++)
			{
                matrix[i, i] = 0D;
			}

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

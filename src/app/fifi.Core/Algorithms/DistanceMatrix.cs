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
        DataCollection dataCollection;
        double[,] matrix;

        public DistanceMatrix(DataCollection input, IDistanceMetric distanceMetric)
        {
            this.distanceMetric = distanceMetric;
            this.dataCollection = input;
            this.matrix = GenerateMatrix();
        }


        public double[,] GenerateMatrix()
        {
            return calculatedMatrix(dataCollection);
        }


        private double[,] calculatedMatrix(DataCollection dataCollection)
        {
            int dataCollectionSize = dataCollection.Items.Count;
            double[,] matrix = new double[dataCollectionSize, dataCollectionSize];
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
                    distance = distanceMetric.Calculate(dataCollection.Items[row].Values, dataCollection.Items[collum].Values);
                    matrix[row, collum] = distance;
                    matrix[collum, row] = distance;
			    }
			}

            return matrix;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    public class MultiDimensionalScaling2
    {
        Matrix matrix;

        public MultiDimensionalScaling2(double[,] data)
        {
            matrix = new Matrix(data.GetLength(0), data.GetLength(1));
            matrix.GetSetMatrix = data;
        }

        public double[,] Calculate()
        {
            matrix.SquaredValues();
            Matrix jMatrix = JMatrixGenerator();
            Matrix scalarProductMatrix = ScalarProductMatrixGenerator(jMatrix);
            return scalarProductMatrix.EigenGenerator().GetSetMatrix;
        }

        private Matrix JMatrixGenerator()
        {
            double dimensionScaling = Math.Pow(matrix.FirstDimension, -1);
            Matrix jMatrix = new Matrix(matrix.FirstDimension, matrix.SecondDimension);
            Matrix identityMatrix = matrix.IdentityMatrixGenerator(matrix.FirstDimension);
            Matrix oneMatrix = matrix.OnesMatrixGenerator(matrix.FirstDimension);

            for (int row = 0; row < matrix.FirstDimension; row++)
            {
                for (int col = 0; col < matrix.SecondDimension; col++)
                {
                    jMatrix[row, col] = identityMatrix[row, col] - (oneMatrix[row, col] * dimensionScaling);
                }
            }
            return jMatrix;
        }

        private Matrix ScalarProductMatrixGenerator(Matrix jMatrix)
        {
            Matrix resultMatrix = new Matrix(matrix.FirstDimension, matrix.SecondDimension);

            for (int row = 0; row < matrix.FirstDimension; row++)
            {
                for (int col = 0; col < matrix.SecondDimension; col++)
                {
                    resultMatrix[row, col] = -(0.5) * jMatrix[row, col];
                }
            }
            resultMatrix = MatrixMultiplier(resultMatrix, matrix);
            resultMatrix = MatrixMultiplier(resultMatrix, jMatrix);
            return resultMatrix;
        }

        private Matrix MatrixMultiplier(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix(firstMatrix.FirstDimension, secondMatrix.SecondDimension);

            for (int row = 0; row < resultMatrix.FirstDimension; row++)
            {
                for (int col = 0; col < resultMatrix.SecondDimension; col++)
                {
                    for (int inner = 0; inner < resultMatrix.FirstDimension; inner++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, inner] * secondMatrix[inner, col];
                    }
                }
            }
            return resultMatrix;
        }
    }
}

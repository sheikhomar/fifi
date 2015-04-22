using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace fifi.Core
{
    public class MultiDimensionalScaling
    {
        Matrix matrix;

        public MultiDimensionalScaling(double[,] data)
        {
            matrix = new Matrix(data.GetLength(0), data.GetLength(1));
            matrix.GetSetMatrix = data;
        }

        public double[,] Calculate()
        {
            matrix.SquaredValues();
            Matrix jMatrix = JMatrixGenerator();
            Matrix scalarProductMatrix = ScalarProductMatrixGenerator(jMatrix);
            return TwoDCoordinateGenerator(scalarProductMatrix).GetSetMatrix;
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

        private Matrix TwoDCoordinateGenerator(Matrix scalarProductMatrix)
        {
            Matrix<double> convertedMatrix = DenseMatrix.OfArray(scalarProductMatrix.GetSetMatrix);
            var eigenInfo = convertedMatrix.Evd();

            /* Eigenvalue calculator */
            double[] eigenvalueArray = eigenInfo.EigenValues.Select(x => x.Real).ToArray();
            Tuple<int, int> largestTwoEigenvalues = FindLargestTwoEigenvalues(eigenvalueArray);
            double[,] eigenvalueMatrixUnconverted = { { Math.Sqrt(eigenvalueArray[largestTwoEigenvalues.Item1]), 0 }, { 0, Math.Sqrt(eigenvalueArray[largestTwoEigenvalues.Item2]) } };
            Matrix<double> eigenvalueMatrix = Matrix<double>.Build.DenseOfArray(eigenvalueMatrixUnconverted);

            /* Eigenvector calculator */
            Matrix<double> eigenvectorMatrix = Matrix<double>.Build.Dense(2, matrix.SecondDimension);
            double[] firstEigenvector = eigenInfo.EigenVectors.Column(largestTwoEigenvalues.Item1).ToArray();
            double[] secondEigenvector = eigenInfo.EigenVectors.Column(largestTwoEigenvalues.Item2).ToArray();
            double[] eigenvector = firstEigenvector;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < eigenvectorMatrix.ColumnCount; col++)
                {
                    eigenvectorMatrix[row, col] = eigenvector[col];
                }
                eigenvector = secondEigenvector;
            }

            Matrix resultMatrix = new Matrix(eigenvalueMatrix.RowCount, eigenvectorMatrix.ColumnCount);
            resultMatrix.GetSetMatrix = eigenvalueMatrix.Multiply(eigenvectorMatrix).ToArray();
            return resultMatrix;
        }

        private Tuple<int, int> FindLargestTwoEigenvalues(double[] valueArray)
        {
            int largestValue = 0, secondLargestValue = 1;
            int counter = 1;
            while (counter < valueArray.Length)
            {
                if (valueArray[counter] > valueArray[secondLargestValue])
                    secondLargestValue = counter;
                else if (valueArray[counter] >= valueArray[largestValue])
                {
                    secondLargestValue = largestValue;
                    largestValue = counter;
                }
                counter++;
            }
            Tuple<int, int> result = new Tuple<int, int>(largestValue, secondLargestValue);
            return result;
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

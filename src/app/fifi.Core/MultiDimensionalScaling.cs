using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace fifi.Core
{
    public class MultiDimensionalScaling
    {
        private Matrix matrix;

        public MultiDimensionalScaling(Matrix data)
        {
            if (data.Rows != data.Columns)
                throw new RankException("Can't run MDS. The inserted matrix have to be an n x n matrix.");
            matrix = new Matrix(data.Rows, data.Columns);
            matrix = data;
        }

        public Matrix Calculate()
        {
            matrix.SquaredValues();
            Matrix jMatrix = JMatrixGenerator();
            Matrix scalarProductMatrix = ScalarProductMatrixGenerator(jMatrix);
            return TwoDCoordinateGenerator(scalarProductMatrix);
        }

        private Matrix JMatrixGenerator()
        {
            double dimensionScaling = Math.Pow(matrix.Rows, -1);
            Matrix jMatrix = new Matrix(matrix.Rows, matrix.Columns);
            Matrix identityMatrix = matrix.IdentityMatrixGenerator(matrix.Rows);
            Matrix oneMatrix = matrix.OnesMatrixGenerator(matrix.Rows);

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
                {
                    jMatrix[row, col] = identityMatrix[row, col] - (oneMatrix[row, col] * dimensionScaling);
                }
            }
            return jMatrix;
        }

        private Matrix ScalarProductMatrixGenerator(Matrix jMatrix)
        {
            Matrix resultMatrix = new Matrix(matrix.Rows, matrix.Columns);

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Columns; col++)
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
            Matrix<double> convertedMatrix = DenseMatrix.OfArray(scalarProductMatrix.GetMatrix);
            var eigenInfo = convertedMatrix.Evd();

            /* Eigenvalue calculator */
            double[] eigenvalueArray = eigenInfo.EigenValues.Select(x => x.Real).ToArray();
            Tuple<int, int> largestTwoEigenvalues = FindLargestTwoEigenvalues(eigenvalueArray);
            double[,] eigenvalueMatrixUnconverted = { { Math.Sqrt(eigenvalueArray[largestTwoEigenvalues.Item1]), 0 }, { 0, Math.Sqrt(eigenvalueArray[largestTwoEigenvalues.Item2]) } };
            Matrix<double> eigenvalueMatrix = Matrix<double>.Build.DenseOfArray(eigenvalueMatrixUnconverted);

            /* Eigenvector calculator */
            Matrix<double> eigenvectorMatrix = Matrix<double>.Build.Dense(2, matrix.Columns);
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

            Matrix resultMatrix = new Matrix(eigenvalueMatrix.Multiply(eigenvectorMatrix).ToArray());
            return resultMatrix;
        }

        private Tuple<int, int> FindLargestTwoEigenvalues(double[] valueArray)
        {
            int largestValue = 0, secondLargestValue = 1;
            int counter = 1;
            while (counter < valueArray.Length)
            {
                if (valueArray[counter] >= valueArray[largestValue])
                {
                    secondLargestValue = largestValue;
                    largestValue = counter;
                }
                else if (valueArray[counter] > valueArray[secondLargestValue])
                    secondLargestValue = counter;
                counter++;
            }
            Tuple<int, int> result = new Tuple<int, int>(largestValue, secondLargestValue);
            return result;
        }

        private Matrix MatrixMultiplier(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix(firstMatrix.Rows, secondMatrix.Columns);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Columns; col++)
                {
                    for (int inner = 0; inner < resultMatrix.Rows; inner++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, inner] * secondMatrix[inner, col];
                    }
                }
            }
            return resultMatrix;
        }
    }
}

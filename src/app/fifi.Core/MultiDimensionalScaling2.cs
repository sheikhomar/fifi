using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using System.Windows.Forms.DataVisualization.Charting;
using CDataPoint = System.Windows.Forms.DataVisualization.Charting.DataPoint;

namespace fifi.Core
{
    public class MultiDimensionalScaling2
    {
        List<CDataPoint> L = new List<CDataPoint>();
        Matrix matrix;

        public MultiDimensionalScaling2(double[,] data)
        {
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

        /*private double[,] eigenCalculator(double[,] scalarProductMatrix)
        {
            var convertedMatrix = DenseMatrix.OfArray(scalarProductMatrix);
            var eigen = convertedMatrix.Evd();

            double[] valueArray = eigen.EigenValues.Select(x => x.Real).ToArray();
            Tuple<int, int> largestValueIndex = findLargestValueIndex(valueArray);
            double[,] valueResult = { { Math.Sqrt(valueArray[largestValueIndex.Item1]), 0 }, { 0, Math.Sqrt(valueArray[largestValueIndex.Item2]) } };

            double[,] vectorArray = eigen.EigenVectors.ToArray();
            double[,] vectorResult = new double[2, scalarProductMatrix.GetLength(0)];

            for (int row = 0; row < vectorArray.GetLength(0); row++)
            {
                for (int col = 0; col < vectorArray.GetLength(0); col++)
                {
                    if (largestValueIndex.Item1 == col)
                        vectorResult[0, row] = vectorArray[row, col];
                    else if (largestValueIndex.Item2 == col)
                        vectorResult[1, row] = vectorArray[row, col];
                }
            }

            var valueResultMatrix = DenseMatrix.OfArray(valueResult);
            var vectorResultMatrix = DenseMatrix.OfArray(vectorResult);
            var ResultMatrix = valueResultMatrix.Multiply(vectorResultMatrix);
            double[,] returnResult = ResultMatrix.ToArray();
            double[,] final = new double[returnResult.GetLength(0), returnResult.GetLength(1)];

            for (int row = 0; row < returnResult.GetLength(0); row++)
            {
                for (int col = 0; col < returnResult.GetLength(1); col++)
                {
                    final[row, col] = returnResult[row, col];
                }
            }

            return final;
        }*/
    }
}

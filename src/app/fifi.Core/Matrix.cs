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
    class Matrix
    {
        double[,] matrix;

        public Matrix(int row, int colum)
        {
            matrix = new double[row, colum];
        }

        public double this[int row, int colum]
        {
            get {return matrix[row, colum]; }
            set {matrix[row, colum] = value; }
        }

        public double[,] GetSetMatrix 
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public int GetLengthOfDim(int dimension, double[,] defaultMatrix)
        {
            return defaultMatrix.GetLength(dimension);
        }

        public int FirstDimension 
        {
            get { return matrix.GetLength(0); } 
        }

        public int SecondDimension
        {
            get { return matrix.GetLength(1); }
        }

        public void SquaredValues()
        {
            for (int row = 0; row < FirstDimension; row++)
            {
                for (int col = 0; col < SecondDimension; col++)
                {
                    matrix[row, col] *= matrix[row, col];
                }
            }
        }

        public Matrix EigenGenerator()
        {
            var convertedMatrix = DenseMatrix.OfArray(matrix);
            var eigenInfo = convertedMatrix.Evd();
            
            Tuple<int, int> largestTwoEigenvalues = FindLargestTwoEigenvalues(eigenInfo.EigenValues.Select(x => x.Real).ToArray());
            //double[,] eigenvalueMatrix2 = { { Math.Sqrt(largestEigenvalues.Item1), 0 }, { 0, Math.Sqrt(largestEigenvalues.Item2) } };
            double[] eigenvalueMatrixInput = { Math.Sqrt(largestTwoEigenvalues.Item1), 0, 0, Math.Sqrt(largestTwoEigenvalues.Item2) };
            Matrix eigenvalueMatrix = GenerateFullSquaredCustomMatrix(eigenvalueMatrixInput);
            
            double[,] vectorArray = eigenInfo.EigenVectors.ToArray();
            double[,] vectorResult = new double[2, matrix.GetLength(1)];

            for (int row = 0; row < vectorArray.GetLength(0); row++)
            {
                for (int col = 0; col < vectorArray.GetLength(0); col++)
                {
                    if (largestTwoEigenvalues.Item1 == col)
                        vectorResult[0, row] = vectorArray[row, col];
                    else if (largestTwoEigenvalues.Item2 == col)
                        vectorResult[1, row] = vectorArray[row, col];
                }
            }

            var valueResultMatrix = DenseMatrix.OfArray(eigenvalueMatrix.GetSetMatrix);
            var vectorResultMatrix = DenseMatrix.OfArray(vectorResult);
            var ResultMatrix = valueResultMatrix.Multiply(vectorResultMatrix);
            double[,] returnResult = ResultMatrix.ToArray();
            Matrix final = new Matrix(returnResult.GetLength(0), returnResult.GetLength(1));

            for (int row = 0; row < returnResult.GetLength(0); row++)
            {
                for (int col = 0; col < returnResult.GetLength(1); col++)
                {
                    final[row, col] = returnResult[row, col];
                }
            }
            return final;
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

        public Matrix IdentityMatrixGenerator(int size)
        {
            Matrix customMatrix = new Matrix(size, size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == col)
                        customMatrix[row, col] = 1;
                    else
                        customMatrix[row, col] = 0;
                }
            }
            return customMatrix;
        }

        public Matrix OnesMatrixGenerator(int size)
        {
            Matrix customMatrix = new Matrix(size, size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    customMatrix[row, col] = 1;
                }
            }
            return customMatrix;
        }

        private Matrix GenerateFullSquaredCustomMatrix(double[] inputValues)
        {
            Matrix returnMatrix = new Matrix(inputValues.Length / 2, inputValues.Length / 2);
            for (int row = 0, inputValueCounter = 0; row < inputValues.Length / 2; row++)
            {
                for (int col = 0; col < inputValues.Length / 2; col++, inputValueCounter++)
                {
                    returnMatrix[row, col] = inputValues[inputValueCounter];
                }
            }
            return returnMatrix;
        }
    }
}
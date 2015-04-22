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
        double[,] distanceMatrix;
        double[,] squaredMatrix;
        double[,] jMatrix;
        double[,] scalarProductMatrix;
        double[,] result;
        
        public MultiDimensionalScaling(double[,] data)
        {
            distanceMatrix = data;
        }
        
        public double[,] Calculate()
        {
            squaredMatrix = squaredDistanceMatrix(distanceMatrix);
            jMatrix = jMatrixCalculator(squaredMatrix);
            scalarProductMatrix = scalarProductMatrixCalculator(squaredMatrix, jMatrix);
            result = eigenCalculator(scalarProductMatrix);
            return result;
        }

        private double[,] squaredDistanceMatrix(double[,] distanceMatrix)
        {
            for (int row = 0; row < distanceMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < distanceMatrix.GetLength(1); col++)
                {
                    distanceMatrix[row, col] *= distanceMatrix[row, col];
                }
            }
            return distanceMatrix;
        }

        private double[,] jMatrixCalculator(double[,] squaredMatrix)
        {
            double[,] identityMatrix = identityMatrixGenerator(squaredMatrix.GetLength(1));
            double[,] tempJMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double[,] oneMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double dimensionScaling = Math.Pow(squaredMatrix.GetLength(0), -1);

            for (int row = 0; row < squaredMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squaredMatrix.GetLength(1); col++)
                {
                    oneMatrix[row, col] = 1;
                }
            }

            for (int row = 0; row < squaredMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squaredMatrix.GetLength(1); col++)
                {
                    tempJMatrix[row, col] = identityMatrix[row, col] - (oneMatrix[row, col] * dimensionScaling);
                }
            }
            return tempJMatrix;
        }

        private double[,] scalarProductMatrixCalculator(double[,] squaredMatrix, double[,] jMatrix)
        {
            double [,] tempScalarProductMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double [,] tempArray = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];

            for (int row = 0; row < squaredMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squaredMatrix.GetLength(1); col++)
                {
                    tempScalarProductMatrix[row, col] = -(0.5) * jMatrix[row, col];
                }
            }
            tempArray = matrixMultiplier(tempScalarProductMatrix, squaredMatrix);
            tempScalarProductMatrix = matrixMultiplier(tempArray, jMatrix);
            return tempScalarProductMatrix;
        }

        private Tuple<int, int> findLargestValueIndex(double[] valueArray)
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

        private double[,] eigenCalculator(double[,] scalarProductMatrix)
        {
            var convertedMatrix = DenseMatrix.OfArray(scalarProductMatrix);
            var eigen = convertedMatrix.Evd();

            double[] valueArray = eigen.EigenValues.Select(x => x.Real).ToArray();
            Tuple<int, int> largestValueIndex = findLargestValueIndex(valueArray);
            double[,] valueResult = { {Math.Sqrt(valueArray[largestValueIndex.Item1]), 0}, {0, Math.Sqrt(valueArray[largestValueIndex.Item2])} };

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
        }

        private double[,] matrixMultiplier(double[,] matrixA, double[,] matrixB) 
        {
            double[,] resultMatrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];

            for (int row = 0; row < matrixA.GetLength(0); row++)
            {
                for (int col = 0; col < matrixA.GetLength(1); col++)
                {
                    for (int inner = 0; inner < matrixA.GetLength(0); inner++)
                    {
                        resultMatrix[row, col] += matrixA[row, inner] * matrixB[inner, col];
                    }
                }
            }
            return resultMatrix;
        }

        private double[,] identityMatrixGenerator(int size)
        {
            double[,] identityMatrix = new double[size, size];

            for (int row = 0; row < squaredMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squaredMatrix.GetLength(1); col++)
                {
                    if (row == col)
                        identityMatrix[row, col] = 1;
                    else
                        identityMatrix[row, col] = 0;
                }
            }
            return identityMatrix;
        }
    }
}

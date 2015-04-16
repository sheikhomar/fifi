using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    class MDS
    {
        double[,] distanceMatrix;
        double[,] squaredMatrix;
        double[,] jMatrix;
        double[,] scalarProductMatrix;
        
        
        public MDS(double[,] data)
        {
            distanceMatrix = data;
        }
        
        public void Run()
        {
            squaredMatrix = squaredDistanceMatrix(distanceMatrix);
            jMatrix = jMatrixCalculator(squaredMatrix);
            scalarProductMatrix = scalarProductMatrixCalculator(squaredMatrix, jMatrix);

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
            double[,] identityMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double[,] tempJMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double[,] oneMatrix = new double[squaredMatrix.GetLength(0), squaredMatrix.GetLength(1)];
            double dimensionScaling = Math.Pow(squaredMatrix.GetLength(0), -1);

            for (int row = 0; row < squaredMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < squaredMatrix.GetLength(1); col++)
                {
                    if (row == col)
                        identityMatrix[row, col] = 1; 
                    else
                        identityMatrix[row, col] = 0;

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
                    tempScalarProductMatrix[row, col] = -(1 / 2) * jMatrix[row, col];
                }
            }
            tempArray = matrixMultiplier(tempScalarProductMatrix, squaredMatrix);
            tempScalarProductMatrix = matrixMultiplier(tempArray, jMatrix);
            return tempScalarProductMatrix;
        }

        private double[,] matrixMultiplier(double[,] matrixA, double[,] matrixB) 
        {
            double[,] resultMatrix = new double[matrixA.GetLength(0), matrixA.GetLength(1)];

            for (int row = 0; row < matrixA.GetLength(0); row++)
            {
                for (int col = 0; col < matrixA.GetLength(1); col++)
                {
                    for (int inner = 0; inner < matrixA.GetLength(1); inner++)
                    {
                        resultMatrix[row, col] += matrixA[row, inner] * matrixB[inner, col];
                    }
                }
            }
            return resultMatrix;
        }
    }
}

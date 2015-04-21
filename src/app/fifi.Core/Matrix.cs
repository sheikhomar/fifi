using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
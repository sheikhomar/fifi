using System;

namespace fifi.Core
{
    public class Matrix
    {
        private double[,] matrix;

        public Matrix(int row, int column)
        {
            if (row <= 0 || column <= 0)
            {
                throw new ArgumentException("Cannot create a matrix with 0 or less columns and rows");
            }
            
            matrix = new double[row, column];
        }

        public Matrix(double[,] setmatrix)
        {
            matrix = setmatrix;
        }

        public double this[int row, int colum]
        {
            get {return matrix[row, colum]; }
            set {matrix[row, colum] = value; }
        }

        public double[,] GetMatrix { get { return matrix; } }

        public int Rows 
        {
            get { return matrix.GetLength(0); } 
        }

        public int Columns
        {
            get { return matrix.GetLength(1); }
        }

        public void SquaredValues()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
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
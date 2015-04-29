using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Row 
        {
            get { return matrix.GetLength(0); } 
        }

        public int Column
        {
            get { return matrix.GetLength(1); }
        }

        public void SquaredValues()
        {
            for (int row = 0; row < Row; row++)
            {
                for (int col = 0; col < Column; col++)
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
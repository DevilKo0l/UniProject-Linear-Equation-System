using System;

namespace Linear_Equation_System
{
    internal class Calculator
    {
        private int nRow, nCol;
        public double[,] matrix;

        public Calculator(double[,] newMatrix)
        {
            matrix = newMatrix;
            nRow = matrix.GetLength(0);
            nCol = matrix.GetLength(1);
        }

        public double[,] ForwardEliminationMatrix()
        {
            //handle the row
            for (int i = 0; i < nRow; i++)
            {
                //handle row+1
                for (int j = i + 1; j < nRow; j++)
                {
                    double factor = matrix[j, i] / matrix[i, i];

                    for (int k = i; k < nCol; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }
                }
            }
            return matrix;
        }

        public double[] GetRoot()
        {
            ForwardEliminationMatrix();
            Pivoting();
            return BackwardsSubstitution();
        }

        public double[] BackwardsSubstitution()
        {
            double[] result = new double[nRow];
            //handle row from bottom to top
            for (int i = nRow - 1; i >= 0; i--)
            {
                result[i] = matrix[i, nCol - 1];
                for (int j = i + 1; j <= nRow - 1; j++)
                {
                    result[i] -= matrix[i, j] * result[j];
                }
                result[i] = result[i] / matrix[i, i];
            }
            return result;
        }

        private void SwapRow(int rowA, int rowB)
        {
            double[] temp = new double[nCol];
            for (int i = 0; i < nCol; i++)
            {
                temp[i] = matrix[rowA, i];
                matrix[rowA, i] = matrix[rowB, i];
                matrix[rowB, i] = temp[i];
            }
        }

        public void Pivoting()
        {
            //control column
            for (int i = 0; i < nCol - 1; i++)
            {
                //control row
                double highestPivot = matrix[i, i];
                for (int j = i + 1; j < nRow; j++)
                {
                    if (matrix[j, i] > highestPivot && matrix[j, i] != 0)
                    {
                        highestPivot = matrix[j, i];
                        SwapRow(i, j);
                    }
                }
            }
        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    Console.Write("{0}  ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
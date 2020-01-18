using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Equation_System
{
    class GaussianElimination
    {
        
        private double[,] ForwardEliminationMatrix(double[,] matrix)
        {
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
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
        
        public double[] BackwardsSubstitution(double[,] matrix)
        {
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
            double[] result = new double[nRow];
            double[,] newMatrix = ForwardEliminationMatrix(matrix);
            //handle row from bottom to top
            for (int i = nRow - 1; i >= 0; i--)
            {
                result[i] = newMatrix[i, nCol - 1];
                for (int j = i + 1; j <= nRow - 1; j++)
                {
                    result[i] -= newMatrix[i, j] * result[j];
                }
                result[i] = result[i] / newMatrix[i, i];

            }
            return result;
        }
    }
}

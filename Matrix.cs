using System;

namespace Linear_Equation_System
{
    public class Matrix
    {
        public int nRow, nCol;
        public double[,] matrix;

        public Matrix(int newRow, int newCol)
        {
            nRow = newRow;
            nCol = newCol;
            matrix = new double[nRow, nCol];
        }

        public double[,] SetLinearEquationMatrix()
        {
            for (int i = 0; i < nRow; i++)
            {
                Console.WriteLine("\nEnter coefficient for Eq #{0}: ", i + 1);
                int input;
                for (int j = 0; j < nCol; j++)
                {
                    Console.Write("Coefficient #{0}: ", j + 1);
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.Write("Please enter cofficient #{0} again: ", j + 1);
                    }
                    matrix[i, j] = input;
                }
            }
            return matrix;
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
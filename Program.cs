using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Equation_System
{   
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Type linear equations in augmented matrix notation: a1 a2 ... all d,");
            Console.WriteLine("          where a1...N are coefficients and d is constant");
            Console.Write("\nHow many equations do you want to enter: ");

            
            double[,] matrix = LinearEquationMatrix(4);
            DisplayEquation(matrix);
            double[,] forwardElimination = ForwardEliminationMatrix(matrix);
            DisplayMatrix(forwardElimination);
           
            DisplayResult(BackwardsSubstitution(forwardElimination));
            
            
        }

        static public double[] BackwardsSubstitution(double[,] matrix)
        {
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
            double[] result = new double[nRow];
            //handle row from bottom to top
            for (int i = nRow-1; i >= 0; i--)
            {
                result[i] = matrix[i, nCol - 1];
                for (int j = i+1; j <=nRow-1; j++)
                {
                    result[i] -= matrix[i, j] * result[j];
                }
                result[i] = result[i] / matrix[i, i];

            }
            return result;
        }
        static public double[,] ForwardEliminationMatrix(double[,] matrix)
        {
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
            //handle the row
            for (int i = 0; i < nRow; i++)
            {
                //handle row+1
                for (int j = i+1; j < nRow; j++)
                {
                    double factor = matrix[j,i] / matrix[i, i];                    
                    
                    for (int k = i; k < nCol; k++)
                    {
                        matrix[j,k] -= factor * matrix[i,k];
                    }
                    
                }
            }
            return matrix;
        }
        static public double[,] LinearEquationMatrix(int row)
        {
            int col = row + 1;
            double[,] matrix = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("\nEnter coefficient for Eq #{0}: ",i+1);
                int input;
                for (int j = 0; j < col; j++)
                {
                    Console.Write("Coefficient #{0}: ", j+1);
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.Write("Please enter cofficient #{0} again: ",j+1);
                    }
                    matrix[i, j] = input;
                }
            }

            return matrix;
        }
        static public void DisplayMatrix(double[,] matrix)
        {
            Console.WriteLine("\nForward elimination");
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
            for (int i = 0; i < nRow; i++)
            {
                for (int j = 0; j < nCol; j++)
                {
                    Console.Write("{0} ",matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        static public void DisplayResult(double[] resultArray)
        {
            Console.WriteLine("\nResult: ");
            int numX = resultArray.Length;
            for (int i = 0; i < numX; i++)
            {
                Console.WriteLine("X{0}: {1}",i+1,resultArray[i]);
            }
        }

        static public void DisplayEquation(double[,] matrix)
        {
            Console.Clear();
            int nRow = matrix.GetLength(0);
            int nCol = matrix.GetLength(1);
            string[] variableArray = Enumerable.Repeat("X", nCol).ToArray();
            Console.WriteLine("\nYou have entered the following equation:");
            for (int i = 0; i < nRow; i++)
            {
                Console.Write("Eq #{0}: ",i+1);
                for (int j = 0; j < nCol; j++)
                {
                    if (matrix[i,j] > 0 && j<(nCol-1) && j>0)
                    {
                        Console.Write("+ {0}*{1}{2} ", matrix[i, j], "X", j+1);
                    }
                    if (matrix[i, j] < 0 && j < (nCol - 1) && j > 0)
                    {
                        Console.Write("- {0}*{1}{2} ", Math.Abs(matrix[i, j]), "X", j + 1);
                    }

                    if (j == 0)
                    {
                        Console.Write("{0}*{1}{2} ", matrix[i, j], "X", j + 1);
                    }
                    
                    if(j == (nCol - 1))
                    {
                        Console.Write("= {0}", matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}


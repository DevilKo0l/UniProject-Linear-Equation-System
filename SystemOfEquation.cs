using System;
using System.Linq;

namespace Linear_Equation_System
{
    internal class SystemOfEquation : Matrix
    {
        private readonly Calculator _calculate;

        public SystemOfEquation(int newNumberOfEquation, int newNumberOfUnknown)
            : base(newNumberOfEquation, newNumberOfUnknown)
        {
            _calculate = new Calculator(matrix);
        }

        public double[] GetRoot()
        {
            _calculate.ForwardEliminationMatrix();
            _calculate.Pivoting();
            return _calculate.BackwardsSubstitution();
        }

        public void DisplayEquation()
        {
            Console.Clear();
            string[] variableArray = Enumerable.Repeat("X", nCol).ToArray();
            Console.WriteLine("You have entered the following equation:");
            for (int i = 0; i < nRow; i++)
            {
                Console.Write("Eq #{0}: ", i + 1);
                for (int j = 0; j < nCol; j++)
                {
                    if (matrix[i, j] > 0 && j < (nCol - 1) && j > 0)
                    {
                        Console.Write("+ {0}*{1}{2} ", matrix[i, j], "X", j + 1);
                    }
                    if (matrix[i, j] < 0 && j < (nCol - 1) && j > 0)
                    {
                        Console.Write("- {0}*{1}{2} ", Math.Abs(matrix[i, j]), "X", j + 1);
                    }

                    if (j == 0)
                    {
                        Console.Write("{0}*{1}{2} ", matrix[i, j], "X", j + 1);
                    }

                    if (j == (nCol - 1))
                    {
                        Console.Write("= {0}", matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayRoot()
        {
            var result = GetRoot();
            Console.WriteLine("\nResult: ");
            int numX = GetRoot().Length;
            for (int i = 0; i < numX; i++)
            {
                Console.WriteLine("X{0}: {1}", i + 1, result[i]);
            }
        }
    }
}
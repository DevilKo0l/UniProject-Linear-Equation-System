using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Equation_System
{
    class EquationSystem: Matrix
    {
        private readonly GaussianElimination _gausian;        
        
        public EquationSystem(int newNumberOfEquation, int newNumberOfUnknown, GaussianElimination gaussian)
            :base(newNumberOfEquation, newNumberOfUnknown)
        {
            _gausian = gaussian;
           
        }

        public void DisplayEquation()
        {
            Console.Clear();            
            string[] variableArray = Enumerable.Repeat("X", nCol).ToArray();
            Console.WriteLine("\nYou have entered the following equation:");
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

        public void DisplayResult()
        {
            var result = _gausian.BackwardsSubstitution(matrix);
            Console.WriteLine("\nResult: ");
            int numX = result.Length;
            for (int i = 0; i < numX; i++)
            {
                Console.WriteLine("X{0}: {1}", i + 1, result[i]);
            }
        }


    }
}

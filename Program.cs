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

            double[,] matrix = new double[3, 4] { { 1, 2, 3, 5 }, { 1, 5, 8, 9 }, { 8, 9, 6, 1 } };
            EquationSystem equation = new EquationSystem(2, 3, new GaussianElimination());
            equation.SetLinearEquationMatrix();
            equation.DisplayEquation();
            equation.DisplayResult();
        }
    }
}


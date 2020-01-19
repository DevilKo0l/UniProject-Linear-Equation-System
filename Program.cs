using System;

namespace Linear_Equation_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Type linear equations in augmented matrix notation: a1 a2... aN d");
            Console.WriteLine("       Where a1..N are coefficients and d is constant");
            bool cont = true;
            int numEq;
            while (cont)
            {
                Console.Write("\nEnter number of equation: ");
                numEq = int.Parse(Console.ReadLine());
                SystemOfEquation newEq = new SystemOfEquation(numEq, numEq + 1);
                newEq.SetLinearEquationMatrix();
                newEq.DisplayEquation();
                newEq.DisplayRoot();
                Console.Write("\nDo you want to continue(y/n): ");
                if (askForContinue(Console.ReadLine()))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    cont = false;
                }
            }
        }

        static public bool askForContinue(string input)
        {
            if (input[0].ToString().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
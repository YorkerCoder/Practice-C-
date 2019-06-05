using System;

namespace Linear_Equation_Solver
{
    class Program
    {
        static void Main()
        {
            var matrix = new Matrix();
            matrix.RREF();
            matrix.Output();
        }
    }
}

using System;
namespace Non_Linear_Equation_Solver
{
    public class Solver
    {
        double[,] F { get; set; }
        double[,] J { get; set; }
        public double[] Initial_Vector { get; set; }

        public Solver(double[,] vector_function_F, double[] initial_vector)
        {
            F = vector_function_F;
            Initial_Vector = initial_vector;
        }

        

    }
}

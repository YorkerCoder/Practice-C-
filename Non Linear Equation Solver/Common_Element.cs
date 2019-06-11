using System;
namespace Non_Linear_Equation_Solver
{
    //simple elements such as 3x^2 where 3 is the coefficient, x is the variable and 2 is the exponent
    public class Common_Element 
    {
        public Common_Element(double coefficient, double exponent)
        {
            Coefficient = coefficient;
            Exponent = exponent;
        }

        public double Coefficient { get; set; }
        public double Exponent { get; set; }

        public double Value(double variable_value)
        {
            return Coefficient * Math.Pow(variable_value, Exponent);

        }

        public double First_Derivative(double variable_value)
        {
            
            return Exponent * Coefficient * Math.Pow(variable_value, (Exponent - 1));
        }

        
    }
}

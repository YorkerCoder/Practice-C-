using System;
namespace Non_Linear_Equation_Solver
{
    public class Exponential_Element
    {
        public double Coefficient { get; set; }
        public double Base { get; set; }

        //set the base with a coefficient of 1
        public Exponential_Element(double _base)
        {
            Base = _base;
        }

        //set the base and coefficient
        public Exponential_Element(double _base, double coefficient)
            :this(_base)
        {
            Coefficient = coefficient;
        }

        public double Value(double variable_value)
        {
            return Coefficient * Math.Pow(Base, variable_value);
        }

    }
}

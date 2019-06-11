using System;
namespace Non_Linear_Equation_Solver
{
    public enum Trig { sin, cos, tan, sinh, cosh, tanh }


    public class Trig_Element 
    {
        //Both coefficient and exponent are 1
        public Trig_Element(Trig trig_type)
        {
            Trig_Type = trig_type;
            Coefficient = 1;
            Exponent = 1;

        }

        //Only exponent is 1
        public Trig_Element(Trig trig_type, double coefficient)
            :this(trig_type)//calls the single parameter constructor
        {
            Coefficient = coefficient;
        }

        //Both exponent and coefficient aren't 1
        public Trig_Element(Trig trig_type, double coefficient, double exponent)
            :this(trig_type, coefficient)//calls the double parameter constructor
        {
            Exponent = exponent;
        }

        public enum Trig { sin, cos, tan, sinh, cosh, tanh }
        public double Coefficient { get; set; }
        public double Exponent { get; set; }
        public Trig Trig_Type { get; set; }
         

        //gets the value of the function element at the current point
        public double Value(double variable_value, Trig trig_type)
        {
            switch(trig_type)
            {
                case Trig.sin:
                    return Coefficient * Math.Pow(Math.Sin(variable_value), Exponent);
                case Trig.cos:
                    return Coefficient * Math.Pow(Math.Cos(variable_value), Exponent);
                case Trig.tan:
                    return Coefficient * Math.Pow(Math.Tan(variable_value), Exponent);
                case Trig.sinh:
                    return Coefficient * Math.Pow(Math.Sinh(variable_value), Exponent);
                case Trig.cosh:
                    return Coefficient * Math.Pow(Math.Cosh(variable_value), Exponent);
                case Trig.tanh:
                    return Coefficient * Math.Pow(Math.Tanh(variable_value), Exponent);
                default:
                    throw new Exception("No valid trig enum was passed to the Value function");
            }
        }



    }
}

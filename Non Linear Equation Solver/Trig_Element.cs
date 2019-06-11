using System;
namespace Non_Linear_Equation_Solver
{
    public enum Trig { sin, cos, tan, sinh, cosh, tanh }

    public class Trig_Element 
    {
        public Trig_Element(double coefficient, double exponent, Trig trig_type)
        {
            Coefficient = coefficient;
            Exponent = exponent;
            Trig_Type = trig_type;
        }

        public enum Trig { sin, cos, tan, sinh, cosh, tanh }
        public double Coefficient { get; set; }
        public double Exponent { get; set; }
        public Trig Trig_Type { get; set; }
         

        //gets the value of the function element at the current point
        public double Value(double variable_value, Trig trig_type)
        {
            //check if it's sin
            if (trig_type == Trig.sin)
            {
                return Coefficient * Math.Pow(Math.Sin(variable_value), Exponent);
            }

            //check if it's cos
            else if(trig_type == Trig.cos)
            {
                return Coefficient * Math.Pow(Math.Cos(variable_value), Exponent);
            }

            //check if it's tan
            else if(trig_type == Trig.tan)
            {
                return Coefficient * Math.Pow(Math.Tan(variable_value), Exponent);
            }

            //check if it's sinh
            else if(trig_type == Trig.sinh)
            {
                return Coefficient * Math.Pow(Math.Sinh(variable_value), Exponent);
            }

            //check if it's cosh
            else if (trig_type == Trig.cosh)
            {
                return Coefficient * Math.Pow(Math.Cosh(variable_value), Exponent);
            }

            //otherwise it's tanh
            else
            {
                return Coefficient * Math.Pow(Math.Tanh(variable_value), Exponent);
            }
        }


        //gets the value of the first derivative
        public double Sin_First_Derivative(double variable_value, Trig trig_type)
        {
            //check if it's sin
            if (trig_type == Trig.sin)
            {
                return Coefficient * Math.Pow(Math.Sin(variable_value), Exponent);
            }

            //check if it's cos
            else if (trig_type == Trig.cos)
            {
                return Coefficient * Math.Pow(Math.Cos(variable_value), Exponent);
            }

            //check if it's tan
            else if (trig_type == Trig.tan)
            {
                return Coefficient * Math.Pow(Math.Tan(variable_value), Exponent);
            }

            //check if it's sinh
            else if (trig_type == Trig.sinh)
            {
                return Coefficient * Math.Pow(Math.Sinh(variable_value), Exponent);
            }

            //check if it's cosh
            else if (trig_type == Trig.cosh)
            {
                return Coefficient * Math.Pow(Math.Cosh(variable_value), Exponent);
            }

            //otherwise it's tanh
            else
            {
                return Coefficient * Math.Pow(Math.Tanh(variable_value), Exponent);
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace Non_Linear_Equation_Solver
{
    public class Common_Element : IElement
    {
        private static double _h = 0.00000001;
        private static List<double> _variables;//list of the values of variables shared between all common elements
        

        public List<double> Variables { get { return _variables; } set { _variables = value; } }
        public int Variable { get; set; } //holds the place of where the variable is in the list
        public double Value { get { return Evaluate(); } }
        public double Partial_Derivative { get { return (Evaluate(_h) - Evaluate(-_h)) / (2 * _h); } }
        public Operator LHS { get; }
        public Operator RHS { get; }


        public double Coefficient { get;}
        public double Exponent { get;}


        //Assign the Coefficient, Exponent, RHS and LHS operators, and the variable
        public Common_Element(double coefficient, double exponent, Operator rhs, Operator lhs, int variable)
        {
            Coefficient = coefficient;
            Exponent = exponent;
            RHS = rhs;
            LHS = lhs;
            Variable = variable;
            
        }

        //evaluates the values of the element at the current variable value
        private double Evaluate()
        {
            return Coefficient * Math.Pow(Variables[Variable], Exponent);
        }

        //evaluates the elements value at a step (h) off the current variable value
        private double Evaluate(double h)
        {

            return Coefficient * Math.Pow(Variables[Variable] + h, Exponent);
        }
    }
}

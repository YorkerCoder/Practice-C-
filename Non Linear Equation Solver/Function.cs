using System;
using System.Collections.Generic;
namespace Non_Linear_Equation_Solver
{
    public class Function
    {
        //a list of elements 
        public List<IElement> Elemenets { get; set; }

        //a function to get the value of all the elements
        public double Value()
        {
            double sum = 0;
            foreach (var element in Elemenets)
            {
                sum += element.Value;
            }

            return sum;
        }

        //a function to get the partial derivative 
    }
}

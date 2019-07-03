namespace Non_Linear_Equation_Solver
{
    public interface IElement
    {
        Operator LHS { get; }//tells you the operator in the left hand side
        Operator RHS { get; }//tells you the operator in the right hand side
        double Value { get; }//gets the evaluated value of the function element
        double Partial_Derivative { get; }//gets the value of the partial derivative of an element
    }
}

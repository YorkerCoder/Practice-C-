namespace Non_Linear_Equation_Solver
{
    public class Number : IElement
    {
        public Operator LHS { get; }
        public Operator RHS { get; }
        public double Value { get; }
        public double Partial_Derivative { get { return 0; } }

        public Number(double value, Operator lhs, Operator rhs)
        {
            LHS = lhs;
            RHS = rhs;
            Value = value;
        }

    }
}

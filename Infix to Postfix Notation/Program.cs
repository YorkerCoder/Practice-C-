using System;
using System.Collections;

namespace Infix_to_Postfix_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix = "7/5+3-2";
            Console.WriteLine(Converter.Evaluate(infix));
        }
    }
}

using System.Collections.Generic;
using System;

namespace Infix_to_Postfix_Notation
{
    public class Converter
    { 
        public static string Evaluate(string expression)
        {
            string postfix = string.Empty;//string to store the postfix expression initialized to an empty string
            const string space = " ";
            string substr = string.Empty;
            Stack<string> operators = new Stack<string>();


            //go through the whole lenght of the string
            for(int position = 0; position < expression.Length; position++)
            {
                //store the substring
                substr = expression.Substring(position,1);

                //check if it's an empty string
                if (substr == " ")
                {
                    continue;
                }
                else
                {
                    //if the scanned character is an opperand (letter or number) add it to the postfix *note* later add for a period to allow floating numbers
                    if (char.IsLetterOrDigit(substr, 0))
                    {
                        postfix += substr + space;
                    }

                    //check if the scanned char is ( and push it to the stack
                    else if (substr == "(")
                    {
                        operators.Push(substr);
                    }

                    //check if the scanned char is )
                    else if (substr == ")")
                    {
                        //pop the stack if it's not empty and output it until a '(' is hit
                        while (operators.Count > 0 && operators.Peek() != "(")
                        {
                            postfix += operators.Pop() + space;
                        }

                        //check if the stack is empty and not a (
                        if (operators.Count > 0 && operators.Peek() != "(")
                        {
                            //throw an exception
                            throw new Exception("Invalid Expression");
                        }
                        else
                        {
                            //Pop the open bracket
                            operators.Pop();
                        }
                    }

                    //otherwise we've run across an operator
                    else
                    {
                        while (operators.Count > 0 && Precedent(substr) <= Precedent(operators.Peek()))
                        {
                            postfix += operators.Pop() + space;
                        }
                        operators.Push(substr);

                    }//end else
                }
                
            }//end for loop

            //pop all the remaining operators in the stack
            while(operators.Count > 0)
            {
                postfix += operators.Pop() + space;
            }

            //return the postfix expression
            return postfix;

        }

        /*basic idea is that they return an int based on what the precedent is
         * parenthesis is 4
         * exponents are 3
         * mult and div are 2
         * add and subtract are 1 
         * it defaults to -1
         */
        private static int Precedent(string op) 
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return -1;
            }
        }
    }
}

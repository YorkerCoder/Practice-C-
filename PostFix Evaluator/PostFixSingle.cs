using System;
using System.Collections;

namespace Stack_Math
{
    public class PostFixSingle
    {
        public static void Mains()
        {
            var maths = new PostFixSingle();
            maths.V = "2 3 1 * + 9 -";
            maths.Expression();
            Console.WriteLine("postfix evaluation: " + maths.Answer);
        }

        public string V { get; set; }//stores the string value

        public string Answer { get; set; }

        public Stack stack { get; set; } = new Stack();

        public void Expression()
        {
            int a, b, ans;
            for(int j = 0; j < V.Length; j++)//V.Length is the length of the string
            {
                
                string c = V.Substring(j, 1);//goes through the string 1 by 1
                //check if it's an empty space
                if (c.Equals(" "))
                {
                    //do nothing
                }
                //if it's not a space 
                else
                {
                    //if the substring is multiply
                    if (c.Equals("*"))
                    {
                        //pop the top two strings from the stack and store them
                        string sa = (string)stack.Pop();
                        string sb = (string)stack.Pop();

                        //convert the string to number and store them
                        a = Convert.ToInt32(sb);//note 
                        b = Convert.ToInt32(sa);

                        //multiply the numbers 
                        ans = a * b;

                        //put it back in the stack
                        stack.Push(ans.ToString());
                    }

                    //if the substring is divide
                    else if (c.Equals("/"))
                    {
                        string sa = (string)stack.Pop();
                        string sb = (string)stack.Pop();

                        //convert the string to number and store them
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);

                        //divide the numbers 
                        ans = a / b;

                        //put it back in the stack
                        stack.Push(ans.ToString());
                    }

                    //if the substring is add
                    else if (c.Equals("+"))
                    {
                        string sa = (string)stack.Pop();
                        string sb = (string)stack.Pop();

                        //convert the string to number and store them
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);

                        //add the numbers 
                        ans = a + b;

                        //put back in the stack
                        stack.Push(ans.ToString());
                    }

                    //if the substring is subtract
                    else if (c.Equals("-"))
                    {
                        string sa = (string)stack.Pop();
                        string sb = (string)stack.Pop();

                        //convert the string to number and store them
                        a = Convert.ToInt32(sb);
                        b = Convert.ToInt32(sa);

                        //subtract the numbers 
                        ans = a - b;

                        //put back in the stack
                        stack.Push(ans.ToString());
                    }

                    //if it's a number
                    else
                    {
                        //add the number to the stack
                        stack.Push(V.Substring(j, 1));
                    }
                }//end else
            }//end for 

            //store the answer in the answer variable
            Answer = (string)stack.Pop();
        }
    }
}

using System.Collections.Generic;
using System;
namespace Alternative_NLES
{
    public class Equation_Solver
    {
        
        public List<double> X_Vector_N_Minus_1 { get; set; }//stores the previous set of answers
        public List<double> X_Vector_N { get; set; }//initial guesses and final answers stored here
        public List<string> X_Variables { get;}

        //used to store the functions in a form that can be easily turned into a number by the computer
        //public List<Function> Function_Values { get; set; }
        public double[,] Modified_Jacobian { get; set; } //2D arrays [rows, columns], has the y vector column at the end of it
        public int Jac_Rows { get;} // amount of rows in the modified jacobian
        public int Jac_Columns { get;} // amount of columns in the jacobian


        //initialize everything in the constructor
        public Equation_Solver(List<double> y_vector, List<double> x_vector, List<string> x_variables)
        {
            X_Vector_N_Minus_1 = new List<double>();
            Modified_Jacobian = new double[x_variables.Count, x_variables.Count + 1];
            Jac_Rows = Modified_Jacobian.GetLength(0);
            Jac_Columns = Modified_Jacobian.GetLength(1);
            X_Vector_N = x_vector;
            X_Variables = x_variables;
        }


        public void Newton_Method()
        {
            //
            do
            {
                //store Xn in Xn-1
                for (int i = 0; i < X_Vector_N.Count; i++)
                {
                    X_Vector_N_Minus_1[i] = X_Vector_N[i];
                }

                //plug in the values of the variables into the functions to calculate the Y vector and store them in the end of the Modified matrix

                //get and store the values of the partial derivatives to create the rest of the Jacobian matrix 
                
                //Perform Gaussian Elimination
                Gaussian_Elimination();

                //Calculate Xn by using X(n) = X(n-1) + Y
                for (int row = 0; row < Jac_Rows; row++)
                {
                    X_Vector_N[row] = X_Vector_N_Minus_1[row] + Modified_Jacobian[row, Jac_Columns - 1];
                }
                

            } while (Vector_Norm() == false);


        }
        
        //method that performs Gaussian elimination
        private void Gaussian_Elimination()
        {
            //go through the rows
            for(int column = 0; column < Jac_Rows; column++)
            {
                //check if the pivot value is a 0
                if(Abs_Compare(Modified_Jacobian[column, column], 1) == true)
                {
                    //if it's a 0 go down the row until you find a non zero
                    for (int row = column+1; row < Jac_Rows; row++)
                    {
                       //make sure it's not a 0
                       if (Abs_Compare(Modified_Jacobian[row,column], 0) == false)
                       {
                            //switch the rows 
                            Jacobian_Row_Switcher(row, column);

                            //check if it's a 1
                            if (Abs_Compare(Modified_Jacobian[row, column], 1) == false)
                            {
                                //divide the row by the pivot number
                                Row_Divide(row, Modified_Jacobian[column, column]);
                            }


                            //clean out the rest of the column
                            Column_Cleaner(column, column);
                            //break out of the row
                            row = Modified_Jacobian.GetLength(0);

                        }
                    }
                }
                //check if it's a 1
                else if (Abs_Compare(Modified_Jacobian[column, column], 1) == true)
                {
                    //set the rest of the numbers in the column to 0
                    Column_Cleaner(column, column);

                }
                //otherwise it's neither
                else
                {
                    //divide the row by the non pivot number
                    Row_Divide(column, Modified_Jacobian[column, column]);
                    //clean out the rest of the column
                    Column_Cleaner(column, column);
                }
            }
        }

        //if the doubles are close enough returns true
        private bool Abs_Compare(double comparing, double comparer)
        {
            const double Tolerance = 0.000001;
            //get the absolute difference
            double abs_difference = Math.Abs(comparer - comparing);
            //check if the numbers are barely different
            if (abs_difference <= Tolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Switches around 2 rows in the jacobian matrix and is temporary until i have the function class working
        private void Jacobian_Row_Switcher(int row_1, int row_2)
        {
            double[] temp = new double[Jac_Columns];//used to temporarily store a row
            //store the first row in the temp array
            for(int column = 0; column < Jac_Columns; column++)
            {
                temp[column] = Modified_Jacobian[row_1, column];
            }

            //store the second row in the first row
            for (int column = 0; column < Jac_Columns; column++)
            {
                Modified_Jacobian[row_1, column] = Modified_Jacobian[row_2, column];
            }

            //store the temp row in the second row
            for (int column = 0; column < Jac_Columns; column++)
            {
                Modified_Jacobian[row_2, column] = temp[column];
            }

        }


        //function to set the rest of the numbers in the column to 0 in the jacobian
        private void Column_Cleaner(int subtracting_row, int column)
        {
            //go through all the rows in the column
            for (int row = 0; row < Jac_Rows; row++)
            {
                //make sure it's not the active row
                if(row != subtracting_row)
                {
                    //subtract the multiple of the safe row from the current row
                    Row_Subtract(subtracting_row, Modified_Jacobian[row, column], row);
                }
            }
        }


        //function to subtract a row in the modified jacobian 
        private void Row_Subtract(int subtracting_row, double row_multiplier, int row_to_subtract_from)
        {
            //starting from the far left column in the row, go right subtracting the multiple from the subtracting row
            for (int column = 0; column < Jac_Columns; column++)
            {
                //set the value in the column of the jacobian to 0
                Modified_Jacobian[row_to_subtract_from, column] = Modified_Jacobian[row_to_subtract_from, column] - (Modified_Jacobian[subtracting_row, column] * row_multiplier);
            }
        }

        //Function to divide a row by a number in the modified jacobian
        private void Row_Divide(int row, double row_divider)
        {
            //divide the Y vector
            

            //starting from the left go to the right dividing by the row divider in that particular row
            for (int column = 0; column < Jac_Columns; column++)
            {
                Modified_Jacobian[row, column] = Modified_Jacobian[row, column] / row_divider;
            }
        }

        //Vector norm ||x(k) - x(k-1)|| returns true if it's close enough to 0
        private bool Vector_Norm()
        {
            double sum = 0;
            double sqrt = 0;
            //sum up the squares of x(k) - x(k-1)
            for (int i = 0; i < X_Vector_N.Count; i++)
            {
                sum = Math.Pow((X_Vector_N[i] - X_Vector_N_Minus_1[i]), 2);
            }

            //sqrt the sum
            sqrt = Math.Sqrt(sum);

            //returns true if it's close to 0, otherwise it returns false
            return Abs_Compare(sqrt, 0);
        }
    }

}

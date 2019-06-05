using System;

namespace Linear_Equation_Solver
{
    public class Matrix
    {
        //Note for a 2D Array [rows , columns]
        public string[] Variables { get; private set; } = new string[] { "x", "y", "z" };
        public double[,] Multipliers { get; private set; } = new double[,] { { 1, 1, -1, 9 }, { 0, 1, 3, 3 }, { -1, 0, -2, 2 } }; //{ { 1, -2, 1 }, { 3, 4, -1 } };  

        public int Multipliers_Columns { get; private set; } 
        public int Multipliers_Rows { get; private set; }

        public Matrix()
        {
            Multipliers_Rows = Multipliers.GetLength(0);
            Multipliers_Columns = Multipliers.GetLength(1);
        }

        public Matrix(string[] variables, double[,] multipliers)
            :this()//note - this calls the base constructor
        {
            Multipliers = multipliers;
            Variables = variables; 
            
        }

        //output the answers
        public void Output()
        {
            //go through the rows
            for(int row = 0; row <Multipliers_Rows; row++)
            {
                Console.WriteLine("{0}: {1}", Variables[row], Multipliers[row, Multipliers_Columns-1]);
            }
            
        }

        public void RREF()
        {
            const double tolerance = 0.00001;//if it's greater than to the tolerance it means it's not the number if it's less it means it's close enough to it
            double row_divider = 0;
            

            //note i'm using column as a row when reading from the 2d array because it's forming the identity matrix
            for(int column = 0; column < Multipliers_Columns - 1; column++)
            {
                //check if the pivot number is a 0
                if(Abs_Compare(Multipliers[column,column], 0) < tolerance)
                {
                    //go through the column below the pivot number
                    for(int row = column + 1; row < Multipliers_Rows; row++)
                    {
                        //check to see that it's not a 0
                        if(Abs_Compare(Multipliers[row, column], 0) > tolerance)
                        {
                            //switch the row
                            Row_Switcher(row, column);
                            
                            //check if it's not a 1
                            if(Abs_Compare(Multipliers[row, column], 1) > tolerance)
                            {
                                //divide the row by the non pivot number
                                row_divider = Multipliers[column, column];
                                Row_Divide(column, row_divider);
                            }

                            //clean out the rest of the column
                            Column_Cleaner(column, column);
                            //break out of the row 
                            row = Multipliers_Rows;
                        }
                    }
                }

                //check if the pivot number is a 1
                else if(Abs_Compare(Multipliers[column, column], 0) < tolerance)
                {
                    //set the rest of the numbers in the column to 0
                    Column_Cleaner(column, column);
                }

                //otherwise it's neither
                else
                {
                    //divide the row by the non pivot number
                    row_divider = Multipliers[column, column];
                    Row_Divide(column, row_divider);
                    //clean out the rest of the column
                    Column_Cleaner(column, column);
                }
            }
            
        }

        //function to set the rest of the columns numbers to 0
        private void Column_Cleaner(int subtracting_row, int column)
        {
            //go through all the rows in that column
            for(int row = 0; row < Multipliers_Rows; row++)
            {
                //check if it's not the safe row
                if(row != subtracting_row)
                {
                    //subtract the multiple of the safe row from the current row
                    Row_Subtract(subtracting_row, Multipliers[row, column], row);
                }
            }
        }

        //Function to trade rows
        private void Row_Switcher(int row1, int row2)
        {
            double[] temp_row = new double[Multipliers_Rows]; //used to temporarily hold a row while switching takes place
            
            //store row 1 in a temporary row
            for (int column = 0; column < Multipliers_Columns; column++)
            {
                temp_row[column] = Multipliers[row1, column];
            }

            //place the second row in the first row
            for (int column = 0; column < Multipliers_Columns; column++)
            {
                Multipliers[row1, column] = Multipliers[row2, column];
            }
            //place the first row in the second row
            for (int column = 0; column < Multipliers_Columns; column++)
            {
                Multipliers[row2, column] = temp_row[column];
            }
        }

        //function to divide a row by a number
        private void Row_Divide(int row, double row_Divider)
        {
            //starting from the left go to the right dividing by the row divider in that particular row
            for (int column = 0; column < Multipliers_Columns; column++)
            {
                Multipliers[row, column] = (Multipliers[row, column] / row_Divider);
            }
        }

        //function to subtract a multiple of one row from another
        private void Row_Subtract(int subtracting_Row, double row_Multiplier, int row_To_Subtract_From)
        {
            for(int column = 0; column< Multipliers_Columns; column++)
            {
                Multipliers[row_To_Subtract_From, column] = Multipliers[row_To_Subtract_From, column] - (Multipliers[subtracting_Row, column] * row_Multiplier);
            }
        }

        //function to compare the abs difference between two doubles
        private double Abs_Compare(double comparer_1, double comparer_2)
        {
            return Math.Abs(comparer_1 - comparer_2);
        }

    }
}

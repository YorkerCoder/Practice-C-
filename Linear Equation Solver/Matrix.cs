using System;

namespace Linear_Equation_Solver
{
    public class Matrix
    {
        //Note for a 2D Array [rows , columns]
        public string[] Variables { get; set; } = new string[] { "x", "y", "z" };
        public double[,] Multipliers { get; set; } = new double[,] { { 1, -2, 1 }, { 3, 4, -1 } };  //{ { 1, 1, -1, 9 }, { 0, 1, 3, 3 }, { -1, 0, -2, 2 } };

        public int Multipliers_Columns { get; set; } 
        public int Multipliers_Rows { get; set; }

        public Matrix()
        {
            Multipliers_Rows = Multipliers.GetLength(0);
            Multipliers_Columns = Multipliers.GetLength(1);
        }
        public void RREF()
        {
            const double tolerance = 0.00001;//if it's greater than to the tolerance it means it's not the number if it's less it means it's close enough to it
            double row_divider = 0;
            double row_multiplier = 0;

            //note i'm using column as a row because it's forming the identity matrix
            for(int column = 0; column < Multipliers_Columns; column++)
            {
                //check if the pivot number is a 0
                if(Abs_Compare(Multipliers[column,column], 0) < tolerance)
                {
                    //go through the column below the pivot
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

                            //break out of the column
                        }
                    }
                }
                //check if the pivot number is a 1
                if(Abs_Compare(Multipliers[column, column], 0) < tolerance)
                {

                }
                //otherwise it's neither
                else
                {

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

        private void Row_Divide(int row, double row_Divider)
        {
            //starting from the left go to the right dividing by the row divider in that particular row
            for (int column = 0; column < Multipliers_Columns; column++)
            {
                Multipliers[row, column] = (Multipliers[row, column] / row_Divider);
            }
        }

        private void Row_Subtract(int subtracting_Row, double row_Multiplier, int row_To_Subtract_From)
        {
            for(int column = 0; column< Multipliers_Columns; column++)
            {
                Multipliers[row_To_Subtract_From, column] = Multipliers[row_To_Subtract_From, column] - (Multipliers[subtracting_Row, column] * row_Multiplier);
            }
        }

        private double Abs_Compare(double comparer_1, double comparer_2)
        {
            return Math.Abs(comparer_1 - comparer_2);
        }

    }
}

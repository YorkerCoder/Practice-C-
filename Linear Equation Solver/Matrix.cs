using System;

namespace Linear_Equation_Solver
{
    public class Matrix
    {
        //Note for a 2D Array [rows , columns]
        public string[] Variables { get; set; } = new string[] { "x", "y", "z" };
        public double[,] Multipliers { get; set; } = new double[,] { { 1, 1, -1, 9 }, { 0, 1, 3, 3 }, { -1, 0, -2, 2 } };

        public int Multipliers_Columns { get; set; } 
        public int Multipliers_Rows { get; set; }

        public Matrix()
        {
            Multipliers_Rows = Multipliers.GetLength(0);
            Multipliers_Columns = Multipliers.GetLength(1);
        }
        public void RREF()
        {

            double divider_Holder = 0;

            for(int column = 0; column < Multipliers_Columns; column++)
            {
                //check if the diagnol of the current column is a 1 and not a 0
                if (Multipliers[column, column] != 1 && Multipliers[column, column] != 0)
                {
                    //set what you're going to be dividing by
                    divider_Holder = Multipliers[column, column];

                    //divide the whole row by the number in the position
                    for(int row = 0; row < Multipliers_Rows; row++)
                    {
                       Multipliers[row, column] =  Multipliers[row, column] / divider_Holder;
                    }
                }
                //if it's not check the rest of the column to see if the other parts of it are 0
                else
                {
                    for (int row = 0; row < Multipliers_Rows; row++)
                    {
                        //check if it's 0 in the current row of the column
                        if (Multipliers[row, column] != 0)
                        {
                            //subtract the multiple of the row from 
                        }
                    }
                }
            }

        }



    }
}

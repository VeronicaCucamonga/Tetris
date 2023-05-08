using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        //hold a 2-d rectangular array, first dimension is row and the second is the column 
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        //an indexer to provide an easy access to the array, using the indexing directly in the game grid 
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        //constructor 
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        //method: given row and column is inside the grid or not
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //method: given cell is empty or not 
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        //method: check if the row is full
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //method: check if the row is empty 
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        //method: clears a row
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //method: moves a row down by a certain amount of rows
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        //clears whatever rows are full
        public int ClearFullRows()
        {
            int cleared = 0;

            //moves row from bottom to the top
            for (int r = Rows - 1; r >= 0; r--)
            {
                //checks row is full and clears it and increments cleared
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                //moves the row down by the number of rows 
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}

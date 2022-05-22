using System;
namespace Minesweeper
{
    public class cell
    {
        // each cell will contain a position in the grid that is indexedv(eg [5][5]))
        // they will also have a boolean value determining whether they are a bomb or not

        // we can use a loop that iterates over our grid and randomly generates 2 numbers
        // that will serve as a coordinate on the grid

        public int Col;
        public int Row;
        public bool Bomb;

        public Random x = new Random();

        public cell(int col, int row, bool bomb)
        {
            col = x.Next(0, 9);
            row = x.Next(0, 9);

        }
    }
}

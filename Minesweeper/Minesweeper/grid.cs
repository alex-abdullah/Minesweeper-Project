using System;
namespace Minesweeper
{
    public class grid
    {
        // We want to construst a multi-dimensional array that holds our 100 cells
        // user will be able to input 2 numbers that serve as coordinates eg. 5, 10
        // our grid will be created at run time along with the cells that are bombs

        int cols;
        int rows;

        public static string [,] GridCreator()
        {
            string[,] PlayingGrid = new string[10, 10];
            return PlayingGrid;
        }
    }
}

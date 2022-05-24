using System;
namespace Minesweeper
{
    public class Grid
    {
        public Cell[,] GameGrid;
        public int GridWidth;
        public int GridHeight;

        public Grid(int gridWidth, int gridHeight)
        {
            GridWidth = gridWidth;
            GridHeight = gridHeight;

            GameGrid = new Cell[GridWidth, GridHeight];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            // For each cell in the grid (gridWidth x gridHeight cells), initialize the object reference
            for (int i = 0; i < GridWidth; i++)
            {
                for (int j = 0; j < GridHeight; j++)
                {                    
                    GameGrid[i, j] = new Cell(); // Initializes the reference to a real object instance
                }
            }
        }

        public int BombCreator(int maxBombs)
        {
            int j = 0;
            Random rnd = new Random();

            while (j <= maxBombs)
            {
                int col = rnd.Next(0, 9);
                int row = rnd.Next(0, 9);

                if (!GameGrid[col, row].isBomb)
                {
                    GameGrid[col, row].isBomb = true;
                    j++;
                }
            }
            return j;
        }

        public string BombChecker(int col, int row)
        {
            int counter = 0;

            if (col - 1 >= 0 && GameGrid[(col - 1), row].isBomb == true)
                counter++;

            if (col + 1 <= 9 && GameGrid[(col + 1), row].isBomb == true)
                counter++;

            if (row - 1 >= 0 && GameGrid[col, (row - 1)].isBomb == true)
                counter++;

            if (row + 1 <= 9 && GameGrid[col, (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row - 1 >= 0 && GameGrid[(col - 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 <= 9 && row - 1 >= 0 && GameGrid[(col + 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 <= 9 && row + 1 <= 9 && GameGrid[(col + 1), (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row + 1 <= 9 && GameGrid[(col - 1), (row + 1)].isBomb == true)
                counter++;

            return $"There are {counter} bomb(s) nearby";
        }
    }
}

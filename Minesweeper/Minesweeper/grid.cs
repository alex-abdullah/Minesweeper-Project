using System;
namespace Minesweeper
{
    public class Grid
    {
        private Cell[,] _gameGrid;
        private int _gridWidth;
        private int _gridHeight;


        public int GridWidth { get { return _gridWidth; } }
        public int GridHeight { get { return _gridHeight; } }
        public Cell[,] GameGrid { get { return _gameGrid; } }

        public Grid(int gridWidth, int gridHeight)
        {
            _gridWidth = gridWidth;
            _gridHeight = gridHeight;
            _gameGrid = new Cell[_gridWidth, _gridHeight];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            // For each cell in the grid (gridWidth x gridHeight cells), initialize the object reference
            for (int i = 0; i < _gridWidth; i++)
            {
                for (int j = 0; j < _gridHeight; j++)
                {                    
                    _gameGrid[i, j] = new Cell(); // Initializes the reference to a real object instance
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

                if (!_gameGrid[col, row].isBomb)
                {
                    _gameGrid[col, row].isBomb = true;
                    j++;
                }
            }
            return j;
        }

        public string BombChecker(int col, int row)
        {
            int counter = 0;

            if (col - 1 >= 0 && _gameGrid[(col - 1), row].isBomb == true)
                counter++;

            if (col + 1 < _gridWidth && _gameGrid[(col + 1), row].isBomb == true)
                counter++;

            if (row - 1 >= 0 && _gameGrid[col, (row - 1)].isBomb == true)
                counter++;

            if (row + 1 < _gridHeight && _gameGrid[col, (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row - 1 >= 0 && _gameGrid[(col - 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 < _gridWidth && row - 1 >= 0 && _gameGrid[(col + 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 < _gridWidth && row + 1 < _gridHeight && _gameGrid[(col + 1), (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row + 1 < _gridHeight && _gameGrid[(col - 1), (row + 1)].isBomb == true)
                counter++;

            return $"There are {counter} bomb(s) nearby";
        }
    }
}

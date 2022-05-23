using System;
namespace Minesweeper
{
    public class game
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Pirate Bay Minesweeper! <(^o^)>");
            Console.WriteLine("");
            Console.WriteLine("*** INSTRUCTIONS ***");
            Console.WriteLine("");
            Console.WriteLine("1: Please enter numbers one at a time.");
            Console.WriteLine("2: GGLF :)");
            Console.WriteLine("");
            Console.WriteLine("=================================================");
            Console.WriteLine("");
            Console.WriteLine("To begin:");
            Console.WriteLine("");
        }

        public static void CellAlreadyChosen()
        {
            Console.WriteLine("Cell has already been selected.");
            Console.WriteLine("Please choose another cell.");
            Console.WriteLine("");
        }
               
        public static void EndGame()
        {
            Console.WriteLine("");
            Console.WriteLine("BOOM!");
            Console.WriteLine("");
            Console.WriteLine("Better luck next time.");
        }

        public static void InitializeGrid(Cell[,] grid, int gridWidth, int gridHeight)
        {
            // For each cell in the grid (gridWidth x gridHeigh cells), initialize the object reference
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    // Initializes the reference to a real object instance
                    grid[i, j] = new Cell();
                }
            }
        }

        //Returns -1 if not a valid index, otherwise returns the index
        public static int TryParseIndex(string strIndex, int dimensionBound)
        {
            try
            {
                // Trying to convert user input to a number
                int index = Int32.Parse(strIndex);
                                
                if(index >= 0 && index < dimensionBound)
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Valid number was not entered");
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Valid number was not entered");
                return -1;
            }
        }

        public static void BombCreator(Cell[,] grid, int maxBombs)
        {
            int j = 0;
            Random rnd = new Random();

            while (j <= maxBombs)
            {
                int col = rnd.Next(0, 9);
                int row = rnd.Next(0, 9);
                
                if (!grid[col, row].isBomb)
                {
                    grid[col, row].isBomb = true;
                    j++;
                }
            }
        }

        public static string BombChecker(Cell[,] grid, int col, int row)
        {
            int counter = 0;

            if (col - 1 >= 0 && grid[(col - 1), row].isBomb == true)
                counter++;

            if (col + 1 <= 9 && grid[(col + 1), row].isBomb == true)
                counter++;

            if (row - 1 >= 0 && grid[col, (row - 1)].isBomb == true)
                counter++;

            if (row + 1 <= 9 && grid[col, (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row - 1 >= 0 && grid[(col - 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 <= 9 && row - 1 >= 0 && grid[(col + 1), (row - 1)].isBomb == true)
                counter++;

            if (col + 1 <= 9 && row + 1 <= 9 && grid[(col + 1), (row + 1)].isBomb == true)
                counter++;

            if (col - 1 > 0 && row + 1 <= 9 && grid[(col - 1), (row + 1)].isBomb == true)            
                counter++;

            return $"There are {counter} bomb(s) nearby";
        }

    }
}

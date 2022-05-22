using System;
namespace Minesweeper
{
    public class game
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Pirate Bay version of Minesweeper!");
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

        public static void EndGame()
        {
            Console.WriteLine("");
            Console.WriteLine("BOOM!");
            Console.WriteLine("");
            Console.WriteLine("Better luck next time.");
        }

        public static void NoBombMessage()
        {            
            Console.WriteLine("Nice! Keep going!");
            Console.WriteLine("");
        }

        public static void InitializeGrid(Cell[,] grid, int gridWidth, int gridHeight)
        {
            // For each cell in the grid (gridWidth x gridHeigh cells), initialize the object refernece
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    // Initializes the refernce to a real object instance
                    // The new keyword actually allocates the memory and creates the object for you
                    grid[i, j] = new Cell();
                }
            }
        }
    }
}

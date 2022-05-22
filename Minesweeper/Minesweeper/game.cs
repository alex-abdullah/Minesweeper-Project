using System;
namespace Minesweeper
{
    public class game
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Pirate Bay version of Minesweeper!");
            Console.WriteLine("To begin:");
            Console.WriteLine("");
        }

        public static void EndGame()
        {
            Console.WriteLine("");
            Console.WriteLine("Boom!");
            Console.WriteLine("Better luck next time.");
        }
    }
}

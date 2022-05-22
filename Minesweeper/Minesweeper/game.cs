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
    }
}

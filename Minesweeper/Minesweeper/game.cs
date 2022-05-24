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
    }
}

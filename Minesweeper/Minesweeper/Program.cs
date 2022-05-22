using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Creating Playing Grid
            string [,] grid = new string [10, 10];

            int x = 0; // Column
            int y = 0; // Row

            Random rnd = new Random(); // New instance of Random Class

            // Creating 10 randomly placed bombs
           for (int i = 0; i < 10; i++)
            {
                x = rnd.Next(0, 9);
                y = rnd.Next(0, 9);

                grid[x, y] = "Bomb";
            }

           // User Welcome Messages!
            Console.WriteLine("Welcome to the Pirate Bay version of Minesweeper!");
            Console.WriteLine("To begin:");
            Console.WriteLine("");


            // Allowing User to Make Guesses
           for (int i = 0; i <= 90; i++)
            {
                Console.WriteLine("Input 2 numbers:");
                string UserGuess = Console.ReadLine();
                char[] characters = UserGuess.ToCharArray();
                int a = (characters[0] - '0');
                int b = (characters[2] - '0');

                // Checking if user input corresponds to a bomb location
                if (grid[a, b] != "Bomb")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Nice! Keep going!");
                    Console.WriteLine("");
                }

                // Lose condition
                if (grid[a, b] == "Bomb")
                {
                    goto AfterGame;
                }   

            }


           // Endgame message :(
        AfterGame:
            Console.WriteLine("");
            Console.WriteLine("Boom!");
            Console.WriteLine("Better luck next time.");

        }
    }
}

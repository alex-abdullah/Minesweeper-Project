using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Static Grid Creation Method */

            // Creating Playing Grid
            
            string [,] grid = new string [10, 10];
                     
            /* Static Bomb Creation Method */

            Random rnd = new Random(); // New instance of Random Class

            // Creating 10 randomly placed bombs
           for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(0, 9);
                int y = rnd.Next(0, 9);

                grid[x, y] = "Bomb";
            }

            // User Welcome Message!            
            game.Welcome();


            // Allowing User to Make Guesses
            bool bomb = false;


           while (bomb == false)
            {
                Console.WriteLine("Column Number:");
                string col = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    if (col.Length > 1 || col.Length <= 0)
                        throw new Exception("Please input number between 0 and 9");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Column Number:");
                    col = Console.ReadLine();
                    Console.WriteLine("");

                }
                Console.WriteLine("Row Number:");
                string row = Console.ReadLine();
                Console.WriteLine("");
                try
                {
                    if (row.Length > 1 || row.Length <= 0)
                        throw new Exception("Please input number between 0 and 9");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Row Number:");
                    row = Console.ReadLine();
                    Console.WriteLine("");

                }

                //Console.WriteLine("");
                Console.WriteLine($"Cell chosen: [{col},{row}]");

                char[] colChar = col.ToCharArray();
                char[] rowChar = row.ToCharArray();
                int a = (colChar[0] - '0');
                int b = (rowChar[0] - '0');

                
                // Checking if user input corresponds to a bomb location
                if (grid[a, b] != "Bomb")
                {
                    game.NoBombMessage();
                }

                // Lose condition
                if (grid[a, b] == "Bomb")
                {
                    
                    goto EndGame;
                }   

            }


        // Endgame message :(
        EndGame:
            game.EndGame();

        }
    }
}

using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Program {
    


        static void Main(string[] args)
        {


            //3 magic types of things
            //1. is primitives (int, float, char, double, long, bool) NO REFERNCES
            //2. is objects, where you ALWAYS interact with an object via a reference
            //3. is arrays, which work the same as objects (use refernce)

            //2 references of the same size
            //int[] arr;
            //int[] arr2;

            //But if you follow ther ferences into RAM (memory), thats where the differnet
            //arr = new int[10];
            //arr2 = new int[12];
            


            /* Static Grid Creation Method */

            // Creating Playing Grid

            const int gridWidth = 10;
            const int gridHeight = 10;

            // Creates gridWidth x gridHeight null references
            Cell [,] grid = new Cell [gridWidth, gridHeight];

            // One-time initialize (10x10 iterations)
            game.InitializeGrid(grid, gridWidth, gridHeight);
                     
            /* Static Bomb Creation Method */

            Random rnd = new Random(); // New instance of Random Class

            // Creating 10 randomly placed bombs
           for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(0, 9);
                int y = rnd.Next(0, 9);

                grid[x, y].isBomb = true;
            }

            // User Welcome Message!            
            game.Welcome();


            // Allowing User to Make Guesses
            bool bomb = false;


           while (bomb == false)
            {

                int a = -1;
                int b = -1;

                while (a == -1)
                {
                    Console.WriteLine($"Please input column number between {0} and {gridWidth - 1}");
                    string col = Console.ReadLine();
                    Console.WriteLine("");

                    int res = game.TryParseIndex(col, gridWidth);

                    // TODO Double check that col/height/row/width is consistent
                    if (res != -1) // did not fail
                    {
                        a = res;   
                    }
                }

                while (b == -1)
                {
                    Console.WriteLine("Row Number:");
                    string row = Console.ReadLine();
                    Console.WriteLine("");

                    int res = game.TryParseIndex(row, gridHeight);

                    if (res != -1)
                    {
                        b = res;
                    }

                }
                            
                                               
                Console.WriteLine($"Cell chosen: [{a},{b}]");
                                
                if (grid[a, b].isBomb == false)
                {
                    game.NoBombMessage();
                }
                else
                {
                    bomb = true;
                }

                            
            }


        // Endgame message :(
        
            game.EndGame();

        }
    }
}

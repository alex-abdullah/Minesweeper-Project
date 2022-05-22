using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Program {
    


        static void Main(string[] args)
        {

            // Creating Playing Grid

            int gridWidth = 10;
            int gridHeight = 10;

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

            // Guess counter
            int guessCounter = 0;


           while (bomb == false)
            {

                int a = -1;
                int b = -1;

                while (a == -1)
                {
                    Console.WriteLine($"Enter column number between {0} and {gridWidth - 1}");
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
                    Console.WriteLine($"Enter row number between {0} and {gridHeight - 1}");
                    string row = Console.ReadLine();
                    Console.WriteLine("");

                    int res = game.TryParseIndex(row, gridHeight);

                    if (res != -1)
                    {
                        b = res;
                    }

                }
                            
                                               
                Console.WriteLine($"Cell chosen: [{a},{b}]");

                //Storing User's Guess
                Cell userGuess = grid[a, b];

                if (userGuess.isBomb == false && userGuess.alreadyChecked == true)
                {
                    game.CellAlreadyChosen();
                }

                if (userGuess.isBomb == false && userGuess.alreadyChecked == false)
                {
                    guessCounter++;
                    userGuess.alreadyChecked = true;
                    Console.WriteLine($"Nice! {guessCounter} down {(gridHeight * gridWidth) - (10 + guessCounter)} to go!");
                    Console.WriteLine("");
                }

                if (userGuess.isBomb == true)
                {
                    bomb = true;
                }                            
            }

        // Endgame message :(
        
            game.EndGame();

        }
    }
}

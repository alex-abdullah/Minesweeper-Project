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
            int playingGrid = gridWidth * gridHeight;

            // Creates gridWidth x gridHeight null references
            Cell[,] grid = new Cell[gridWidth, gridHeight];

            // One-time initialize (10x10 iterations)
            game.InitializeGrid(grid, gridWidth, gridHeight);

            // Creating Bombs

            game.BombCreator(grid, 10);

            
            // User Welcome Message!            
            game.Welcome();


            // Guess counter
            int guessCounter = 0;

            // Allowing User to Make Guesses
            bool gameActive = true;

            while (gameActive == true)
            {

                int userCol = -1;
                int userRow = -1;

                while (userCol == -1)
                {
                    Console.WriteLine($"Enter column number between {0} and {gridWidth - 1}");
                    string col = Console.ReadLine();
                    Console.WriteLine("");

                    int result = game.TryParseIndex(col, gridWidth);
                                        
                    if (result != -1) 
                    {
                        userCol = result;
                    }
                }

                while (userRow == -1)
                {
                    Console.WriteLine($"Enter row number between {0} and {gridHeight - 1}");
                    string row = Console.ReadLine();
                    Console.WriteLine("");

                    int result = game.TryParseIndex(row, gridHeight);

                    if (result != -1)
                    {
                        userRow = result;
                    }

                }


                Console.WriteLine($"Cell chosen: [{userCol},{userRow}]");

                //Storing User's Guess
                Cell userGuess = grid[userCol, userRow];


                if (userGuess.isBomb == false && userGuess.alreadyChecked == true)
                {
                    game.CellAlreadyChosen();
                }

                if (userGuess.isBomb == false && userGuess.alreadyChecked == false)
                {
                    guessCounter++;
                    userGuess.alreadyChecked = true;
                    Console.WriteLine($"Nice! {guessCounter} down {playingGrid - (10 + guessCounter)} to go!");
                    Console.WriteLine("");
                }


                // Checking for bombs
                game.BombChecker(grid, userCol, userRow);

                // Printing out number of bombs
                Console.WriteLine(game.BombChecker(grid, userCol, userRow));
                Console.WriteLine("");


                // Winner Winner Chicken Dinner :)
                if (guessCounter == playingGrid - 10)
                {
                    Console.WriteLine("You win!!!");
                    gameActive = false;
                }



                // If you choose a bomb :(
                if (userGuess.isBomb == true)
                {
                    game.EndGame();
                    gameActive = false;
                }

            }
        }      

    }
}

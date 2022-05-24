using System;
using System.Collections.Generic;

namespace Minesweeper
{
    class Program {



        static void Main(string[] args)
        {            
            Grid playingGrid = new Grid(10, 10); // Creating Playing Grid 
            playingGrid.BombCreator(10); // Generating Random bombs
            game.Welcome(); // Welcome to the game :)     
                        
            int guessCounter = 0; // Guess counter

            // Allowing User to Make Guesses
            bool gameActive = true;

            while (gameActive == true)
            {
                int userCol = -1;
                int userRow = -1;

                while (userCol == -1)
                {
                    Console.WriteLine($"Enter column number between {0} and {playingGrid.GridWidth - 1}");
                    string col = Console.ReadLine();
                    Console.WriteLine("");
                    int result = game.TryParseIndex(col, playingGrid.GridWidth);                                        
                    if (result != -1) 
                    {
                        userCol = result;
                    }
                }

                while (userRow == -1)
                {
                    Console.WriteLine($"Enter row number between {0} and {playingGrid.GridHeight - 1}");
                    string row = Console.ReadLine();
                    Console.WriteLine("");
                    int result = game.TryParseIndex(row, playingGrid.GridHeight);

                    if (result != -1)
                    {
                        userRow = result;
                    }

                }

                Console.WriteLine($"Cell chosen: [{userCol},{userRow}]"); // Displaying cell chosen by user                
                Cell userGuess = playingGrid.GameGrid[userCol, userRow]; //Storing User's Guess


                if (userGuess.isBomb == false && userGuess.alreadyChecked == true)
                {
                    game.CellAlreadyChosen();
                }

                if (userGuess.isBomb == false && userGuess.alreadyChecked == false)
                {
                    guessCounter++;
                    userGuess.alreadyChecked = true;
                    Console.WriteLine($"Nice! {guessCounter} down {playingGrid.GridWidth * playingGrid.GridHeight - (10 + guessCounter)} to go!");
                    Console.WriteLine("");
                }
                                
                playingGrid.BombChecker(userCol, userRow); // Checking for bombs                
                Console.WriteLine(playingGrid.BombChecker(userCol, userRow)); // Displaying number of bombs
                Console.WriteLine("");


                // Winner Winner Chicken Dinner :)
                if (guessCounter == playingGrid.GridWidth * playingGrid.GridHeight - 10)
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

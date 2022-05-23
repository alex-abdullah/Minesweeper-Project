﻿using System;
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

            // Creating Bombs
                       
            game.BombCreator(grid, 10);

            // User Welcome Message!            
            game.Welcome();


            // Guess counter
            int guessCounter = 0;

            // Allowing User to Make Guesses
            bool bomb = false;

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

                

                //===============================================================

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

                int bombCounter = 0;
                               
                
                if (a - 1 >= 0 && grid[(a - 1), b].isBomb == true)
                    bombCounter++;

                if (a + 1 <= 9 && grid[(a + 1), b].isBomb == true)
                    bombCounter++;

                if (b - 1 >= 0 && grid[a, (b - 1)].isBomb == true)
                    bombCounter++;

                if (b + 1 <= 9 && grid[a, (b + 1)].isBomb == true)
                    bombCounter++;

                if (a - 1 > 0 && b - 1 >= 0 && grid[(a - 1), (b - 1)].isBomb == true)
                    bombCounter++;

                if (a + 1 <= 9 && b - 1 >= 0 && grid[(a + 1), (b - 1)].isBomb == true)
                    bombCounter++;

                if (a + 1 <= 9 && b + 1 <= 9 && grid[(a + 1), (b + 1)].isBomb == true)
                    bombCounter++;

                if (a - 1 > 0 && b + 1 <= 9 && grid[(a - 1), (b + 1)].isBomb == true)
                    {
                    bombCounter++;              

                    }

                Console.WriteLine($"There are {bombCounter} bomb(s) nearby");

                if (userGuess.isBomb == true)
                {
                    bomb = true;
                }

            }

        // Endgame message :(
        
            game.EndGame();

        }

        // TODO:

        /* Generate message to indicate how many bombs are near coordinate
         * Once MVP finished, push to GitHub and attempt to create
         * Grid Class -> Speak to Pang
         */
    }
}

﻿using System;
using System.Text;

namespace SnakesAndLadders
{
    public class Program
    {
        private static Random rng;

        private static string Player0="🐟";
        private static int Player0Pos=5;
        private static string Player1="🥩";
        private static int Player1Pos=15;
        
        private static string CE1="🐍";
        private static int CasaEsp1_1=13;
        private static int CasaEsp1_2=12;
        private static string CE2="🐯";
        private static int CasaEsp2_1=18;
        private static int CasaEsp2_2=17;



        private static void Main(string[] args)
        {
            // Board Lines and Columns
            int boardX = 5;
            int boardY = 5;

            // Init random number generator
            rng = new Random();
            
            // Set UTF-8 for emojis 
            Console.OutputEncoding = Encoding.UTF8;

            // Create board with the Lines and Columns
            int[,] board = new int[boardX, boardY];

            board = FillBoard(board);

            DrawBoard(board);

        }

        

        /// <summary>
        /// Get created board, fill it with values
        /// </summary>
        /// <param name="board">Board of the game</param>
        private static int[,] FillBoard(int[,] board)
        {
            int tileNumber = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = tileNumber;
                    tileNumber++;
                }
            }
            return board;
        }

        
        /// <summary>
        /// Draws board to the console
        /// </summary>
        /// <param name="board">Board of the game</param>
        private static void DrawBoard(int[,] board){
            // Draw Lines
            for (int i = board.GetLength(0)-1; i >= 0; i--)
            {
                Console.Write("|");
                // Draw Columns
                // If Even
                if (i % 2 == 0)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        DrawTile(board[i,j]);                        
                    }
                    Console.WriteLine();
                }
                // If Odd
                else
                {
                    for (int j = board.GetLength(1)-1; j >= 0; j--)
                    {
                        DrawTile(board[i,j]);    
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Receives the current position of the board
        /// and draws in the tile, their number, the player or the ladders or snakes
        /// </summary>
        /// <param name="board">Current position being drawn</param>
        private static void DrawTile(int board)
        {
            // Player Tiles
            if(board == Player0Pos-1)
            {
                Console.Write($"{Player0,3:d} |");
            }
            else if (board == Player1Pos-1)
            {
                Console.Write($"{Player1,3:d} |");
            }
            // Special Tiles
            else if (board == CasaEsp1_1-1 || board == CasaEsp1_2-1)
            {
                Console.Write($"{CE1,3:d} |");
            }
            else if (board == CasaEsp2_1-1 || board == CasaEsp2_2-1)
            {
                Console.Write($"{CE2,3:d} |");
            }
            // Normal Tiles
            else
            {
                Console.Write($"{board+1,3:d} |");
            }
        }

        
        




        /// <summary>
        /// Rolls a die of some number of <paramref name="sides"/>.
        /// </summary>
        /// <param name="sides">Number of sides of the die.</param>
        /// <returns>Integer between 1 and <paramref name="sides"/>.</returns>
        private static int RollDie(int sides)
        {
            return rng.Next() % sides + 1;
        }


        /// <summary>
        /// Rolls a die and moves a player forward. The <paramref name="player"/>
        /// passed in is modified.
        /// </summary>
        /// <param name="board">The board the player is in.</param>
        /// <param name="player">The player to move.</param>
        private static void MovePlayer(int [,] board, int[] player)
        {
            int newRow = player[0], newCol = player[1];

            // Roll die to find spaces to move
            int spacesToMove = RollDie(6);

            for (int i = 0; i < spacesToMove; i++)
            {
                // If moving on an even row, go right...
                // else, go left
                if (newRow % 2 == 0)
                {
                    newCol++;
                }
                else
                {
                    newCol--;
                }

                // If player goes out of bounds of a row,
                // move it to the first column of the next row
                if (newCol < 0)
                {
                    newCol = 0;
                    newRow++;
                }
                else if (newCol >= board.GetLength(1))
                {
                    newCol = board.GetLength(1) - 1;
                    newRow++;
                }
            }

            // Set player position to new position
            player[0] = newRow;
            player[1] = newCol;
        }

    }
}

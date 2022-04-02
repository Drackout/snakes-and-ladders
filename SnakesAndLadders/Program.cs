using System;

namespace SnakesAndLadders
{
    public class Program
    {
        private static Random rng;

        private static void Main(string[] args)
        {

            //Board Size Lines and Columns
            int boardX = 5;
            int boardY = 5;

            // Init random number generator
            rng = new Random();

            //int linhaDeJogo = boardX * boardY;

            //Create the board with the Lines and Columns
            int[,] board = new int[boardX, boardY];

            board = FillBoard(board);

            //DrawBoard(board);


            //Draw Board | TODO Invert the array and write le zig zag
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i,j]} | ");
                }
                Console.WriteLine();
            }

            /*
            board[0,1] = 1;
            Console.WriteLine(board[0,1]);
            */


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

        /*
        /// <summary>
        /// Draws board to the console
        /// </summary>
        /// <param name="board">Board of the game</param>
        private static void DrawBoard(int[,] board){
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i,j]}");
                }
                Console.WriteLine();
            }
            return 0;
        }
        */

        /// <summary>
        /// Rolls a die of some number of <paramref name="sides"/>.
        /// </summary>
        /// <param name="sides">Number of sides of the die.</param>
        /// <returns>Integer between 1 and <paramref name="sides"/>.</returns>
        private static int RollDie(int sides)
        {
            return rng.Next() % sides + 1;
        }


        private static int MovePlayerTo(int[,] board, int[] player, int row, int col)
        {
            int status;

            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
            {
                player[0] = row;
                player[1] = col;
                status = 0;
            }
            else
            {
                status = 1;
            }

            if (player[0] == board.Length - 1)
            {
                status = 2;
            }

            return status;
        }


        private static int[] SpaceAtDistance(int[,] board, int startRow, int startCol, int distance)
        {
            int startNumber;

            // Convert row and column to space number
            if (startRow % 2 == 0)
            {
                startNumber = startRow * board.GetLength(1) + startCol;
            }
            else
            {
                startNumber = startRow * board.GetLength(1) + (board.GetLength(1) - 1 - startCol);
            }

            // Add distance to travel
            int endNumber = startNumber + distance;
            if (endNumber < 0)
                endNumber = 0;
            else if (endNumber > board.Length)
                endNumber = board.Length - 1;

            // Convert back to row and column
            int endRow, endCol;
            endRow = endNumber / board.GetLength(1);
            if (endRow % 2 == 0)
            {
                endCol = endNumber % board.GetLength(1);
            }
            else
            {
                endCol = board.GetLength(1) - 1 - endNumber % board.GetLength(1);
            }

            return new int[] { endRow, endCol };
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
            MovePlayerTo(board, player, newRow, newCol);
        }

    }
}

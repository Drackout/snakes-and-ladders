using System;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {

            //Board Size Lines and Columns
            int boardX = 5;
            int boardY = 5;

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

    }
}

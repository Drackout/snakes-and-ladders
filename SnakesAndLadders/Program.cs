using System;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {

            //Draw the map
            int boardX = 5;
            int boardY = 5;

            int[][] board = new int[boardX][boardY];

            board[0][1] = 1;

            Console.WriteLine(board[0][1]);

            
        }
    }
}

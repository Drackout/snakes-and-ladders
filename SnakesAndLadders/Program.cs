using System;
using System.Text;

namespace SnakesAndLadders
{
    public class Program
    {
        private static Random rng;

        private static string player0 = "🐟";
        private static int player0Pos = 1;
        private static string player1 = "🥩";
        private static int player1Pos = 1;

        private static int[][] players = new int[2][];

        
        private static string CE1="🐍";
        private static int casaEsp1_1=13;
        private static int casaEsp1_2=12;
        private static string CE2="🐯";
        private static int casaEsp2_1=18;
        private static int casaEsp2_2=17;



        private static void Main(string[] args)
        {
            // Board Lines and Columns
            int boardX = 5;
            int boardY = 5;
            
            //Vars TESTE
            int PlayerTurn = 0;
            int RolledDie;
            players[0] = new int[2] {0,0};
            players[1] = new int[2] {0,0};

            // Init random number generator
            rng = new Random();
            
            // Set UTF-8 for emojis 
            Console.OutputEncoding = Encoding.UTF8;

            // Create board with the Lines and Columns
            int[,] board = new int[boardX, boardY];

            board = FillBoard(board);

            DrawBoard(board);


            while (true)
            {
                //Switch Player
                if (PlayerTurn == 0)
                {
                    PlayerTurn = 1;
                }
                else
                {
                    PlayerTurn = 0;
                }
                
                // Show the player playing 
                Console.WriteLine($"Player {PlayerTurn} Turn!");

                // Check Extra Die
                //RollDie(12);

                // Check Cheat Die

                // Roll Die
                RolledDie = RollDie(6);

                //Console.WriteLine(players[0][0]);
                //Console.WriteLine(players[0][1]);
                //Console.WriteLine(players[1][0]);
                //Console.WriteLine(players[1][1]);


                //SpaceAtDistance(board, players[PlayerTurn][0], players[PlayerTurn][1], RolledDie),
                //SpaceAtDistance(board, players[PlayerTurn][0], players[PlayerTurn][1], RolledDie)
                
                // Move player to new position
                //Console.WriteLine(MovePlayerTo(board, players[PlayerTurn], 1, 1));
                int[] AAAA = SpaceAtDistance(board, players[PlayerTurn][0], players[PlayerTurn][1], RolledDie);


                Console.WriteLine(RolledDie);
                Console.WriteLine(AAAA[0]);
                Console.WriteLine(AAAA[1]);
                
                Console.WriteLine(board[AAAA[0], AAAA[1]]);
                
                if (PlayerTurn == 0)
                {
                    player0Pos += board[AAAA[0], AAAA[1]];
                }
                else
                {
                    player1Pos += board[AAAA[0], AAAA[1]];
                }

                Console.ReadKey();

                DrawBoard(board);

            }





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
            if(board == player0Pos-1)
            {
                Console.Write($"{player0,3:d} |");
            }
            else if (board == player1Pos-1)
            {
                Console.Write($"{player1,3:d} |");
            }
            // Special Tiles
            else if (board == casaEsp1_1-1 || board == casaEsp1_2-1)
            {
                Console.Write($"{CE1,3:d} |");
            }
            else if (board == casaEsp2_1-1 || board == casaEsp2_2-1)
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
        /// Updates the player's position.
        /// </summary>
        /// <param name="board">Game board where the player is.</param>
        /// <param name="player">The player to move.</param>
        /// <param name="row">The row of the cell to move to.</param>
        /// <param name="col">The column of the cell to move to.</param>
        /// <returns>
        /// A status code: 0 for successful movement, 1 for forbidden movement,
        /// 2 for landing on the final space. (is this useful?)
        /// </returns>
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


        /// <summary>
        /// Converts a space in cell format to number format.
        /// </summary>
        /// <param name="board">The board where the space is.</param>
        /// <param name="row">The row of the cell.</param>
        /// <param name="col">The column of the cell.</param>
        /// <returns>The space represented as a number.</returns>
        private static int SpaceCellToNumber(int[,] board, int row, int col)
        {
            int number;
            if (row % 2 == 0)
            {
                number = row * board.GetLength(1) + col;
            }
            else
            {
                number = row * board.GetLength(1) + (board.GetLength(1) - 1 - col);
            }

            return number;
        }


        /// <summary>
        /// Converts a space in number format to cell format.
        /// </summary>
        /// <param name="board">The board where the space is.</param>
        /// <param name="number">The number of the space.</param>
        /// <returns>The space represented as a cell.</returns>
        private static int[] SpaceNumberToCell(int[,] board, int number)
        {
            int row, col;
            row = number / board.GetLength(1);
            if (row % 2 == 0)
            {
                col = number % board.GetLength(1);
            }
            else
            {
                col = board.GetLength(1) - 1 - number % board.GetLength(1);
            }

            return new int[] { row, col };
        }


        private static int[] SpaceAtDistance(int[,] board, int startRow, int startCol, int distance)
        {
            // Convert row and column to space number
            int startNumber = SpaceCellToNumber(board, startRow, startCol);

            // Add distance to travel
            int endNumber = startNumber + distance;
            if (endNumber < 0)
                endNumber = 0;
            else if (endNumber > board.Length)
                endNumber = board.Length - 1;

            // Convert back to row and column
            int[] endCell = SpaceNumberToCell(board, endNumber);

            return endCell;
        }


        private static int ReturnIfPastEnd(int[,] board, int space)
        {
            int newSpace = space;

            if (newSpace > board.Length)
            {
                int finalSpace = board.Length - 1;
                int excessMovement = newSpace - finalSpace;
                newSpace = finalSpace - excessMovement;
            }

            return newSpace;
        }


        /*
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
        */

    }
}

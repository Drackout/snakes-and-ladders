using System;
using System.Text;

namespace SnakesAndLadders
{
    public class Program
    {
        private static Random rng;

        private static string player0 = "🐟";
        private static string player1 = "🥩";
        private static int player0Pos = 1;
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

            //DrawBoard(board);


            // Game Loop
            while (true)
            {
                
                
                // Show the current player 
                Console.WriteLine($"Player {PlayerTurn} Turn!");

                // Check Extra Die
                //RollDie(12);

                // Check Cheat Die

                // Roll Normal Die
                RolledDie = RollDie(6);

                // Gets the distance the player will walk
                int[] DistanceValues = SpaceAtDistance(board, players[PlayerTurn][0], players[PlayerTurn][1], RolledDie);

                Console.WriteLine(RolledDie);
                Console.WriteLine(DistanceValues[0]);
                Console.WriteLine(DistanceValues[1]);

                

                //Check player turn
                if (PlayerTurn == 0)
                {
                    // Player walks the distance
                    player0Pos += SpaceCellToNumber(board, DistanceValues[0], DistanceValues[1]);

                    // If player walks past the limit of the board
                    player0Pos = ReturnIfPastEnd(board, player0Pos);

                    // Verifies if current player's on same tile
                    if(VerifySamePosition(player0Pos, player1Pos) == 1 && player1Pos != 1)
                    {
                        // Oponent returns 1 tile
                        --player1Pos;
                    }
                }
                else
                {
                    // Player walks the distance
                    player1Pos += SpaceCellToNumber(board, DistanceValues[0], DistanceValues[1]);
                    
                    // If player walks past the limit of the board
                    player1Pos = ReturnIfPastEnd(board, player1Pos);

                    // Verifies if current player's on same tile
                    if(VerifySamePosition(player0Pos, player1Pos) == 1 && player0Pos != 1)
                    {
                        // Oponent returns 1 tile
                        --player0Pos;
                    }
                }



                // Draw board with updated player locations
                DrawBoard(board);
                
                // Check which Player won by checking the most recent reaching the end
                if (player0Pos == board.Length || player1Pos == board.Length)
                {
                    Console.WriteLine($"Player {PlayerTurn} Won!");
                    Console.WriteLine("Congrats!!");
                    break;
                }

                // Let the player see the new movement that happened before proceeding
                Console.ReadKey();

                //Switch Player Turns
                if (PlayerTurn == 0)
                {
                    PlayerTurn = 1;
                }
                else
                {
                    PlayerTurn = 0;
                }

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

        /// <summary>
        /// Compares if the given players positions is the same
        /// </summary>
        /// <param name="p0Position">Player 0 board position</param>
        /// <param name="p1Position">Player 1 board position</param>
        /// <returns>0 on different tiles, 1 on same tile</returns>
        private static int VerifySamePosition(int p0Position, int p1Position)
        {
            if (p0Position != p1Position)
            {
                return 0;
            } 
            else
            {
                return 1;
            }
        }


    }
}

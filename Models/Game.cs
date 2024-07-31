using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeAssn.Models
{
    internal class Game
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        public void Start()
        {
            int moveCount = 0;
            bool gameWon = false;

            while (moveCount < 9 && !gameWon)
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (1-9):");
                int move = Convert.ToInt32(Console.ReadLine()) - 1;

                if (board[move] == ' ')
                {
                    board[move] = currentPlayer;
                    moveCount++;
                    gameWon = CheckWin();

                    if(!gameWon)
                        SwitchPlayer();
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }



            PrintBoard();
            if (gameWon)
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        public bool CheckWin()
        {

            int[][] winPatterns =
            {
                   new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                 new int[] { 2, 5, 8 },
                  new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
                                         };

            foreach (var pattern in winPatterns)
            {
                if (board[pattern[0]] == currentPlayer && board[pattern[1]] == currentPlayer && board[pattern[2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
            

        }

        public void SwitchPlayer()
        {
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }
        }
    }
}


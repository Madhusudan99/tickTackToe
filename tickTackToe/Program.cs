using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickTackToe
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            int numberOfStepsPlayed = 1;
            int numberOfRemainingMoves = 9;
            string[] currentStatus = {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool won = false;

            while(numberOfRemainingMoves != 0)
            {
                
                printGameBoard(currentStatus);
                Console.WriteLine();
                Console.WriteLine("Player 1: X");
                Console.WriteLine("Player 2: 0");
                Console.WriteLine();
                int player = getWitchPlayersTurn(numberOfStepsPlayed);
                Console.WriteLine($"Player {player}'s turn");
                Console.WriteLine("Enter  your choice: ");
                string userChoice = Console.ReadLine();

                if(currentStatus[Convert.ToInt32(userChoice) - 1] == "X" || currentStatus[Convert.ToInt32(userChoice) - 1] == "0")
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    currentStatus[Convert.ToInt32(userChoice) - 1] = playerSign(player);
                    numberOfStepsPlayed++;
                    numberOfRemainingMoves--;

                    won = hasWon(currentStatus);
                    if (won)
                    {
                        Console.Clear();
                        printGameBoard(currentStatus);
                        Console.WriteLine($"Player {player} Won!!!");
                        break;
                    }
                    Console.Clear();
                }
                
            }

            if(!won)
            {
                Console.WriteLine("The match is draw");
            }
            

        }

        private static bool hasWon(string[] currentStatus)
        {
            if(currentStatus[0] == currentStatus[1] && currentStatus[1] == currentStatus[2])
            {
                return true;
            }

            if (currentStatus[0] == currentStatus[3] && currentStatus[3] == currentStatus[6])
            {
                return true;
            }

            if (currentStatus[6] == currentStatus[7] && currentStatus[7] == currentStatus[8])
            {
                return true;
            }

            if (currentStatus[2] == currentStatus[5] && currentStatus[5] == currentStatus[8])
            {
                return true;
            }

            if (currentStatus[0] == currentStatus[4] && currentStatus[4] == currentStatus[8])
            {
                return true;
            }

            if (currentStatus[2] == currentStatus[4] && currentStatus[4] == currentStatus[6])
            {
                return true;
            }

            if (currentStatus[3] == currentStatus[4] && currentStatus[4] == currentStatus[5])
            {
                return true;
            }

            if (currentStatus[1] == currentStatus[4] && currentStatus[4] == currentStatus[7])
            {
                return true;
            }
            return false;
        }

        private static int getWitchPlayersTurn(int numberOfStepsPlayed)
        {
            if (numberOfStepsPlayed % 2 == 0)
            {
                return 2; // Player 2's turn
            }
            return 1; // Player 1's turn
        }

        private static string playerSign(int player)
        {
            if (player == 1)
            {
                return "X";
            }
            return "0";
        }

        private static void printGameBoard(string[] currentStatus)
        {

            Console.WriteLine($" {currentStatus[0]} | {currentStatus[1]} | {currentStatus[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {currentStatus[3]} | {currentStatus[4]} | {currentStatus[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {currentStatus[6]} | {currentStatus[7]} | {currentStatus[8]} ");

        }
    }
}

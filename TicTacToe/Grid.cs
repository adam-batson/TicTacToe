using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Grid
    {
        public char[] Moves { get; private set; }
        public char[] availableMoves { get; private set; }
        
        public Grid()
        {
            ResetGrid();
        }

        public void PrintGrid()
        {
            Console.Clear(); // Clears screen for neatness.
            Console.WriteLine($"\n {Moves[0]} | {Moves[1]} | {Moves[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Moves[3]} | {Moves[4]} | {Moves[5]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Moves[6]} | {Moves[7]} | {Moves[8]}\n");

        }
        
        public void AddToGrid(int index, int turn)
        {
            turn %= 2;

            if(turn == 0)
            {
                Moves[index - 1] = 'X';
            }
            else
            {
                Moves[index - 1] = 'O';
            }

            availableMoves[index - 1] = ' ';
        }

        public void ResetGrid()
        {
            Moves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            availableMoves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
    }
}

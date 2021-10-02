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
        public char[] AvailableMoves { get; private set; }

        public string WinRow1 => $"{Moves[0]}{Moves[1]}{Moves[2]}";
        public string WinRow2 => $"{Moves[3]}{Moves[4]}{Moves[5]}";
        public string WinRow3 => $"{Moves[6]}{Moves[7]}{Moves[8]}";
        public string WinColumn1 => $"{Moves[0]}{Moves[3]}{Moves[6]}";
        public string WinColumn2 => $"{Moves[1]}{Moves[4]}{Moves[7]}";
        public string WinColumn3 => $"{Moves[2]}{Moves[5]}{Moves[8]}";
        public string WinDiagonal1 => $"{Moves[0]}{Moves[4]}{Moves[8]}";
        public string WinDiagonal2 => $"{Moves[2]}{Moves[4]}{Moves[6]}";

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
        
        public void AddToGrid(Player p, int index)
        {
            Moves[index - 1] = p.Shape;
            AvailableMoves[index - 1] = ' ';
        }

        public void ResetGrid()
        {
            Moves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            AvailableMoves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
    }
}

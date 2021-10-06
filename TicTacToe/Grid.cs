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

        // Win conditions update as moves are added to the grid.
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
            Console.WriteLine();
            for (int i = 0; i < Moves.Length; i++)
            {
                SetMovesColor(i); // Prints the move in color based on what's in the index.
                if (i != 2 && i != 5 && i != 8) // Prints a vertical bar if the index isn't the end of a row.
                {
                    Console.Write("|");
                }
                else
                {
                    if (i == 2 || i == 5) // Prints the horizontal bar when the index ends row 1 or row 2.
                    {
                        Console.WriteLine("\n---+---+---");
                    }
                }
            }
            Console.WriteLine();
        }
        
        public void AddToGrid(Player p, int cell)
        {
            Moves[cell - 1] = p.Shape;
            AvailableMoves[cell - 1] = ' ';
        }

        public void ResetGrid()
        {
            Moves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            AvailableMoves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }

        private void SetMovesColor(int i) // Changes color of the shape based on what's in the index passed in.
        {
            if (Moves[i] == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($" {Moves[i]} ");
                Console.ResetColor();
            }
            else if (Moves[i] == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write($" {Moves[i]} ");
                Console.ResetColor();
            }
            else // If no X or O, then it will display the cell number in white.
                Console.Write($" {Moves[i]} ");
        }
    }
}

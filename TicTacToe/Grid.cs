using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Grid
    {
        private char[] moves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public void PrintGrid()
        {
            Console.WriteLine($" {moves[0]} | {moves[1]} | {moves[2]}");
            Console.WriteLine("-----------");
            Console.WriteLine($" {moves[3]} | {moves[4]} | {moves[5]}");
            Console.WriteLine("-----------");
            Console.WriteLine($" {moves[6]} | {moves[7]} | {moves[8]}");

        }

        

        public void AddToGrid(int index, int turn)
        {
            if(turn == 1)
            {
                moves[index - 1] = 'X';
            }
            else
            {
                moves[index - 1] = 'O';
            }
        }

        public void ResetGrid()
        {
            moves = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
    }
}

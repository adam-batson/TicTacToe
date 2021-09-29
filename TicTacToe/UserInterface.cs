using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class UserInterface
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!\n");
            //Console.WriteLine("Rules go here");
        }

        /*public static char ShapeChoice()
        {
            Console.Write($"Player1, choose X or O: ");
            var choice = Console.ReadLine();
            return Convert.ToChar(choice.Trim().ToUpper());
        }*/

        public static int MoveChoice(int player)
        {
            Console.Write($"Player {player}, choose a box: ");
            var index = Console.ReadLine();
            return Convert.ToInt32(index.Trim());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Check
    {   
        public static bool ValidMove(Grid grid, int cell)
        {
            if (cell < 1 || cell > 9)
            {
                Console.WriteLine("\nChoose an unfilled cell from 1 to 9.");
                return false;
            }
            else if (grid.AvailableMoves[cell - 1] == ' ')
            {
                Console.WriteLine("\nThat cell has been filled already. Please choose a free cell.");
                return false;
            }
            else return true;
        }

        public static bool Win(Player p, string[] wincons)
        {
            var win = (wincons.Any(x => x.Equals($"{p.Shape}{p.Shape}{p.Shape}")));

                if (win)
                {
                    p.AddScore();
                }

            return win;
        }

        public static bool YesOrNo(char input) // Checks if user wants to play again
        {
            input = Char.ToUpper(input);
            return (input == 'Y');
        }

        public static char ChosenShape(char c)
        {
            return (c == 'X') ? 'O' : 'X'; // The shape output will be the shape not input.
        }
    }
}


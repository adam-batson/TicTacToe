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
                Console.WriteLine("\nChoose an unfilled cell (1 - 9).");
                return false;
            }
            else if (grid.AvailableMoves[cell - 1] == ' ')
            {
                Console.WriteLine("\nThat cell has been filled already. Please choose a free cell.");
                return false;
            }
            else return true;
        }

        public static bool Win(string[] wincons)
        {
            bool win = false;

                if (wincons.Any(x => x.Equals("XXX"))) // Check if player 1 has 3 in a row.
                {
                    UI.NotifyWin(1);
                    win = true;
                }
                else if (wincons.Any(x => x.Equals("OOO"))) // Check if player 2 has 3 in a row.
                {
                    UI.NotifyWin(2);
                    win = true;
                }

            return win;
        }

        public static char ValidYesOrNo(char input) // Checks if the input is valid
        {
            if (input == 'Y' || input == 'N')
            {
                return input; // Sends back answer for processing.
            }
            else
            {
                Console.WriteLine("\nThat input isn't valid.");
                return ' '; // Sends back space to trigger another prompt for Y or N.
            }
        }
    }
}


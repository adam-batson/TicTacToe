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
            else if (grid.availableMoves[cell - 1] == ' ')
            {
                Console.WriteLine("\nThat cell has been filled already. Please choose a free cell.");
                return false;
            }
            else return true;
        }

        public static bool WinOrDraw(Grid grid, int turn)
        {
            bool win = false;

            for (int i = 0; i < 8; i++) // There are 8 winning possibilities
            {
                string line = "";
                switch (i)
                {
                    case 0:
                        line = $"{grid.Moves[0]}{grid.Moves[1]}{grid.Moves[2]}"; // Put Row 1 entries in a string.
                        break;
                    case 1:
                        line = $"{grid.Moves[3]}{grid.Moves[4]}{grid.Moves[5]}"; // Put Row 2 entries in a string.
                        break;
                    case 2:
                        line = $"{grid.Moves[6]}{grid.Moves[7]}{grid.Moves[8]}"; // Put Row 3 entries in a string.
                        break;
                    case 3:
                        line = $"{grid.Moves[0]}{grid.Moves[3]}{grid.Moves[6]}"; // Put Column 1 entries in a string.
                        break;
                    case 4:
                        line = $"{grid.Moves[1]}{grid.Moves[4]}{grid.Moves[7]}"; // Put Column 2 entries in a string.
                        break;
                    case 5:
                        line = $"{grid.Moves[2]}{grid.Moves[5]}{grid.Moves[8]}"; // Put Column 3 entries in a string.
                        break;
                    case 6:
                        line = $"{grid.Moves[0]}{grid.Moves[4]}{grid.Moves[8]}"; // Put entries along one diagonal in a string.
                        break;
                    case 7:
                        line = $"{grid.Moves[2]}{grid.Moves[4]}{grid.Moves[6]}"; // Put entries along the other diagonal in a string.
                        break;
                }
                if (line == "XXX") // Check if player 1 has 3 in a row.
                {
                    UI.NotifyWin(1);
                    win = true;
                    break; // Stop checking wins.
                }
                else if (line == "OOO") // Check if player 2 has 3 in a row.
                {
                    UI.NotifyWin(2);
                    win = true;
                    break; // Stop checking wins.
                }
                else if (turn == 9) // In 9 turns, the board will be full, and nobody won, so it's a draw.
                {
                    UI.NotifyDraw();
                    break;
                }
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


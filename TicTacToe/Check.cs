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
            // Verifies the cell chosen is between 1 and 9, then checks if it's already filled.
            // Returns if the move is valid.

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

        public static bool Win(Player p, string[] winConditions) // Checks for a win, increments score and returns whether or not p won the game.
        {
            var win = (winConditions.Any(x => x.Equals($"{p.Shape}{p.Shape}{p.Shape}")));

                if (win)
                {
                    p.AddScore();
                }

            return win;
        }

        public static bool YesOrNo(char input) // Returns whether user wants to play again or not.
        {
            input = Char.ToUpper(input);
            return (input == 'Y');
        }

        public static char ChosenShape(char c) // Returns the shape that the first player did not choose.
        {
            return (c == 'X') ? 'O' : 'X'; 
        }
    }
}


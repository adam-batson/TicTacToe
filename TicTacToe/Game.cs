using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public int TurnCount { get; private set; }
        public bool InputIsValid { get; private set; }
        private Grid grid;

        public Game()
        {
            grid = new Grid();
            TurnCount = 0;
            InputIsValid = true;
        }

        public void PlayGame() // Handles the actual running of the game.
        {
            UI.Welcome();
            grid.PrintGrid();

            while (TurnCount < 9) // Once 9 turns are taken, all cells will be full.
            {
                var input = 0;

                do // Asks for input once, but repeats request if the chosen cell is already filled.
                {
                    input = UI.MoveChoice(TurnCount);
                    InputIsValid = Check.CheckValidity(grid, input);
                } while (InputIsValid == false);


                grid.AddToGrid(input, TurnCount); // We get the cell from the player with UI.MoveChoice and sent it to be added to the grid.
                grid.PrintGrid();
                TurnCount++;

                if (TurnCount >= 5) // Turn 5 is the earliest that a win condition can be met.
                {
                    if (Check.CheckWinOrDraw(grid, TurnCount)) // If a win is found, it returns true and exits the game loop.
                        break;
                }
            }
        }
    }    
        
}

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

        private string[] WinConditions => new string[] {grid.WinRow1, grid.WinRow2, grid.WinRow3,
                                                        grid.WinColumn1, grid.WinColumn2, grid.WinColumn3,
                                                        grid.WinDiagonal1, grid.WinDiagonal2 };
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
                    InputIsValid = Check.ValidMove(grid, input);
                } while (InputIsValid == false);


                grid.AddToGrid(input, TurnCount); // We get the cell from the player with UI.MoveChoice and sent it to be added to the grid.
                grid.PrintGrid();
                TurnCount++;

                if (TurnCount >= 5) // Turn 5 is the earliest that a win condition can be met.
                {
                    if (Check.Win(WinConditions)) // If a win is found, it returns true and exits the game loop.
                        break;
                    else if (TurnCount == 9) // If no wins, but also no more moves avalable, calls a draw.
                    {
                        UI.NotifyDraw();
                        break;
                    }
                }
            }

        }
    }    
        
}

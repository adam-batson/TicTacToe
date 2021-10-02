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
        public Player P1;
        public Player P2;
        private Grid grid;
        private bool Player1Turn;     
        private string[] WinConditions => new string[] {grid.WinRow1, grid.WinRow2, grid.WinRow3,
                                                        grid.WinColumn1, grid.WinColumn2, grid.WinColumn3,
                                                        grid.WinDiagonal1, grid.WinDiagonal2 };

        public Game()
        {
            grid = new();
            P1 = new();
            P1.Name = "Player 1";
            P2 = new();
            P2.Name = "Player 2";
            TurnCount = 0;
            Player1Turn = true;
            InputIsValid = true;
        }

        public void PlayGame() // Handles the actual running of the game.
        {
            UI.Welcome();
            P1.ChangeShape(UI.GetShape(P1));
            P2.ChangeShape(UI.GetShape(P2));
            UpdateScreen();

            while (TurnCount < 9) // Once 9 turns are taken, all cells will be full.
            {
                var input = 0;

                do // Asks for input once, but repeats request if the chosen cell is already filled.
                {
                    input = UI.MoveChoice(TurnCount);
                    InputIsValid = Check.ValidMove(grid, input);
                } while (InputIsValid == false);

                if (Player1Turn)
                {
                    grid.AddToGrid(P1, input); // We get the cell from the player and send it to be added to the grid.
                }
                else
                {
                    grid.AddToGrid(P2, input);
                }

                UpdateScreen();
                TurnCount++;

                if (TurnCount >= 5) // Turn 5 is the earliest that a win condition can be met.
                {
                    if (Player1Turn)
                    {
                        if (Check.Win(P1, WinConditions)) // If a win is found, it returns true and exits the game loop.
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (Check.Win(P2, WinConditions))
                        {
                            break;
                        } 
                    }
                    if (TurnCount == 9) // If no wins, but also no more moves avalable, calls a draw.
                    {
                        UI.NotifyDraw();
                        break;
                    }
                }

                if (TurnCount % 2 == 1)
                {
                    Player1Turn = !Player1Turn; // Switches the player whose turn it is every other turn.
                }
            }

        }

        private void UpdateScreen()
        {
            grid.PrintGrid();
            UI.PrintScore(P1, P2);
        }
    }    
        
}

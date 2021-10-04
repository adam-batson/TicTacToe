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
        Random rand;
        private Grid grid;
        private bool Player1Turn;     
        private string[] WinConditions => new string[] {grid.WinRow1, grid.WinRow2, grid.WinRow3,
                                                        grid.WinColumn1, grid.WinColumn2, grid.WinColumn3,
                                                        grid.WinDiagonal1, grid.WinDiagonal2 };

        public Game()
        {
            grid = new();
            TurnCount = 0;
            Player1Turn = true; // Defaults to Player 1's turn first.
            InputIsValid = true;
            rand = new Random();
        }

        public void PlayGame(Player p1, Player p2) // Handles the actual running of the game.
        {
            char chosenShape; // Holds the shape chosen by the first player.

            if (rand.Next(0,2) == 0) // Player 1 chooses shape.
            {
                UI.GoesFirst(p1);
                chosenShape = UI.GetShape(p1);
                p1.ChangeShape(chosenShape);

                var p2Shape = Check.ChosenShape(chosenShape); // assigns Player 2 shape based on Player 1's choice.
                p2.ChangeShape(p2Shape);
            }
            else // Player 2 chooses shape.
            {
                Player1Turn = !Player1Turn; // It is not Player 1's turn.

                UI.GoesFirst(p2);
                chosenShape = UI.GetShape(p2);
                p2.ChangeShape(chosenShape);

                var p1Shape = Check.ChosenShape(chosenShape); // assigns Player 1 shape based on Player 2's choice.
                p1.ChangeShape(p1Shape);
            }

            UpdateScreen(p1, p2);

            while (TurnCount < 9) // Once 9 turns are taken, all cells will be full.
            {
                int moveInput;

                do // Asks for input once, but repeats request if the chosen cell is already filled.
                {
                    moveInput = Player1Turn ? UI.MoveChoice(p1) : UI.MoveChoice(p2);
                    InputIsValid = Check.ValidMove(grid, moveInput);
                } while (InputIsValid == false);

                if (Player1Turn)
                {
                    grid.AddToGrid(p1, moveInput); // We get the cell from the player and send it to be added to the grid.
                }
                else
                {
                    grid.AddToGrid(p2, moveInput);
                }

                UpdateScreen(p1, p2);
                TurnCount++;

                if (TurnCount >= 5) // Turn 5 is the earliest that a win condition can be met.
                {
                    if (Player1Turn)
                    {
                        if (Check.Win(p1, WinConditions)) // If a win is found, it returns true and exits the game loop.
                        {
                            UpdateScreen(p1, p2);
                            UI.NotifyWin(p1);
                            break;
                        }
                    }
                    else
                    {
                        if (Check.Win(p2, WinConditions))
                        {
                            UpdateScreen(p1, p2);
                            UI.NotifyWin(p2);
                            break;
                        }
                    }
                    if (TurnCount == 9) // If no wins, but also no more moves avalable, calls a draw.
                    {
                        UI.NotifyDraw();
                        break;
                    }
                }

                Player1Turn = !Player1Turn; // Changes the turn.
            }
        }

        private void UpdateScreen(Player p1, Player p2)
        {
            grid.PrintGrid();
            UI.PrintScore(p1, p2);
        }
    }    
        
}

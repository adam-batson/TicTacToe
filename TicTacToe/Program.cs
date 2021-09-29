using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserInterface.Welcome();
            //UserInterface.ShapeChoice();

            Grid grid = new();

            grid.PrintGrid();

            grid.AddToGrid(UserInterface.MoveChoice(1), 1);
            grid.PrintGrid();
            grid.AddToGrid(UserInterface.MoveChoice(2), 2);
            grid.PrintGrid();
            grid.AddToGrid(UserInterface.MoveChoice(1), 1);
            grid.PrintGrid();

        }
    }
}

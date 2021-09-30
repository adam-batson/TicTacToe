using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Game game = new();
                game.PlayGame();
            } while (UI.PlayAgain());
        }
    }
}

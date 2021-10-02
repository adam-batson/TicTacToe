using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new();
            Player p2 = new();
            p1.Name = "Player 1";
            p2.Name = "Player 2";

            UI.Welcome();

            p1.Name = UI.GetName(p1);
            p2.Name = UI.GetName(p2);

            do
            {
                Game game = new();
                game.PlayGame(p1, p2);
            } while (UI.AskToPlayAgain());
        }
    }
}

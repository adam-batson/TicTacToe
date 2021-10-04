using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize players here to allow Name, Score, GamesPlayed to carry over between games.
            Player p1 = new(); 
            Player p2 = new();

            // Initializes player names so we know who's being asked to enter a name later.
            p1.ChangeName("Player 1"); 
            p2.ChangeName("Player 2");

            UI.Welcome(); // Display welcome and rules.

            Console.Clear();

            // Allow players to choose names.
            p1.ChangeName(UI.GetName(p1)); 
            p2.ChangeName(UI.GetName(p2));

            // Play game, then loop until players don't want to play anymore.
            do
            {
                Game game = new();
                game.PlayGame(p1, p2);
            } while (UI.AskToPlayAgain());
        }
    }
}

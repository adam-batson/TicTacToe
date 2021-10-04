using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class UI
    {
        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to Tic-Tac-Toe!");
            Console.WriteLine("\nHere are the rules:");
            Console.WriteLine("\nPlayers will enter their names.");
            Console.WriteLine("The first player will be randomly chosen each game.");
            Console.WriteLine("\nThe first player chooses X or O, and the second player gets the leftover shape.");
            Console.WriteLine("On their turn, players will choose a cell from 1 to 9, shown on the grid.");
            Console.WriteLine("The chosen cell will be filled with that player's shape.");
            Console.WriteLine("Any cell still showing its number is a valid move choice.");
            Console.WriteLine("\nWhen a player gets 3 in a row vertically, horizontally, or diagonally, the game is won!");
            Console.WriteLine("If the board is filled before any player wins, the game is a draw.");
            Console.WriteLine("\nPress any key to begin.");
            Console.ReadKey();
        }

        public static int MoveChoice(Player p) // Gets a player's move choice and makes sure it's an int.
        {
            bool validInput;
            int chosenCell;

            do // If the input can't parse into int, this loops.
            {
                Console.Write($"\n{p.Name}, choose a cell from 1 to 9 that is still available: ");
                validInput = Int32.TryParse(Console.ReadLine(), out chosenCell);

                if (!validInput)
                {
                    Console.WriteLine("\nOnly whole numbers are valid."); // Tells player that input must be an int.
                }
            } while (!validInput); // Repeats as long as non int input is given.

            return chosenCell;
        }

        public static void NotifyWin(Player p)
        {
            Console.WriteLine($"\n{p.Name} wins!");
        }

        public static void NotifyDraw()
        {
            Console.WriteLine("\nAll cells are filled with no winner. The game is a draw.");
        }

        public static bool AskToPlayAgain()
        {
            bool validInput; // Is the input a char?
            bool validAnswer; // Is the input Y or N?
            bool playAgain; // Did the player want to play again?
            char input; // Holds player input.

            do // If the input can't parse into Char or is not Y or N, this loops.
            {
                Console.Write("\nWould you like to play again? (Y or N): ");
                validInput = Char.TryParse(Console.ReadLine(), out input);
                input = Char.ToUpper(input);
                validAnswer = validInput && (input == 'Y' || input == 'N'); // Checks these conditions to determine whether to loop

                if (!validAnswer)
                {
                    Console.WriteLine("\nYour answer must be Y or N.");
                }
            } while (!validAnswer); // Repeats as long as non-char input is not given, or if input given isn't Y or N.

            playAgain = Check.YesOrNo(input);

            if (!playAgain) // Thanks player for playing if they want to quit the game.
            {
                Console.WriteLine("\nThanks for playing!");
            }

            return playAgain;
        }

        public static char GetShape(Player p) // Gets a player's choice to be X or O.
        {
            bool validInput;
            bool validChoice;
            char c;

            do // If the input can't parse into Char or is not X or O, this loops.
            {
                Console.WriteLine($"\n{p.Name}, do you want to be X or O? ");

                validInput = Char.TryParse(Console.ReadLine(), out c);
                c = Char.ToUpper(c);
                validChoice = validInput && (c == 'X' || c == 'O');

                if (!validChoice)
                {
                    Console.WriteLine("\nYou can only choose X or O.");
                }
            } while (!validChoice); // Repeats if input is non-char or is not X or O.

            Console.Clear();
            return c;
        }

        public static void PrintScore(Player p, Player q)
        {
            var draws = p.GamesPlayed - p.Score - q.Score;

            Console.WriteLine("\nScore");
            Console.WriteLine("-----");
            Console.WriteLine($"{p.Name}: {p.Score}");
            Console.WriteLine($"{q.Name}: {q.Score}");
            Console.WriteLine($"Draws: {draws}");
        }

        public static string GetName(Player p)
        {
            Console.WriteLine($"\n{p.Name}, please enter your name: ");
            var name = Console.ReadLine();
            return name;
        }

        public static void GoesFirst(Player p)
        {
            Console.Clear();
            Console.WriteLine($"\n{p.Name} goes first this game!");
        }
    }
}

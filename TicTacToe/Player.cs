using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; private set; }
        public char Shape { get; private set; }
        public int Score { get; private set; }
        public int GamesPlayed { get; private set; }

        public Player()
        {
            Name = "Player";
            Shape = '!';
            Score = 0;
            GamesPlayed = 0;
        }

        // Properties can only be set from within the class, so these methods handle that.
        public void ChangeName(string input)
        {
            Name = input;
        }

        public void ChangeShape(char c)
        {
            Shape = c;
        }

        public void AddScore()
        {
            Score++;
        }

        public void AddGamesPlayed()
        {
            GamesPlayed++;
        }
    }
}
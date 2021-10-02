using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; set; }
        public char Shape { get; private set; }
        public int Score { get; private set; }

        public Player()
        {
            Name = "Player";
            Shape = '!';
            Score = 0;
        }

        public void ChangeShape(char c)
        {
            Shape = c;
        }

        public void AddScore()
        {
            Score++;
        }
    }
}
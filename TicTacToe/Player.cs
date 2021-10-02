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
        public char[] PossibleShapes { get; private set; }
        public int Score { get; private set; }

        public Player()
        {
            Name = "Player";
            Shape = 'X';
            Score = 0;
            PossibleShapes = new char[] { 'X', 'O', '@', '#', '$', '*' };
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
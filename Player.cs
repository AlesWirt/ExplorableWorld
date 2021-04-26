using System;
using Pastel;
using static System.Console;

namespace ExplorableWorld
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private string PlayerColor;
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = "#ff5900";
        }
        public void Draw()
        {
            SetCursorPosition(X, Y);
            Write(PlayerMarker.Pastel(PlayerColor));
            ResetColor();
        }
    }
}

using System;
using Pastel;
using static System.Console;

namespace ExplorableWorld
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }
        public void Draw()
        {
            for(int y = 0; y < Rows; y++)
            {
                for(int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);

                    string bgColorHex;
                    if(y % 2 == 0)
                    {
                        bgColorHex = x % 2 == 0 ? "#00ffea" : "#008075";
                    }
                    else
                    {
                        bgColorHex = x % 2 == 0 ? "#008075" : "#00ffea";
                    }

                    string fgColorHex = element == "X" ? "#b300c7" : "#080080";
                    Write(element.Pastel(fgColorHex).PastelBg(bgColorHex));
                }
            }
        }
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }
        public bool IsPositionWalkable(int x, int y)
        {
            //Check bounds first.
            if(x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            //Check if the grid is a walkable tile. 
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
    }
}

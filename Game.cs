using System;
using Pastel;
using Figgle;
using static System.Console;

namespace ExplorableWorld
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Welcome to the Maze";
            CursorVisible = false;
            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            
            MyWorld = new World(grid);
            CurrentPlayer = new Player(1, 1);
            RunGameLoop();
        }
        private void DisplayIntro()
        {
            WriteLine(FiggleFonts.Larry3d.Render("Welcome"));
            WriteLine(FiggleFonts.Larry3d.Render("to the maze!")); 
            WriteLine("\nInstructions");
            WriteLine("> Use the arrow keys to move.");
            Write("> Try to reach the goal, thar looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X".Pastel("#6bff93"));
            ResetColor();
            WriteLine("> Press any key to start.");
            ReadKey(true);
        }
        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped!");
            WriteLine("Thanks for playing!");
            WriteLine("Press eny key to exit...");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }
        private void HandlePlayerInput()
        {
            //Get only the most recent key input
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } while (KeyAvailable);
            
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if(MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                //Draw everything
                DrawFrame();
                //Check for player input from the keyboard and move the player
                HandlePlayerInput();
                //Check if the player has reached the exit and end the game if so
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if(elementAtPlayerPos == "X")
                {
                    break;
                }
                //Give the Console a chance to render
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}

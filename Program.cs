using System;
using System.Collections.Generic;

namespace SnakeTheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = Console.LargestWindowHeight;
            int width = Console.LargestWindowWidth;
            // 64*240
            Game game = new Game(height,width);
            TerminalView view = new TerminalView(game);
            view.ReflectGameChanges();
            
            Console.ReadLine();
        }
    }
   public  class TerminalView
    {
        private readonly Queue<GameChangeItem> gameChangeItems = new Queue<GameChangeItem>();
        public TerminalView(Game game)
        {
            gameChangeItems = game.GameChanges;
            Console.WindowHeight = game.height;
            Console.WindowWidth =game.width;


        }
        public void ReflectGameChanges()
        {
            foreach ( var change in gameChangeItems)
            {
                Console.SetCursorPosition(change.SnakeCoordinate.x,change.SnakeCoordinate.y);
                if (change.GameChangeType == GameChangeType.WallAppear)
                {
                    Console.WriteLine("#");
                }
                if (change.GameChangeType == GameChangeType.WallDisapper || change.GameChangeType == GameChangeType.SnakeDisappear)
                {
                    Console.WriteLine();                
                }
                if(change.GameChangeType == GameChangeType.SnakeDisappear)
                {
                    Console.WriteLine("@");
                }
               
            }
        }
    }

}

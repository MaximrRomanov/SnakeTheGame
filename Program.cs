using System;
using System.Collections.Generic;

namespace SnakeTheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            int width = Console.LargestWindowWidth;
            int height = Console.LargestWindowHeight;
            // 64*240
            Game game = new Game((int)(height*0.75),(int)(width*0.75));
            TerminalView view = new TerminalView(game.GameChanges, height, width);
            view.ReflectGameChanges();
            
            Console.ReadLine();
        }
    }
   public  class TerminalView
    {
        private readonly Queue<GameChangeItem> gameChangeItems = new Queue<GameChangeItem>();
        public TerminalView(Queue<GameChangeItem> gameChangeItems, int height, int width)
        {
            this.gameChangeItems = gameChangeItems;
            Console.WindowHeight = height;
            Console.WindowWidth = width;


        }
        public void ReflectGameChanges()
        {
            foreach ( var change in gameChangeItems)
            {
                Console.SetCursorPosition(change.SnakeCoordinate.y,change.SnakeCoordinate.x);
                if (change.GameChangeType == GameChangeType.WallAppear)
                {
                    Console.WriteLine("#");
                }
                if (change.GameChangeType == GameChangeType.WallDisapper || change.GameChangeType == GameChangeType.SnakeDisappear)
                {
                    Console.WriteLine();                
                }
                if(change.GameChangeType == GameChangeType.SnakeAppear)
                {
                    Console.WriteLine("@");
                }
               
            }
        }
    }

}

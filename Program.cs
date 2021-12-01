using System;

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

            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.ReadLine();
        }
    }

}

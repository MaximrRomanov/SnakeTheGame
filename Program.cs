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

            Console.WindowHeight = height;
            Console.WindowWidth = width;
            Console.ReadLine();
        }
    }
   
    class Game
    {
        private readonly int width, height;
        private readonly DotType[,] gameField; // двумерный массив
        private Snake snake;
      public  Game (int height, int  width)
        {
            this.width = width;
            this.height = height;
            gameField = new DotType[height, width]; // измерение 0, измерение 1
            InitGameField();
        }
        private void InitGameField() 
        {
            InitWall();
            InitSnake();
        }
        private void InitWall()

        {
            /*
             * #####################
             * #                   #
             * #                   #
             * #                   #
             * #                   #
             * #                   #
             * #                   #
             * ##################### 
             */

            // верхняя стенка
            for (int i = 0; i < gameField.GetLength(1); i++) // возвращает длину измерения               
            {
                gameField[0,i] = DotType.Wall; 
            }
            // правая стенка
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                gameField[i, gameField.GetLength(1)-1] = DotType.Wall;
            }
            // нижняя стенка
            for (int i = 0; i < gameField.GetLength(1); i++)
            {
                gameField[gameField.GetLength(0)-1,i] = DotType.Wall;
            }
            // левая стенка
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                gameField[i, 0] = DotType.Wall;
            }
        }
        private void InitSnake()
        {
            snake = new Snake(height / 2, width / 2);
        }
        
    }
    class SnakeCoordinateChange
    {
        private readonly Snake
    }
    class Snake
    {
        private readonly Direction direction = Direction.Up;
        private readonly LinkedList<SnakeCoordinate> snake = new LinkedList<SnakeCoordinate>();
        public Snake (int x, int y)
        {
            snake.AddFirst(new LinkedListNode<SnakeCoordinate>(new SnakeCoordinate(x, y)));
        }
    }

}

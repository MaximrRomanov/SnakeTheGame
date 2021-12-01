using System;

namespace SnakeTheGame
{
    public class Game
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
        private void ReflectSnake()
        {
            foreach ( var change in snake.Changes)
            {
                if(change.SnakeCoordinateChangeType == SnakeCoordinateChangeType.Add)
                {
                    gameField[change.SnakeCoordinate.x, change.SnakeCoordinate.y] = DotType.Snake;
                }
                if (change.SnakeCoordinateChangeType == SnakeCoordinateChangeType.Remove)
                {
                    gameField[change.SnakeCoordinate.x, change.SnakeCoordinate.y] = DotType.FreeSpace;
                }
                throw new NotImplementedException();
            }
        }
        private void InitSnake()
        {
            snake = new Snake(height / 2, width / 2);
            ReflectSnake();
        }
        
    }

}

using System;
using System.Collections.Generic;

namespace SnakeTheGame
{
    public class Game
    {
        //!!
        public  readonly int width, height;
        private readonly DotType[,] gameField; // двумерный массив
        private Snake snake;
        public readonly Queue<GameChangeItem> GameChanges = new Queue<GameChangeItem>();
      public  Game (int height, int  width)
        {
            this.height = height;
            this.width = width;
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
                GameChanges.Enqueue(new GameChangeItem(GameChangeType.WallAppear, new SnakeCoordinate(0, i)));
            }
            // правая стенка
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                gameField[i, gameField.GetLength(1)-1] = DotType.Wall;
                GameChanges.Enqueue(new GameChangeItem(GameChangeType.WallAppear, new SnakeCoordinate(i, gameField.GetLength(1) - 1)));
            }
            // нижняя стенка
            for (int i = 0; i < gameField.GetLength(1); i++)
            {
                gameField[gameField.GetLength(0)-1,i] = DotType.Wall;
                GameChanges.Enqueue(new GameChangeItem(GameChangeType.WallAppear, new SnakeCoordinate( gameField.GetLength(0) - 1, i)));
            }
            // левая стенка
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                gameField[i, 0] = DotType.Wall;
                GameChanges.Enqueue(new GameChangeItem(GameChangeType.WallAppear, new SnakeCoordinate(i, 0)));
            }
        }
        private void ReflectSnake()
        {
            foreach (var change in snake.Changes)
            {
                
                if(change.SnakeCoordinateChangeType == SnakeCoordinateChangeType.Add)
                {
                    gameField[change.SnakeCoordinate.x, change.SnakeCoordinate.y] = DotType.Snake;
                    //
                    GameChanges.Enqueue(new GameChangeItem(GameChangeType.SnakeAppear, new SnakeCoordinate(change.SnakeCoordinate.x, change.SnakeCoordinate.y)));
                    continue;
                }
                if (change.SnakeCoordinateChangeType == SnakeCoordinateChangeType.Remove)
                {
                    gameField[change.SnakeCoordinate.x, change.SnakeCoordinate.y] = DotType.FreeSpace;
                    //
                    GameChanges.Enqueue(new GameChangeItem(GameChangeType.SnakeDisappear, new SnakeCoordinate(change.SnakeCoordinate.x, change.SnakeCoordinate.y)));
                    continue;
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

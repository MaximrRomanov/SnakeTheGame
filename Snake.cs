using System.Collections.Generic;

namespace SnakeTheGame
{
    public class Snake
    {
        private readonly Direction direction = Direction.Up;
        private readonly LinkedList<SnakeCoordinate> snake = new LinkedList<SnakeCoordinate>();
        
        public Snake (int x, int y)
        {
            snake.AddFirst(new LinkedListNode<SnakeCoordinate>(new SnakeCoordinate(x, y)));
            Changes.Enqueue(new SnakeCoordinateChange(snake.First.Value, SnakeCoordinateChangeType.Add));
        }
        public  readonly Queue<SnakeCoordinateChange> Changes = new Queue<SnakeCoordinateChange>();
    }

}

namespace SnakeTheGame
{
    public class SnakeCoordinateChange
    {
        public SnakeCoordinate SnakeCoordinate { get; }
        public SnakeCoordinateChangeType SnakeCoordinateChangeType { get; }

       public  SnakeCoordinateChange(SnakeCoordinate snakeCoordinate, SnakeCoordinateChangeType snakeCoordinateChangeType)
        {
            SnakeCoordinate = snakeCoordinate;
            SnakeCoordinateChangeType = snakeCoordinateChangeType;

        }

    }

}

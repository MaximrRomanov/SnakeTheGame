namespace SnakeTheGame
{
    //
    public  class GameChangeItem
    {
        public GameChangeType GameChangeType { get; }
        public SnakeCoordinate SnakeCoordinate { get; }
        public GameChangeItem (GameChangeType gameChangeType, SnakeCoordinate snakeCoordinate)
        {
            GameChangeType = gameChangeType;
            SnakeCoordinate = snakeCoordinate;
        }
        
    }


}

namespace SnakeGame
{
    public class Snake : GameObject
    {
        public static readonly Dictionary<string, Direction> directions = new()
        {
            { "Right" , new Direction(1, 0) },
            { "Left" , new Direction(-1, 0) },
            { "Up" , new Direction(0, -1) },
            { "Down" , new Direction(0, 1) }
        };

        public Direction Direction { get; set; }
        public ConsoleColor SnakeColor { get; set; }

        Pixel head;

        public Snake(int length, Direction direction, ConsoleColor SnakeColor) : base()
        {
            Name = "Snake";
            for (int i = 0; i < length - 1; i++)
            {
                Body.Add(new Pixel(i, 5, SnakeColor));
            }
            
            head = Body[^1];
            Direction = direction;
        }

        

        public void Crawl(bool pop = true)
        {
            if ( pop )
            {
                Body.RemoveAt(0);
            }

            head = new Pixel(head.X + Direction.ColumnOffset, head.Y + Direction.RowOffset, SnakeColor);
            Body.Add(head);
        }
    }
}
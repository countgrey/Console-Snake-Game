namespace SnakeGame;

public class Snake : GameObject
{
    public static readonly Dictionary<string, Direction> directions = new()
    {
        { "Right" , new Direction(1, 0) },
        { "Left" , new Direction(-1, 0) },
        { "Up" , new Direction(0, -1) },
        { "Down" , new Direction(0, 1) }
    };

    private Direction direction;

    public Direction Direction_
    {
        get
        {
            return direction;
        }
        set
        {
            if (value.ColumnOffset != -direction.ColumnOffset && value.RowOffset != -direction.RowOffset) direction = value;
        }
    }

    public ConsoleColor SnakeColor { get; set; }

    Pixel head;

    public Snake(int length, Direction direction_, ConsoleColor SnakeColor) : base()
    {
        for (int i = 0; i < length - 1; i++)
        {
            Body.Add(new Pixel(i, 5, SnakeColor));
        }
        
        head = Body[^1];
        direction = direction_;
    }

    

    public bool Crawl(bool pop = true)
    {
        if ( pop )
        {
            Body.RemoveAt(0);
        }

        head = new Pixel(head.X + direction.ColumnOffset, head.Y + direction.RowOffset, SnakeColor);
        
        foreach (Pixel pos in body)
        {
            if ((pos.X, pos.Y) == (head.X, head.Y))
            {
                return true;
            }
        }

        Body.Add(head);
        return false;
    }
}
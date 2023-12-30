namespace SnakeGame;

class Program
{
    public const int width = 50;
    public const int height = 50;

    public const int borderLeftOffset = 1;
    public const int borderTopOffset = 1;
    public const int borderRightOffset = 1;
    public const int borderBottomOffset = 1;

    private const int msFrameLatency = 50;

    private const ConsoleColor borderColor = ConsoleColor.White;
    private const ConsoleColor SnakeColor = ConsoleColor.White;

    public static GameObject Border;
    public static Snake Player;
    public static Fruit Apple;

    private const string defaultDirection = "Right";

    protected static void Init()
    {
        Console.SetWindowSize(width, height);
        Console.SetBufferSize(width, height);
        Console.CursorVisible = false;

        Engine.ObjectList = 
        [
            new GameObject(CreateBorder(borderLeftOffset, borderTopOffset, borderRightOffset, borderBottomOffset)),
            new Snake(5, Snake.directions[defaultDirection], SnakeColor),
            new Fruit()
        ];

        Border = Engine.ObjectList[0];
        Player = (Snake)Engine.ObjectList[1];
        Apple = (Fruit)Engine.ObjectList[2];
    }

    private static int Loop()
    {
        Border.Draw();
        Player.Draw();
        Apple.Draw();

        string keyInput = ControlInput();
        if (keyInput != " ") Player.Direction = Snake.directions[keyInput];

        if  (Player.TouchedObject() != null)
        {
            if (Player.TouchedObject().Name == "Apple")
            {
                Player.Crawl(false);
            }
        }
        else Player.Crawl();

        if (Apple.TouchedObject() != null) 
        {
            if (Apple.TouchedObject().Name == "Snake")
            {
                Apple.ChangePosition();
            }
        }
        

        return 0;
    }

    public static void Main()
    {
        Init();

        for( ; ; )
        {
            if (Loop() != 0) break;
            Thread.Sleep(msFrameLatency);
            Console.Clear();
        }
    }

    private static string ControlInput()
    {
        ConsoleKey key = ConsoleKey.R;
        if(Console.KeyAvailable == true) key = Console.ReadKey().Key;

        Dictionary<ConsoleKey, string> controls = new()
        {
            { ConsoleKey.RightArrow , "Right" },
            { ConsoleKey.LeftArrow , "Left" },
            { ConsoleKey.UpArrow , "Up" },
            { ConsoleKey.DownArrow , "Down" }
        };

        string? outputDirection = " ";
        if (controls.TryGetValue(key, out string? value)) outputDirection = value;

        return outputDirection;
    }

    private static List<Pixel> CreateBorder(int xOffset = 0, int yOffset = 0, int bottomOffset = 0, int rightOffset = 0)
    { 
        var border = new List<Pixel>();
        
        for (int y = yOffset; y <= height - yOffset; y++)
        {
            border.Add(new Pixel(0, y, borderColor));
            border.Add(new Pixel(width-rightOffset, y, borderColor));
        }

        for (int x = xOffset; x <= width - xOffset; x++)
        {
            border.Add(new Pixel(x, 0, borderColor));
            border.Add(new Pixel(x, height-bottomOffset, borderColor));
        }

        return border;
    }
}
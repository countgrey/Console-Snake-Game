namespace SnakeGame;

class Program
{
    private const ConsoleColor borderColor = ConsoleColor.White;
    private const ConsoleColor SnakeColor = ConsoleColor.White;

    public static Border MainBorder;
    public static Snake Player;
    public static Fruit Apple;

    private const string defaultDirection = "Right";

    protected static void Init()
    {
        Console.SetWindowSize(Engine.width, Engine.height + Engine.bottomInfoSize);
        Console.SetBufferSize(Engine.width, Engine.height + Engine.bottomInfoSize);
        Console.CursorVisible = false;

        Engine.ObjectList = 
        [
            new Border(Border.CreateBorder(Engine.borderLeftOffset, Engine.borderTopOffset, Engine.borderRightOffset, Engine.borderBottomOffset, ConsoleColor.White)),
            new Snake(5, Snake.directions[defaultDirection], SnakeColor),
            new Fruit()
        ];

        MainBorder = (Border)Engine.ObjectList[0];
        Player = (Snake)Engine.ObjectList[1];
        Apple = (Fruit)Engine.ObjectList[2];
    }

    private static int Loop()
    {
        MainBorder.Draw();
        Player.Draw();
        Apple.Draw();

        string keyInput = Engine.ControlInput();
        if (keyInput != " ") Player.Direction = Snake.directions[keyInput];
        
        if  (Player.TouchedObject() != null)
        {
            if (Player.TouchedObject().Name == "Apple")
            {
                Player.Crawl(false);
            }
        }
        else Player.Crawl();

        /*
        if (Apple.TouchedObject() != null) 
        {
            if (Apple.TouchedObject().Name == "Snake")
            {
                Apple.ChangePosition();
            }
        }
        */

        return 0;
    }

    public static void Main()
    {
        Init();

        for( ; ; )
        {
            if (Loop() != 0) break;
            Thread.Sleep(Engine.msFrameLatency);
            Console.Clear();
        }
    }
}
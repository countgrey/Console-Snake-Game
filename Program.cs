namespace SnakeGame;

class Program
{
    private const ConsoleColor borderColor = ConsoleColor.White;
    private const ConsoleColor SnakeColor = ConsoleColor.White;

    private const int borderThickness = 1;

    private static Border MainBorder;
    private static Snake Player;
    private static Fruit Apple;

    private static int score = 0;

    private const string defaultDirection = "Right";

    public const int msFrameLatency = 50;

    protected static void Init()
    {
        Console.SetWindowSize(Engine.width, Engine.height + Engine.bottomInfoSize);
        Console.SetBufferSize(Engine.width, Engine.height + Engine.bottomInfoSize);
        Console.CursorVisible = false;

        Engine.ObjectList = 
        [
            new Border(borderColor, borderThickness),
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
        if (keyInput != " ") Player.Direction_ = Snake.directions[keyInput];

        switch (Player.TouchedObject())
        {
            case GameObject value when value == Apple:
                Apple.ChangePosition();
                if (Player.Crawl(false)) return 1;
                score += 1;
                break;

            case GameObject value when value == MainBorder:
                return 1;

            default:
                if(Player.Crawl()) return 1;
                break;
        }

        Engine.ShowScore(score);

        return 0;
    }

    public static void Main()
    {
        Init();

        while(Loop() == 0)
        {
            Thread.Sleep(msFrameLatency);
            Console.Clear();
        }

        Engine.GameOver();
    }
}
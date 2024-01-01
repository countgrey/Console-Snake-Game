namespace SnakeGame;

public class Engine
{
    public const int width = 50;
    public const int height = 50;

    public const int borderLeftOffset = 0;
    public const int borderTopOffset = 0;
    public const int borderRightOffset = 1;
    public const int borderBottomOffset = 1;

    public const int bottomInfoSize = 2;
    public static int debugValue = 0;

    private static List<GameObject> objectList = [];

    public static List<GameObject> ObjectList { get => objectList; set => objectList = value; }

    public static string ControlInput()
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

    public static void GameOver()
    {
        Console.Clear();
        Console.SetCursorPosition(width/2, height/2);
        Console.Write("GAME OVER!");
        Console.ReadKey();
    }

    public static void ShowScore(int score)
    {
        Console.SetCursorPosition(borderLeftOffset, height + bottomInfoSize - 1);
        Console.Write($"Score: {score}");
    }
}
